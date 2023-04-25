using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class Setting
{
    public long Id { get; set; }

    public string Var { get; set; } = null!;

    public string? Value { get; set; }

    public string? ThingType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? ThingId { get; set; }
}
