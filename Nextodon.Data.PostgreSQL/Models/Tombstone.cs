using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class Tombstone
{
    public long Id { get; set; }

    public long? AccountId { get; set; }

    public string Uri { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? ByModerator { get; set; }

    public virtual Account? Account { get; set; }
}
