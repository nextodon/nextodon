using System;
using System.Collections.Generic;
using System.Net;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class OauthAccessToken
{
    public string Token { get; set; } = null!;

    public string? RefreshToken { get; set; }

    public int? ExpiresIn { get; set; }

    public DateTime? RevokedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Scopes { get; set; }

    public long? ApplicationId { get; set; }

    public long Id { get; set; }

    public long? ResourceOwnerId { get; set; }

    public DateTime? LastUsedAt { get; set; }

    public IPAddress? LastUsedIp { get; set; }

    public virtual OauthApplication? Application { get; set; }

    public virtual ICollection<Device> Devices { get; } = new List<Device>();

    public virtual User? ResourceOwner { get; set; }

    public virtual ICollection<SessionActivation> SessionActivations { get; } = new List<SessionActivation>();

    public virtual ICollection<WebPushSubscription> WebPushSubscriptions { get; } = new List<WebPushSubscription>();
}
