using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class CustomFilterStatus
{
    public long Id { get; set; }

    public long CustomFilterId { get; set; }

    public long StatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual CustomFilter CustomFilter { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
