namespace Mastodon.Client;

public sealed class MediaClient
{
    private readonly MastodonClient _client;

    internal MediaClient(MastodonClient client)
    {
        _client = client;
    }

    public Task<Response<MediaAttachment>> GetMediaAsync(string id)
    {
        return _client.HttpClient.GetFromJsonWithHeadersAsync<MediaAttachment>($"api/v1/media/{id}", MastodonClient._options);
    }
}
