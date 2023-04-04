using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class OauthApplication
{
    public string Name { get; set; } = null!;

    public string Uid { get; set; } = null!;

    public string Secret { get; set; } = null!;

    public string RedirectUri { get; set; } = null!;

    public string Scopes { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool Superapp { get; set; }

    public string? Website { get; set; }

    public string? OwnerType { get; set; }

    public long Id { get; set; }

    public long? OwnerId { get; set; }

    public bool? Confidential { get; set; }

    public virtual ICollection<OauthAccessGrant> OauthAccessGrants { get; } = new List<OauthAccessGrant>();

    public virtual ICollection<OauthAccessToken> OauthAccessTokens { get; } = new List<OauthAccessToken>();

    public virtual User? Owner { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
