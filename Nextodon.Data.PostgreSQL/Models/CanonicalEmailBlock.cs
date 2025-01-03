﻿using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class CanonicalEmailBlock
{
    public long Id { get; set; }

    public string CanonicalEmailHash { get; set; } = null!;

    public long? ReferenceAccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Account? ReferenceAccount { get; set; }
}
