using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class WebauthnCredential
{
    public long Id { get; set; }

    public string ExternalId { get; set; } = null!;

    public string PublicKey { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public long SignCount { get; set; }

    public long? UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User? User { get; set; }
}
