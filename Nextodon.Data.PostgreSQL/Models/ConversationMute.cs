using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class ConversationMute
{
    public long ConversationId { get; set; }

    public long AccountId { get; set; }

    public long Id { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Conversation Conversation { get; set; } = null!;
}
