using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class Identity
{
    public string Provider { get; set; } = null!;

    public string Uid { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long Id { get; set; }

    public long? UserId { get; set; }

    public virtual User? User { get; set; }
}
