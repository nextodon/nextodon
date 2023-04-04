using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string? Domain { get; set; }

    public string? PrivateKey { get; set; }

    public string PublicKey { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Note { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string Uri { get; set; } = null!;

    public string? Url { get; set; }

    public string? AvatarFileName { get; set; }

    public string? AvatarContentType { get; set; }

    public long? AvatarFileSize { get; set; }

    public DateTime? AvatarUpdatedAt { get; set; }

    public string? HeaderFileName { get; set; }

    public string? HeaderContentType { get; set; }

    public long? HeaderFileSize { get; set; }

    public DateTime? HeaderUpdatedAt { get; set; }

    public string? AvatarRemoteUrl { get; set; }

    public bool Locked { get; set; }

    public string HeaderRemoteUrl { get; set; } = null!;

    public DateTime? LastWebfingeredAt { get; set; }

    public string InboxUrl { get; set; } = null!;

    public string OutboxUrl { get; set; } = null!;

    public string SharedInboxUrl { get; set; } = null!;

    public string FollowersUrl { get; set; } = null!;

    public int Protocol { get; set; }

    public long Id { get; set; }

    public bool Memorial { get; set; }

    public long? MovedToAccountId { get; set; }

    public string? FeaturedCollectionUrl { get; set; }

    public string? Fields { get; set; }

    public string? ActorType { get; set; }

    public bool? Discoverable { get; set; }

    public string[]? AlsoKnownAs { get; set; }

    public DateTime? SilencedAt { get; set; }

    public DateTime? SuspendedAt { get; set; }

    public bool? HideCollections { get; set; }

    public int? AvatarStorageSchemaVersion { get; set; }

    public int? HeaderStorageSchemaVersion { get; set; }

    public string? DevicesUrl { get; set; }

    public DateTime? SensitizedAt { get; set; }

    public int? SuspensionOrigin { get; set; }

    public bool? Trendable { get; set; }

    public DateTime? ReviewedAt { get; set; }

    public DateTime? RequestedReviewAt { get; set; }

    public virtual ICollection<AccountAlias> AccountAliases { get; } = new List<AccountAlias>();

    public virtual ICollection<AccountConversation> AccountConversations { get; } = new List<AccountConversation>();

    public virtual ICollection<AccountDeletionRequest> AccountDeletionRequests { get; } = new List<AccountDeletionRequest>();

    public virtual ICollection<AccountDomainBlock> AccountDomainBlocks { get; } = new List<AccountDomainBlock>();

    public virtual ICollection<AccountMigration> AccountMigrationAccounts { get; } = new List<AccountMigration>();

    public virtual ICollection<AccountMigration> AccountMigrationTargetAccounts { get; } = new List<AccountMigration>();

    public virtual ICollection<AccountModerationNote> AccountModerationNoteAccounts { get; } = new List<AccountModerationNote>();

    public virtual ICollection<AccountModerationNote> AccountModerationNoteTargetAccounts { get; } = new List<AccountModerationNote>();

    public virtual ICollection<AccountNote> AccountNoteAccounts { get; } = new List<AccountNote>();

    public virtual ICollection<AccountNote> AccountNoteTargetAccounts { get; } = new List<AccountNote>();

    public virtual ICollection<AccountPin> AccountPinAccounts { get; } = new List<AccountPin>();

    public virtual ICollection<AccountPin> AccountPinTargetAccounts { get; } = new List<AccountPin>();

    public virtual AccountStat? AccountStat { get; set; }

    public virtual ICollection<AccountStatusesCleanupPolicy> AccountStatusesCleanupPolicies { get; } = new List<AccountStatusesCleanupPolicy>();

    public virtual ICollection<AccountWarning> AccountWarningAccounts { get; } = new List<AccountWarning>();

    public virtual ICollection<AccountWarning> AccountWarningTargetAccounts { get; } = new List<AccountWarning>();

    public virtual ICollection<AdminActionLog> AdminActionLogs { get; } = new List<AdminActionLog>();

    public virtual ICollection<AnnouncementMute> AnnouncementMutes { get; } = new List<AnnouncementMute>();

    public virtual ICollection<AnnouncementReaction> AnnouncementReactions { get; } = new List<AnnouncementReaction>();

    public virtual ICollection<Appeal> AppealAccounts { get; } = new List<Appeal>();

    public virtual ICollection<Appeal> AppealApprovedByAccounts { get; } = new List<Appeal>();

    public virtual ICollection<Appeal> AppealRejectedByAccounts { get; } = new List<Appeal>();

    public virtual ICollection<Block> BlockAccounts { get; } = new List<Block>();

    public virtual ICollection<Block> BlockTargetAccounts { get; } = new List<Block>();

    public virtual ICollection<Bookmark> Bookmarks { get; } = new List<Bookmark>();

    public virtual ICollection<CanonicalEmailBlock> CanonicalEmailBlocks { get; } = new List<CanonicalEmailBlock>();

    public virtual ICollection<ConversationMute> ConversationMutes { get; } = new List<ConversationMute>();

    public virtual ICollection<CustomFilter> CustomFilters { get; } = new List<CustomFilter>();

    public virtual ICollection<Device> Devices { get; } = new List<Device>();

    public virtual ICollection<EncryptedMessage> EncryptedMessages { get; } = new List<EncryptedMessage>();

    public virtual ICollection<Favourite> Favourites { get; } = new List<Favourite>();

    public virtual ICollection<FeaturedTag> FeaturedTags { get; } = new List<FeaturedTag>();

    public virtual ICollection<Follow> FollowAccounts { get; } = new List<Follow>();

    public virtual FollowRecommendationSuppression? FollowRecommendationSuppression { get; set; }

    public virtual ICollection<FollowRequest> FollowRequestAccounts { get; } = new List<FollowRequest>();

    public virtual ICollection<FollowRequest> FollowRequestTargetAccounts { get; } = new List<FollowRequest>();

    public virtual ICollection<Follow> FollowTargetAccounts { get; } = new List<Follow>();

    public virtual ICollection<Import> Imports { get; } = new List<Import>();

    public virtual ICollection<Account> InverseMovedToAccount { get; } = new List<Account>();

    public virtual ICollection<ListAccount> ListAccounts { get; } = new List<ListAccount>();

    public virtual ICollection<List> Lists { get; } = new List<List>();

    public virtual ICollection<MediaAttachment> MediaAttachments { get; } = new List<MediaAttachment>();

    public virtual ICollection<Mention> Mentions { get; } = new List<Mention>();

    public virtual Account? MovedToAccount { get; set; }

    public virtual ICollection<Mute> MuteAccounts { get; } = new List<Mute>();

    public virtual ICollection<Mute> MuteTargetAccounts { get; } = new List<Mute>();

    public virtual ICollection<Notification> NotificationAccounts { get; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationFromAccounts { get; } = new List<Notification>();

    public virtual ICollection<PollVote> PollVotes { get; } = new List<PollVote>();

    public virtual ICollection<Poll> Polls { get; } = new List<Poll>();

    public virtual ICollection<Report> ReportAccounts { get; } = new List<Report>();

    public virtual ICollection<Report> ReportActionTakenByAccounts { get; } = new List<Report>();

    public virtual ICollection<Report> ReportAssignedAccounts { get; } = new List<Report>();

    public virtual ICollection<ReportNote> ReportNotes { get; } = new List<ReportNote>();

    public virtual ICollection<Report> ReportTargetAccounts { get; } = new List<Report>();

    public virtual ICollection<ScheduledStatus> ScheduledStatuses { get; } = new List<ScheduledStatus>();

    public virtual ICollection<Status> StatusAccounts { get; } = new List<Status>();

    public virtual ICollection<StatusEdit> StatusEdits { get; } = new List<StatusEdit>();

    public virtual ICollection<Status> StatusInReplyToAccounts { get; } = new List<Status>();

    public virtual ICollection<StatusPin> StatusPins { get; } = new List<StatusPin>();

    public virtual ICollection<StatusTrend> StatusTrends { get; } = new List<StatusTrend>();

    public virtual ICollection<TagFollow> TagFollows { get; } = new List<TagFollow>();

    public virtual ICollection<Tombstone> Tombstones { get; } = new List<Tombstone>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
