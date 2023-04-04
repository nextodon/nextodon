using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class List
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int RepliesPolicy { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<ListAccount> ListAccounts { get; } = new List<ListAccount>();
}
