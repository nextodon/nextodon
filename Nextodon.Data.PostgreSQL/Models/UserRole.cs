using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class UserRole
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int Position { get; set; }

    public long Permissions { get; set; }

    public bool Highlighted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
