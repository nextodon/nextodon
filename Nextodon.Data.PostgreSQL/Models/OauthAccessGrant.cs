using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class OauthAccessGrant
{
    public long Id { get; set; }

    public string Token { get; set; } = null!;

    public int ExpiresIn { get; set; }

    public string RedirectUri { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? RevokedAt { get; set; }

    public string? Scopes { get; set; }

    public long ApplicationId { get; set; }

    public long ResourceOwnerId { get; set; }

    public virtual OauthApplication Application { get; set; } = null!;

    public virtual User ResourceOwner { get; set; } = null!;
}
