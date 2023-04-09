using System;
using System.Collections.Generic;
using System.Net;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class LoginActivity
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string? AuthenticationMethod { get; set; }

    public string? Provider { get; set; }

    public bool? Success { get; set; }

    public string? FailureReason { get; set; }

    public string? Ip { get; set; }

    public string? UserAgent { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
