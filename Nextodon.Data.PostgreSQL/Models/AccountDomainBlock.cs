using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class AccountDomainBlock
{
    public string? Domain { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? AccountId { get; set; }

    public long Id { get; set; }

    public virtual Account? Account { get; set; }
}
