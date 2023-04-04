using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class StatusesTag
{
    public long StatusId { get; set; }

    public long TagId { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
