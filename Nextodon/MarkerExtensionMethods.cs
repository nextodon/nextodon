namespace Nextodon;

public static class MarkerExtensionMethods
{
    public static Grpc.Marker ToGrpc(this Nextodon.Data.Marker i)
    {
        var v = new Grpc.Marker
        {
            Home = i.Home?.ToGrpc(),
            Notifications = i.Notifications?.ToGrpc(),
        };

        return v;
    }

    public static Grpc.MarkerItem ToGrpc(this Nextodon.Data.Marker.MarkerItem i)
    {
        var v = new Grpc.MarkerItem
        {
            LastReadId = i.LastReadId,
            Version = i.Version,
            UpdatedAt = i.UpdatedAt.ToGrpc(),
        };

        return v;
    }
}
