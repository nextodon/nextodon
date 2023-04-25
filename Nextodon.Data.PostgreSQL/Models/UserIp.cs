using System;
using System.Collections.Generic;
using System.Net;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class UserIp
{
    public long? UserId { get; set; }

    public IPAddress? Ip { get; set; }

    public DateTime? UsedAt { get; set; }
}
