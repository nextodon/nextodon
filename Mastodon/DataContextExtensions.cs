using Grpc.Core;
using Mastodon.Client;
using MongoDB.Driver;
using static Google.Rpc.Context.AttributeContext.Types;

namespace Mastodon;

public static class DataContextExtensions
{
    public static async Task<Grpc.Status> GetStatusById(this DataContext db, ServerCallContext context, MastodonClient mastodon, string id, string? meId)
    {
        var status = await db.Status.FindByIdAsync(id);
        if (status == null)
        {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, string.Empty));
        }

        var owner = await mastodon.Accounts.GetByIdAsync(status.UserId);
        owner.RaiseExceptions();

        var result = status.ToGrpc();
        result.Account = owner.Data!.ToGrpc();

        result.Uri = context.GetUrlPath($"users/{owner.Data!.Username}/statuses/{status.Id}");
        result.Url = context.GetUrlPath($"@{owner.Data!.Username}/{status.Id}");

        if (!string.IsNullOrWhiteSpace(status.ReblogedFromId))
        {
            result.Reblog = await db.GetStatusById(context, mastodon, status.ReblogedFromId, meId);
        }

        var mediaIds = status.MediaIds;

        if (mediaIds != null)
        {
            foreach (var mediaId in mediaIds)
            {
                var media = await mastodon.Media.GetMediaAsync(mediaId);
                media.RaiseExceptions();

                result.MediaAttachments.Add(media.Data!.ToGrpc());
            }
        }

        result.Poll = null;

        {
            var filter1 = Builders<Data.Status>.Filter.Ne(x => x.Deleted, true);
            var filter2 = Builders<Data.Status>.Filter.Eq(x => x.ReblogedFromId, status.Id);
            result.ReblogsCount = (uint)(await db.Status.CountDocumentsAsync(filter1 & filter2));
        }

        if (!string.IsNullOrWhiteSpace(meId))
        {
            var filter1 = Builders<Data.Status>.Filter.Ne(x => x.Deleted, true);
            var filter2 = Builders<Data.Status>.Filter.Eq(x => x.ReblogedFromId, status.Id);
            var filter3 = Builders<Data.Status>.Filter.Eq(x => x.UserId, meId);
            result.Reblogged = (await db.Status.CountDocumentsAsync(filter1 & filter2 & filter3)) > 0;
        }

        return result;
    }
}
