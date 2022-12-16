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
        var u = new Uri(url);

        if (u.Host == "mastodon.lol")
        {
            var builder = new UriBuilder(url)
            {
                Host = "backend.mangoriver-4d99c329.canadacentral.azurecontainerapps.io"
            };

            url = builder.Uri.ToString();
        }

        return url;
    }
}
