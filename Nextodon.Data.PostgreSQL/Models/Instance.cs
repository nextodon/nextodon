using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class Instance
{
    public string? Domain { get; set; }

    public long? AccountsCount { get; set; }
}
