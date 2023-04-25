using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class Status
{
    public long Id { get; set; }

    public string? Uri { get; set; }

    public string Text { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? InReplyToId { get; set; }

    public long? ReblogOfId { get; set; }

    public string? Url { get; set; }

    public bool Sensitive { get; set; }

    public int Visibility { get; set; }

    public string SpoilerText { get; set; } = null!;

    public bool Reply { get; set; }

    public string? Language { get; set; }

    public long? ConversationId { get; set; }

    public bool? Local { get; set; }

    public long AccountId { get; set; }

    public long? ApplicationId { get; set; }

    public long? InReplyToAccountId { get; set; }

    public long? PollId { get; set; }

    public DateTime? DeletedAt { get; set; }

    public DateTime? EditedAt { get; set; }

    public bool? Trendable { get; set; }

    public long[]? OrderedMediaAttachmentIds { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual ICollection<CustomFilterStatus> CustomFilterStatuses { get; set; } = new List<CustomFilterStatus>();

    public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();

    public virtual Status? InReplyTo { get; set; }

    public virtual Account? InReplyToAccount { get; set; }

    public virtual ICollection<Status> InverseInReplyTo { get; set; } = new List<Status>();

    public virtual ICollection<Status> InverseReblogOf { get; set; } = new List<Status>();

    public virtual ICollection<MediaAttachment> MediaAttachments { get; set; } = new List<MediaAttachment>();

    public virtual ICollection<Mention> Mentions { get; set; } = new List<Mention>();

    public virtual ICollection<Poll> Polls { get; set; } = new List<Poll>();

    public virtual Status? ReblogOf { get; set; }

    public virtual ICollection<StatusEdit> StatusEdits { get; set; } = new List<StatusEdit>();

    public virtual ICollection<StatusPin> StatusPins { get; set; } = new List<StatusPin>();

    public virtual StatusStat? StatusStat { get; set; }

    public virtual StatusTrend? StatusTrend { get; set; }
}
