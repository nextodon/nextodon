using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class AccountSummary
{
    public long? AccountId { get; set; }

    public string? Language { get; set; }

    public bool? Sensitive { get; set; }
}
