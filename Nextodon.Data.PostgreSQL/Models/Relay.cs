using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class Relay
{
    public long Id { get; set; }

    public string InboxUrl { get; set; } = null!;

    public string? FollowActivityId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int State { get; set; }
}
