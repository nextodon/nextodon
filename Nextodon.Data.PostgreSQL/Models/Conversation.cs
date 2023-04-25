using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class Conversation
{
    public long Id { get; set; }

    public string? Uri { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AccountConversation> AccountConversations { get; set; } = new List<AccountConversation>();

    public virtual ICollection<ConversationMute> ConversationMutes { get; set; } = new List<ConversationMute>();
}
