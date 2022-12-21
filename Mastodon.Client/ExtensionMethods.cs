using System.Text.Json;

namespace Mastodon.Client;

internal static class ExtensionMethods
{
    public static async Task<Response<TValue>> GetFromJsonWithHeadersAsync<TValue>(this HttpClient client, string? requestUri, JsonSerializerOptions? options, CancellationToken cancellationToken = default)
    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        var headers = response.Headers.ToDictionary(x => x.Key.ToLower(), x => x.Value);
        TValue? data = default;

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            data = JsonSerializer.Deserialize<TValue>(content, options);
        }

        return new Response<TValue>(response.StatusCode, data, headers);
    }

    public static async Task<Response<TValue>> PostFromAsync<TValue>(this HttpClient client, string? requestUri, JsonSerializerOptions? options, IEnumerable<KeyValuePair<string, string>>? form = null, CancellationToken cancellationToken = default)
    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        HttpContent httpcontent = form != null && form.Any() ? new FormUrlEncodedContent(form) : new StringContent(string.Empty);

        var response = await client.PostAsync(requestUri, httpcontent, cancellationToken);
        var headers = response.Headers.ToDictionary(x => x.Key.ToLower(), x => x.Value);
        TValue? data = default;

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            data = JsonSerializer.Deserialize<TValue>(content, options);
        }

        return new Response<TValue>(response.StatusCode, data, headers);
    }
}
