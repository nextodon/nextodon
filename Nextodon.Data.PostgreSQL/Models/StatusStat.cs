using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class StatusStat
{
    public long Id { get; set; }

    public long StatusId { get; set; }

    public long RepliesCount { get; set; }

    public long ReblogsCount { get; set; }

    public long FavouritesCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Status Status { get; set; } = null!;
}
