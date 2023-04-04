using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class AccountDeletionRequest
{
    public long Id { get; set; }

    public long? AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Account? Account { get; set; }
}
