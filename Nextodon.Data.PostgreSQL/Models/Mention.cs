using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class Mention
{
    public long? StatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? AccountId { get; set; }

    public long Id { get; set; }

    public bool Silent { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Status? Status { get; set; }
}
