using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class WebPushSubscription
{
    public long Id { get; set; }

    public string Endpoint { get; set; } = null!;

    public string KeyP256dh { get; set; } = null!;

    public string KeyAuth { get; set; } = null!;

    public string? Data { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? AccessTokenId { get; set; }

    public long? UserId { get; set; }

    public virtual OauthAccessToken? AccessToken { get; set; }

    public virtual User? User { get; set; }
}
