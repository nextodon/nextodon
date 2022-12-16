namespace Mastodon;

public static class WebFingerHelper
{
    public static string FixAcct(string acct)
    {
        if (acct.EndsWith("@mastodon.lol"))
        {
            acct = acct.Replace("@mastodon.lol", "backend.mangoriver-4d99c329.canadacentral.azurecontainerapps.io");
        }

        return acct;
    }

    public static string FixUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return url;
        }

        var u = new Uri(url, UriKind.RelativeOrAbsolute);

        if (u.Host == "mastodon.lol")
        {
            var builder = new UriBuilder(u)
            {
                Host = "backend.mangoriver-4d99c329.canadacentral.azurecontainerapps.io"
            };

            url = builder.Uri.ToString();
        }

        return url;
    }
}
