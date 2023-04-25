using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class Account
{
    public long Id { get; set; }

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

    public int? AvatarFileSize { get; set; }

    public DateTime? AvatarUpdatedAt { get; set; }

    public string? HeaderFileName { get; set; }

    public string? HeaderContentType { get; set; }

    public int? HeaderFileSize { get; set; }

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

    public int? SuspensionOrigin { get; set; }

    public DateTime? SensitizedAt { get; set; }

    public bool? Trendable { get; set; }

    public DateTime? ReviewedAt { get; set; }

    public DateTime? RequestedReviewAt { get; set; }

    public virtual ICollection<AccountAlias> AccountAliases { get; set; } = new List<AccountAlias>();

    public virtual ICollection<AccountConversation> AccountConversations { get; set; } = new List<AccountConversation>();

    public virtual ICollection<AccountDeletionRequest> AccountDeletionRequests { get; set; } = new List<AccountDeletionRequest>();

    public virtual ICollection<AccountDomainBlock> AccountDomainBlocks { get; set; } = new List<AccountDomainBlock>();

    public virtual ICollection<AccountMigration> AccountMigrationAccounts { get; set; } = new List<AccountMigration>();

    public virtual ICollection<AccountMigration> AccountMigrationTargetAccounts { get; set; } = new List<AccountMigration>();

    public virtual ICollection<AccountModerationNote> AccountModerationNoteAccounts { get; set; } = new List<AccountModerationNote>();

    public virtual ICollection<AccountModerationNote> AccountModerationNoteTargetAccounts { get; set; } = new List<AccountModerationNote>();

    public virtual ICollection<AccountNote> AccountNoteAccounts { get; set; } = new List<AccountNote>();

    public virtual ICollection<AccountNote> AccountNoteTargetAccounts { get; set; } = new List<AccountNote>();

    public virtual ICollection<AccountPin> AccountPinAccounts { get; set; } = new List<AccountPin>();

    public virtual ICollection<AccountPin> AccountPinTargetAccounts { get; set; } = new List<AccountPin>();

    public virtual AccountStat? AccountStat { get; set; }

    public virtual ICollection<AccountStatusesCleanupPolicy> AccountStatusesCleanupPolicies { get; set; } = new List<AccountStatusesCleanupPolicy>();

    public virtual ICollection<AccountWarning> AccountWarningAccounts { get; set; } = new List<AccountWarning>();

    public virtual ICollection<AccountWarning> AccountWarningTargetAccounts { get; set; } = new List<AccountWarning>();

    public virtual ICollection<AdminActionLog> AdminActionLogs { get; set; } = new List<AdminActionLog>();

    public virtual ICollection<AnnouncementMute> AnnouncementMutes { get; set; } = new List<AnnouncementMute>();

    public virtual ICollection<AnnouncementReaction> AnnouncementReactions { get; set; } = new List<AnnouncementReaction>();

    public virtual ICollection<Appeal> AppealAccounts { get; set; } = new List<Appeal>();

    public virtual ICollection<Appeal> AppealApprovedByAccounts { get; set; } = new List<Appeal>();

    public virtual ICollection<Appeal> AppealRejectedByAccounts { get; set; } = new List<Appeal>();

    public virtual ICollection<Block> BlockAccounts { get; set; } = new List<Block>();

    public virtual ICollection<Block> BlockTargetAccounts { get; set; } = new List<Block>();

    public virtual ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();

    public virtual ICollection<CanonicalEmailBlock> CanonicalEmailBlocks { get; set; } = new List<CanonicalEmailBlock>();

    public virtual ICollection<ConversationMute> ConversationMutes { get; set; } = new List<ConversationMute>();

    public virtual ICollection<CustomFilter> CustomFilters { get; set; } = new List<CustomFilter>();

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    public virtual ICollection<EncryptedMessage> EncryptedMessages { get; set; } = new List<EncryptedMessage>();

    public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();

    public virtual ICollection<FeaturedTag> FeaturedTags { get; set; } = new List<FeaturedTag>();

    public virtual ICollection<Follow> FollowAccounts { get; set; } = new List<Follow>();

    public virtual FollowRecommendationSuppression? FollowRecommendationSuppression { get; set; }

    public virtual ICollection<FollowRequest> FollowRequestAccounts { get; set; } = new List<FollowRequest>();

    public virtual ICollection<FollowRequest> FollowRequestTargetAccounts { get; set; } = new List<FollowRequest>();

    public virtual ICollection<Follow> FollowTargetAccounts { get; set; } = new List<Follow>();

    public virtual ICollection<Import> Imports { get; set; } = new List<Import>();

    public virtual ICollection<Account> InverseMovedToAccount { get; set; } = new List<Account>();

    public virtual ICollection<ListAccount> ListAccounts { get; set; } = new List<ListAccount>();

    public virtual ICollection<List> Lists { get; set; } = new List<List>();

    public virtual ICollection<MediaAttachment> MediaAttachments { get; set; } = new List<MediaAttachment>();

    public virtual ICollection<Mention> Mentions { get; set; } = new List<Mention>();

    public virtual Account? MovedToAccount { get; set; }

    public virtual ICollection<Mute> MuteAccounts { get; set; } = new List<Mute>();

    public virtual ICollection<Mute> MuteTargetAccounts { get; set; } = new List<Mute>();

    public virtual ICollection<Notification> NotificationAccounts { get; set; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationFromAccounts { get; set; } = new List<Notification>();

    public virtual ICollection<PollVote> PollVotes { get; set; } = new List<PollVote>();

    public virtual ICollection<Poll> Polls { get; set; } = new List<Poll>();

    public virtual ICollection<Report> ReportAccounts { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportActionTakenByAccounts { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportAssignedAccounts { get; set; } = new List<Report>();

    public virtual ICollection<ReportNote> ReportNotes { get; set; } = new List<ReportNote>();

    public virtual ICollection<Report> ReportTargetAccounts { get; set; } = new List<Report>();

    public virtual ICollection<ScheduledStatus> ScheduledStatuses { get; set; } = new List<ScheduledStatus>();

    public virtual ICollection<Status> StatusAccounts { get; set; } = new List<Status>();

    public virtual ICollection<StatusEdit> StatusEdits { get; set; } = new List<StatusEdit>();

    public virtual ICollection<Status> StatusInReplyToAccounts { get; set; } = new List<Status>();

    public virtual ICollection<StatusPin> StatusPins { get; set; } = new List<StatusPin>();

    public virtual ICollection<StatusTrend> StatusTrends { get; set; } = new List<StatusTrend>();

    public virtual ICollection<TagFollow> TagFollows { get; set; } = new List<TagFollow>();

    public virtual ICollection<Tombstone> Tombstones { get; set; } = new List<Tombstone>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
