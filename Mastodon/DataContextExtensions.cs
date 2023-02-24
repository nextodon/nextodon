namespace Mastodon;

public static class DataContextExtensions {
    public static async Task<Grpc.Status> GetStatusById(this DataContext db, ServerCallContext context, MastodonClient mastodon, string id, string? meId) {
        var status = await db.Status.FindByIdAsync(id);
        if (status == null) {
            throw new RpcException(new global::Grpc.Core.Status(StatusCode.NotFound, string.Empty));
        }

        var owner = await db.Account.FindByIdAsync(status.AccountId);

        var result = status.ToGrpc(owner!);
        var account = owner!.ToGrpc();
        result.Account = account;

        result.Uri = context.GetUrlPath($"users/{account.Username}/statuses/{status.Id}");
        result.Url = context.GetUrlPath($"@{account.Username}/{status.Id}");

        if (!string.IsNullOrWhiteSpace(status.ReblogedFromId)) {
            result.Reblog = await db.GetStatusById(context, mastodon, status.ReblogedFromId, meId);
        }

        var mediaIds = status.MediaIds;

        if (mediaIds != null) {
            foreach (var mediaId in mediaIds) {
                var media = await mastodon.Media.GetMediaAsync(mediaId);
                media.RaiseExceptions();

                result.MediaAttachments.Add(media.Data!.ToGrpc());
            }
        }
        result.Poll = null;

        if (status.Poll != null) {
            result.Poll = new Grpc.Poll {
                Id = status.Id,
                Kind = Grpc.PollKind.Priority,
                Expired = false,
                ExpiresAt = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(1)),
                VotersCount = 10000,
                VotesCount = 10000,
                Voted = true,
            };

            foreach (var option in status.Poll.Options) {
                result.Poll.Options.Add(new Grpc.Poll.Types.Option { Title = option, VotesCount = 100, });
            }
        }

        {
            var filter1 = Builders<Data.Status>.Filter.Ne(x => x.Deleted, true);
            var filter2 = Builders<Data.Status>.Filter.Eq(x => x.ReblogedFromId, status.Id);
            result.ReblogsCount = (uint)(await db.Status.CountDocumentsAsync(filter1 & filter2));
        }

        if (!string.IsNullOrWhiteSpace(meId)) {
            var filter1 = Builders<Data.Status>.Filter.Ne(x => x.Deleted, true);
            var filter2 = Builders<Data.Status>.Filter.Eq(x => x.ReblogedFromId, status.Id);
            var filter3 = Builders<Data.Status>.Filter.Eq(x => x.AccountId, meId);
            result.Reblogged = (await db.Status.CountDocumentsAsync(filter1 & filter2 & filter3)) > 0;
        }

        return result;
    }
}
