using System;
using System.Collections.Generic;
using System.Net;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class IpBlock
{
    public long Id { get; set; }

    public IPAddress Ip { get; set; } = null!;

    public int Severity { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
