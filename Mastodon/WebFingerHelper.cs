namespace Mastodon;

public static class WebFingerHelper {
    public static string FixAcct(string acct) {
        if (acct.EndsWith("@mastodon.lol")) {
            acct = acct.Replace("@mastodon.lol", "@backend.mangoriver-4d99c329.canadacentral.azurecontainerapps.io");
        }

        return acct;
    }

    public static string FixUrl(string url, string? preferred = null) {
        if (string.IsNullOrEmpty(url)) {
            return url;
        }

        try {
            var u = new UriBuilder(url) {
                Scheme = "https",
                Port = 443,
            };
            var p = new UriBuilder(preferred ?? "backend.mangoriver-4d99c329.canadacentral.azurecontainerapps.io") {
                Scheme = "https",
                Port = 443,
            };

            if (u.Host == "mastodon.lol") {
                var builder = new UriBuilder(u.ToString()) {
                    Host = p.Host,
                };

                url = builder.Uri.ToString();
            }
        }
        catch { }

        return url;
    }
}
