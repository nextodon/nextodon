using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class EmailDomainBlock
{
    public long Id { get; set; }

    public string Domain { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? ParentId { get; set; }

    public virtual ICollection<EmailDomainBlock> InverseParent { get; } = new List<EmailDomainBlock>();

    public virtual EmailDomainBlock? Parent { get; set; }
}
