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
            url = url.Replace("mastodon.lol", "backend.mangoriver-4d99c329.canadacentral.azurecontainerapps.io");
        }

        return url;
    }
}
