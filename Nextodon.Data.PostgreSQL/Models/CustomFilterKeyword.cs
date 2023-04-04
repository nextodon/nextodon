using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class CustomFilterKeyword
{
    public long Id { get; set; }

    public long CustomFilterId { get; set; }

    public string Keyword { get; set; } = null!;

    public bool? WholeWord { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual CustomFilter CustomFilter { get; set; } = null!;
}
