using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class PgheroSpaceStat
{
    public long Id { get; set; }

    public string? Database { get; set; }

    public string? Schema { get; set; }

    public string? Relation { get; set; }

    public long? Size { get; set; }

    public DateTime? CapturedAt { get; set; }
}
