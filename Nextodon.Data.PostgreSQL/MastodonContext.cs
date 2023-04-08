using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Nextodon.Data.PostgreSQL.Models;

namespace Nextodon.Data.PostgreSQL;

public partial class MastodonContext : DbContext
{
    public MastodonContext()
    {
    }

    public MastodonContext(DbContextOptions<MastodonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountAlias> AccountAliases { get; set; }

    public virtual DbSet<AccountConversation> AccountConversations { get; set; }

    public virtual DbSet<AccountDeletionRequest> AccountDeletionRequests { get; set; }

    public virtual DbSet<AccountDomainBlock> AccountDomainBlocks { get; set; }

    public virtual DbSet<AccountMigration> AccountMigrations { get; set; }

    public virtual DbSet<AccountModerationNote> AccountModerationNotes { get; set; }

    public virtual DbSet<AccountNote> AccountNotes { get; set; }

    public virtual DbSet<AccountPin> AccountPins { get; set; }

    public virtual DbSet<AccountStat> AccountStats { get; set; }

    public virtual DbSet<AccountStatusesCleanupPolicy> AccountStatusesCleanupPolicies { get; set; }

    public virtual DbSet<AccountSummary> AccountSummaries { get; set; }

    public virtual DbSet<AccountWarning> AccountWarnings { get; set; }

    public virtual DbSet<AccountWarningPreset> AccountWarningPresets { get; set; }

    public virtual DbSet<AccountsTag> AccountsTags { get; set; }

    public virtual DbSet<AdminActionLog> AdminActionLogs { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<AnnouncementMute> AnnouncementMutes { get; set; }

    public virtual DbSet<AnnouncementReaction> AnnouncementReactions { get; set; }

    public virtual DbSet<Appeal> Appeals { get; set; }

    public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; }

    public virtual DbSet<Backup> Backups { get; set; }

    public virtual DbSet<Block> Blocks { get; set; }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    public virtual DbSet<CanonicalEmailBlock> CanonicalEmailBlocks { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<ConversationMute> ConversationMutes { get; set; }

    public virtual DbSet<CustomEmoji> CustomEmojis { get; set; }

    public virtual DbSet<CustomEmojiCategory> CustomEmojiCategories { get; set; }

    public virtual DbSet<CustomFilter> CustomFilters { get; set; }

    public virtual DbSet<CustomFilterKeyword> CustomFilterKeywords { get; set; }

    public virtual DbSet<CustomFilterStatus> CustomFilterStatuses { get; set; }

    public virtual DbSet<DeprecatedPreviewCard> DeprecatedPreviewCards { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<DomainAllow> DomainAllows { get; set; }

    public virtual DbSet<DomainBlock> DomainBlocks { get; set; }

    public virtual DbSet<EmailDomainBlock> EmailDomainBlocks { get; set; }

    public virtual DbSet<EncryptedMessage> EncryptedMessages { get; set; }

    public virtual DbSet<Favourite> Favourites { get; set; }

    public virtual DbSet<FeaturedTag> FeaturedTags { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<FollowRecommendation> FollowRecommendations { get; set; }

    public virtual DbSet<FollowRecommendationSuppression> FollowRecommendationSuppressions { get; set; }

    public virtual DbSet<FollowRequest> FollowRequests { get; set; }

    public virtual DbSet<Identity> Identities { get; set; }

    public virtual DbSet<Import> Imports { get; set; }

    public virtual DbSet<Instance> Instances { get; set; }

    public virtual DbSet<Invite> Invites { get; set; }

    public virtual DbSet<IpBlock> IpBlocks { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<ListAccount> ListAccounts { get; set; }

    public virtual DbSet<LoginActivity> LoginActivities { get; set; }

    public virtual DbSet<Marker> Markers { get; set; }

    public virtual DbSet<MediaAttachment> MediaAttachments { get; set; }

    public virtual DbSet<Mention> Mentions { get; set; }

    public virtual DbSet<Mute> Mutes { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<OauthAccessGrant> OauthAccessGrants { get; set; }

    public virtual DbSet<OauthAccessToken> OauthAccessTokens { get; set; }

    public virtual DbSet<OauthApplication> OauthApplications { get; set; }

    public virtual DbSet<OneTimeKey> OneTimeKeys { get; set; }

    public virtual DbSet<PgheroSpaceStat> PgheroSpaceStats { get; set; }

    public virtual DbSet<Poll> Polls { get; set; }

    public virtual DbSet<PollVote> PollVotes { get; set; }

    public virtual DbSet<PreviewCard> PreviewCards { get; set; }

    public virtual DbSet<PreviewCardProvider> PreviewCardProviders { get; set; }

    public virtual DbSet<PreviewCardTrend> PreviewCardTrends { get; set; }

    public virtual DbSet<PreviewCardsStatus> PreviewCardsStatuses { get; set; }

    public virtual DbSet<Relay> Relays { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportNote> ReportNotes { get; set; }

    public virtual DbSet<Rule> Rules { get; set; }

    public virtual DbSet<ScheduledStatus> ScheduledStatuses { get; set; }

    public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }

    public virtual DbSet<SessionActivation> SessionActivations { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<SiteUpload> SiteUploads { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusEdit> StatusEdits { get; set; }

    public virtual DbSet<StatusPin> StatusPins { get; set; }

    public virtual DbSet<StatusStat> StatusStats { get; set; }

    public virtual DbSet<StatusTrend> StatusTrends { get; set; }

    public virtual DbSet<StatusesTag> StatusesTags { get; set; }

    public virtual DbSet<SystemKey> SystemKeys { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TagFollow> TagFollows { get; set; }

    public virtual DbSet<Tombstone> Tombstones { get; set; }

    public virtual DbSet<UnavailableDomain> UnavailableDomains { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserInviteRequest> UserInviteRequests { get; set; }

    public virtual DbSet<UserIp> UserIps { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<WebPushSubscription> WebPushSubscriptions { get; set; }

    public virtual DbSet<WebSetting> WebSettings { get; set; }

    public virtual DbSet<WebauthnCredential> WebauthnCredentials { get; set; }

    public virtual DbSet<Webhook> Webhooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=mastodon;Username=mastodon;Password=1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_accounts_on_id");

            entity.ToTable("accounts");

            entity.HasIndex(e => e.MovedToAccountId, "index_accounts_on_moved_to_account_id").HasFilter("(moved_to_account_id IS NOT NULL)");

            entity.HasIndex(e => e.Uri, "index_accounts_on_uri");

            entity.HasIndex(e => e.Url, "index_accounts_on_url")
                .HasFilter("(url IS NOT NULL)")
                .HasOperators(new[] { "text_pattern_ops" });

            entity.Property(e => e.Id)
                .HasDefaultValueSql("timestamp_id('accounts'::text)")
                .HasColumnName("id");
            entity.Property(e => e.ActorType)
                .HasColumnType("character varying")
                .HasColumnName("actor_type");
            entity.Property(e => e.AlsoKnownAs)
                .HasColumnType("character varying[]")
                .HasColumnName("also_known_as");
            entity.Property(e => e.AvatarContentType)
                .HasColumnType("character varying")
                .HasColumnName("avatar_content_type");
            entity.Property(e => e.AvatarFileName)
                .HasColumnType("character varying")
                .HasColumnName("avatar_file_name");
            entity.Property(e => e.AvatarFileSize).HasColumnName("avatar_file_size");
            entity.Property(e => e.AvatarRemoteUrl)
                .HasColumnType("character varying")
                .HasColumnName("avatar_remote_url");
            entity.Property(e => e.AvatarStorageSchemaVersion).HasColumnName("avatar_storage_schema_version");
            entity.Property(e => e.AvatarUpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("avatar_updated_at");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DevicesUrl)
                .HasColumnType("character varying")
                .HasColumnName("devices_url");
            entity.Property(e => e.Discoverable).HasColumnName("discoverable");
            entity.Property(e => e.DisplayName)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("display_name");
            entity.Property(e => e.Domain)
                .HasColumnType("character varying")
                .HasColumnName("domain");
            entity.Property(e => e.FeaturedCollectionUrl)
                .HasColumnType("character varying")
                .HasColumnName("featured_collection_url");
            entity.Property(e => e.Fields)
                .HasColumnType("jsonb")
                .HasColumnName("fields");
            entity.Property(e => e.FollowersUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("followers_url");
            entity.Property(e => e.HeaderContentType)
                .HasColumnType("character varying")
                .HasColumnName("header_content_type");
            entity.Property(e => e.HeaderFileName)
                .HasColumnType("character varying")
                .HasColumnName("header_file_name");
            entity.Property(e => e.HeaderFileSize).HasColumnName("header_file_size");
            entity.Property(e => e.HeaderRemoteUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("header_remote_url");
            entity.Property(e => e.HeaderStorageSchemaVersion).HasColumnName("header_storage_schema_version");
            entity.Property(e => e.HeaderUpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("header_updated_at");
            entity.Property(e => e.HideCollections).HasColumnName("hide_collections");
            entity.Property(e => e.InboxUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("inbox_url");
            entity.Property(e => e.LastWebfingeredAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_webfingered_at");
            entity.Property(e => e.Locked).HasColumnName("locked");
            entity.Property(e => e.Memorial).HasColumnName("memorial");
            entity.Property(e => e.MovedToAccountId).HasColumnName("moved_to_account_id");
            entity.Property(e => e.Note)
                .HasDefaultValueSql("''::text")
                .HasColumnName("note");
            entity.Property(e => e.OutboxUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("outbox_url");
            entity.Property(e => e.PrivateKey).HasColumnName("private_key");
            entity.Property(e => e.Protocol).HasColumnName("protocol");
            entity.Property(e => e.PublicKey)
                .HasDefaultValueSql("''::text")
                .HasColumnName("public_key");
            entity.Property(e => e.RequestedReviewAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("requested_review_at");
            entity.Property(e => e.ReviewedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reviewed_at");
            entity.Property(e => e.SensitizedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sensitized_at");
            entity.Property(e => e.SharedInboxUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("shared_inbox_url");
            entity.Property(e => e.SilencedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("silenced_at");
            entity.Property(e => e.SuspendedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("suspended_at");
            entity.Property(e => e.SuspensionOrigin).HasColumnName("suspension_origin");
            entity.Property(e => e.Trendable).HasColumnName("trendable");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uri)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("uri");
            entity.Property(e => e.Url)
                .HasColumnType("character varying")
                .HasColumnName("url");
            entity.Property(e => e.Username)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("username");

            entity.HasOne(d => d.MovedToAccount).WithMany(p => p.InverseMovedToAccount)
                .HasForeignKey(d => d.MovedToAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_2320833084");
        });

        modelBuilder.Entity<AccountAlias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_aliases_pkey");

            entity.ToTable("account_aliases");

            entity.HasIndex(e => e.AccountId, "index_account_aliases_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Acct)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("acct");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uri)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("uri");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountAliases)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_fc91575d08");
        });

        modelBuilder.Entity<AccountConversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_conversations_pkey");

            entity.ToTable("account_conversations");

            entity.HasIndex(e => e.ConversationId, "index_account_conversations_on_conversation_id");

            entity.HasIndex(e => new { e.AccountId, e.ConversationId, e.ParticipantAccountIds }, "index_unique_conversations").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");
            entity.Property(e => e.LastStatusId).HasColumnName("last_status_id");
            entity.Property(e => e.LockVersion).HasColumnName("lock_version");
            entity.Property(e => e.ParticipantAccountIds)
                .HasDefaultValueSql("'{}'::bigint[]")
                .HasColumnName("participant_account_ids");
            entity.Property(e => e.StatusIds)
                .HasDefaultValueSql("'{}'::bigint[]")
                .HasColumnName("status_ids");
            entity.Property(e => e.Unread).HasColumnName("unread");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountConversations)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_6f5278b6e9");

            entity.HasOne(d => d.Conversation).WithMany(p => p.AccountConversations)
                .HasForeignKey(d => d.ConversationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_1491654f9f");
        });

        modelBuilder.Entity<AccountDeletionRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_deletion_requests_pkey");

            entity.ToTable("account_deletion_requests");

            entity.HasIndex(e => e.AccountId, "index_account_deletion_requests_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountDeletionRequests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_45bf2626b9");
        });

        modelBuilder.Entity<AccountDomainBlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_account_domain_blocks_on_id");

            entity.ToTable("account_domain_blocks");

            entity.HasIndex(e => new { e.AccountId, e.Domain }, "index_account_domain_blocks_on_account_id_and_domain").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Domain)
                .HasColumnType("character varying")
                .HasColumnName("domain");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountDomainBlocks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_206c6029bd");
        });

        modelBuilder.Entity<AccountMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_migrations_pkey");

            entity.ToTable("account_migrations");

            entity.HasIndex(e => e.AccountId, "index_account_migrations_on_account_id");

            entity.HasIndex(e => e.TargetAccountId, "index_account_migrations_on_target_account_id").HasFilter("(target_account_id IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Acct)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("acct");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FollowersCount).HasColumnName("followers_count");
            entity.Property(e => e.TargetAccountId).HasColumnName("target_account_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountMigrationAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_c9f701caaf");

            entity.HasOne(d => d.TargetAccount).WithMany(p => p.AccountMigrationTargetAccounts)
                .HasForeignKey(d => d.TargetAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_d9a8dad070");
        });

        modelBuilder.Entity<AccountModerationNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_moderation_notes_pkey");

            entity.ToTable("account_moderation_notes");

            entity.HasIndex(e => e.AccountId, "index_account_moderation_notes_on_account_id");

            entity.HasIndex(e => e.TargetAccountId, "index_account_moderation_notes_on_target_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.TargetAccountId).HasColumnName("target_account_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountModerationNoteAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rails_3f8b75089b");

            entity.HasOne(d => d.TargetAccount).WithMany(p => p.AccountModerationNoteTargetAccounts)
                .HasForeignKey(d => d.TargetAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rails_dd62ed5ac3");
        });

        modelBuilder.Entity<AccountNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_notes_pkey");

            entity.ToTable("account_notes");

            entity.HasIndex(e => new { e.AccountId, e.TargetAccountId }, "index_account_notes_on_account_id_and_target_account_id").IsUnique();

            entity.HasIndex(e => e.TargetAccountId, "index_account_notes_on_target_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.TargetAccountId).HasColumnName("target_account_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountNoteAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_4ee4503c69");

            entity.HasOne(d => d.TargetAccount).WithMany(p => p.AccountNoteTargetAccounts)
                .HasForeignKey(d => d.TargetAccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_2801b48f1a");
        });

        modelBuilder.Entity<AccountPin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_pins_pkey");

            entity.ToTable("account_pins");

            entity.HasIndex(e => new { e.AccountId, e.TargetAccountId }, "index_account_pins_on_account_id_and_target_account_id").IsUnique();

            entity.HasIndex(e => e.TargetAccountId, "index_account_pins_on_target_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.TargetAccountId).HasColumnName("target_account_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountPinAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_d44979e5dd");

            entity.HasOne(d => d.TargetAccount).WithMany(p => p.AccountPinTargetAccounts)
                .HasForeignKey(d => d.TargetAccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_a176e26c37");
        });

        modelBuilder.Entity<AccountStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_stats_pkey");

            entity.ToTable("account_stats");

            entity.HasIndex(e => e.AccountId, "index_account_stats_on_account_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FollowersCount).HasColumnName("followers_count");
            entity.Property(e => e.FollowingCount).HasColumnName("following_count");
            entity.Property(e => e.LastStatusAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_status_at");
            entity.Property(e => e.StatusesCount).HasColumnName("statuses_count");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithOne(p => p.AccountStat)
                .HasForeignKey<AccountStat>(d => d.AccountId)
                .HasConstraintName("fk_rails_215bb31ff1");
        });

        modelBuilder.Entity<AccountStatusesCleanupPolicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_statuses_cleanup_policies_pkey");

            entity.ToTable("account_statuses_cleanup_policies");

            entity.HasIndex(e => e.AccountId, "index_account_statuses_cleanup_policies_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Enabled)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("enabled");
            entity.Property(e => e.KeepDirect)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("keep_direct");
            entity.Property(e => e.KeepMedia).HasColumnName("keep_media");
            entity.Property(e => e.KeepPinned)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("keep_pinned");
            entity.Property(e => e.KeepPolls).HasColumnName("keep_polls");
            entity.Property(e => e.KeepSelfBookmark)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("keep_self_bookmark");
            entity.Property(e => e.KeepSelfFav)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("keep_self_fav");
            entity.Property(e => e.MinFavs).HasColumnName("min_favs");
            entity.Property(e => e.MinReblogs).HasColumnName("min_reblogs");
            entity.Property(e => e.MinStatusAge)
                .HasDefaultValueSql("1209600")
                .HasColumnName("min_status_age");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountStatusesCleanupPolicies)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_rails_23d5f73cfe");
        });

        modelBuilder.Entity<AccountSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("account_summaries");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Language)
                .HasColumnType("character varying")
                .HasColumnName("language");
            entity.Property(e => e.Sensitive).HasColumnName("sensitive");
        });

        modelBuilder.Entity<AccountWarning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_warnings_pkey");

            entity.ToTable("account_warnings");

            entity.HasIndex(e => e.AccountId, "index_account_warnings_on_account_id");

            entity.HasIndex(e => e.TargetAccountId, "index_account_warnings_on_target_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Action).HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.OverruledAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("overruled_at");
            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.StatusIds)
                .HasColumnType("character varying[]")
                .HasColumnName("status_ids");
            entity.Property(e => e.TargetAccountId).HasColumnName("target_account_id");
            entity.Property(e => e.Text)
                .HasDefaultValueSql("''::text")
                .HasColumnName("text");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountWarningAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_a65a1bf71b");

            entity.HasOne(d => d.Report).WithMany(p => p.AccountWarnings)
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_8f2bab4b16");

            entity.HasOne(d => d.TargetAccount).WithMany(p => p.AccountWarningTargetAccounts)
                .HasForeignKey(d => d.TargetAccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_a7ebbb1e37");
        });

        modelBuilder.Entity<AccountWarningPreset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_warning_presets_pkey");

            entity.ToTable("account_warning_presets");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Text)
                .HasDefaultValueSql("''::text")
                .HasColumnName("text");
            entity.Property(e => e.Title)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AccountsTag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("accounts_tags");

            entity.HasIndex(e => new { e.AccountId, e.TagId }, "index_accounts_tags_on_account_id_and_tag_id");

            entity.HasIndex(e => new { e.TagId, e.AccountId }, "index_accounts_tags_on_tag_id_and_account_id").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
        });

        modelBuilder.Entity<AdminActionLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_action_logs_pkey");

            entity.ToTable("admin_action_logs");

            entity.HasIndex(e => e.AccountId, "index_admin_action_logs_on_account_id");

            entity.HasIndex(e => new { e.TargetType, e.TargetId }, "index_admin_action_logs_on_target_type_and_target_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Action)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.HumanIdentifier)
                .HasColumnType("character varying")
                .HasColumnName("human_identifier");
            entity.Property(e => e.Permalink)
                .HasColumnType("character varying")
                .HasColumnName("permalink");
            entity.Property(e => e.RouteParam)
                .HasColumnType("character varying")
                .HasColumnName("route_param");
            entity.Property(e => e.TargetId).HasColumnName("target_id");
            entity.Property(e => e.TargetType)
                .HasColumnType("character varying")
                .HasColumnName("target_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AdminActionLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_a7667297fa");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("announcements_pkey");

            entity.ToTable("announcements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllDay).HasColumnName("all_day");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EndsAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ends_at");
            entity.Property(e => e.Published).HasColumnName("published");
            entity.Property(e => e.PublishedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published_at");
            entity.Property(e => e.ScheduledAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduled_at");
            entity.Property(e => e.StartsAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("starts_at");
            entity.Property(e => e.StatusIds).HasColumnName("status_ids");
            entity.Property(e => e.Text)
                .HasDefaultValueSql("''::text")
                .HasColumnName("text");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AnnouncementMute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("announcement_mutes_pkey");

            entity.ToTable("announcement_mutes");

            entity.HasIndex(e => new { e.AccountId, e.AnnouncementId }, "index_announcement_mutes_on_account_id_and_announcement_id").IsUnique();

            entity.HasIndex(e => e.AnnouncementId, "index_announcement_mutes_on_announcement_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AnnouncementId).HasColumnName("announcement_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AnnouncementMutes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_9c99f8e835");

            entity.HasOne(d => d.Announcement).WithMany(p => p.AnnouncementMutes)
                .HasForeignKey(d => d.AnnouncementId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_e35401adf1");
        });

        modelBuilder.Entity<AnnouncementReaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("announcement_reactions_pkey");

            entity.ToTable("announcement_reactions");

            entity.HasIndex(e => new { e.AccountId, e.AnnouncementId, e.Name }, "index_announcement_reactions_on_account_id_and_announcement_id").IsUnique();

            entity.HasIndex(e => e.AnnouncementId, "index_announcement_reactions_on_announcement_id");

            entity.HasIndex(e => e.CustomEmojiId, "index_announcement_reactions_on_custom_emoji_id").HasFilter("(custom_emoji_id IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AnnouncementId).HasColumnName("announcement_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomEmojiId).HasColumnName("custom_emoji_id");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AnnouncementReactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_7444ad831f");

            entity.HasOne(d => d.Announcement).WithMany(p => p.AnnouncementReactions)
                .HasForeignKey(d => d.AnnouncementId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_a1226eaa5c");

            entity.HasOne(d => d.CustomEmoji).WithMany(p => p.AnnouncementReactions)
                .HasForeignKey(d => d.CustomEmojiId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_b742c91c0e");
        });

        modelBuilder.Entity<Appeal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("appeals_pkey");

            entity.ToTable("appeals");

            entity.HasIndex(e => e.AccountId, "index_appeals_on_account_id");

            entity.HasIndex(e => e.AccountWarningId, "index_appeals_on_account_warning_id").IsUnique();

            entity.HasIndex(e => e.ApprovedByAccountId, "index_appeals_on_approved_by_account_id").HasFilter("(approved_by_account_id IS NOT NULL)");

            entity.HasIndex(e => e.RejectedByAccountId, "index_appeals_on_rejected_by_account_id").HasFilter("(rejected_by_account_id IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AccountWarningId).HasColumnName("account_warning_id");
            entity.Property(e => e.ApprovedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("approved_at");
            entity.Property(e => e.ApprovedByAccountId).HasColumnName("approved_by_account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.RejectedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("rejected_at");
            entity.Property(e => e.RejectedByAccountId).HasColumnName("rejected_by_account_id");
            entity.Property(e => e.Text)
                .HasDefaultValueSql("''::text")
                .HasColumnName("text");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.AppealAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_rails_ea84881569");

            entity.HasOne(d => d.AccountWarning).WithOne(p => p.Appeal)
                .HasForeignKey<Appeal>(d => d.AccountWarningId)
                .HasConstraintName("fk_rails_a99f14546e");

            entity.HasOne(d => d.ApprovedByAccount).WithMany(p => p.AppealApprovedByAccounts)
                .HasForeignKey(d => d.ApprovedByAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_9deb2f63ad");

            entity.HasOne(d => d.RejectedByAccount).WithMany(p => p.AppealRejectedByAccounts)
                .HasForeignKey(d => d.RejectedByAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_501c3a6e13");
        });

        modelBuilder.Entity<ArInternalMetadatum>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("ar_internal_metadata_pkey");

            entity.ToTable("ar_internal_metadata");

            entity.Property(e => e.Key)
                .HasColumnType("character varying")
                .HasColumnName("key");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasColumnType("character varying")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Backup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("backups_pkey");

            entity.ToTable("backups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DumpContentType)
                .HasColumnType("character varying")
                .HasColumnName("dump_content_type");
            entity.Property(e => e.DumpFileName)
                .HasColumnType("character varying")
                .HasColumnName("dump_file_name");
            entity.Property(e => e.DumpFileSize).HasColumnName("dump_file_size");
            entity.Property(e => e.DumpUpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dump_updated_at");
            entity.Property(e => e.Processed).HasColumnName("processed");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Backups)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_096669d221");
        });

        modelBuilder.Entity<Block>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_blocks_on_id");

            entity.ToTable("blocks");

            entity.HasIndex(e => new { e.AccountId, e.TargetAccountId }, "index_blocks_on_account_id_and_target_account_id").IsUnique();

            entity.HasIndex(e => e.TargetAccountId, "index_blocks_on_target_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.TargetAccountId).HasColumnName("target_account_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uri)
                .HasColumnType("character varying")
                .HasColumnName("uri");

            entity.HasOne(d => d.Account).WithMany(p => p.BlockAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_4269e03e65");

            entity.HasOne(d => d.TargetAccount).WithMany(p => p.BlockTargetAccounts)
                .HasForeignKey(d => d.TargetAccountId)
                .HasConstraintName("fk_9571bfabc1");
        });

        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bookmarks_pkey");

            entity.ToTable("bookmarks");

            entity.HasIndex(e => new { e.AccountId, e.StatusId }, "index_bookmarks_on_account_id_and_status_id").IsUnique();

            entity.HasIndex(e => e.StatusId, "index_bookmarks_on_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_rails_9f6ac182a6");

            entity.HasOne(d => d.Status).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_rails_11207ffcfd");
        });

        modelBuilder.Entity<CanonicalEmailBlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("canonical_email_blocks_pkey");

            entity.ToTable("canonical_email_blocks");

            entity.HasIndex(e => e.CanonicalEmailHash, "index_canonical_email_blocks_on_canonical_email_hash").IsUnique();

            entity.HasIndex(e => e.ReferenceAccountId, "index_canonical_email_blocks_on_reference_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CanonicalEmailHash)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("canonical_email_hash");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ReferenceAccountId).HasColumnName("reference_account_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.ReferenceAccount).WithMany(p => p.CanonicalEmailBlocks)
                .HasForeignKey(d => d.ReferenceAccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_1ecb262096");
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("conversations_pkey");

            entity.ToTable("conversations");

            entity.HasIndex(e => e.Uri, "index_conversations_on_uri")
                .IsUnique()
                .HasFilter("(uri IS NOT NULL)")
                .HasOperators(new[] { "text_pattern_ops" });

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uri)
                .HasColumnType("character varying")
                .HasColumnName("uri");
        });

        modelBuilder.Entity<ConversationMute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_conversation_mutes_on_id");

            entity.ToTable("conversation_mutes");

            entity.HasIndex(e => new { e.AccountId, e.ConversationId }, "index_conversation_mutes_on_account_id_and_conversation_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");

            entity.HasOne(d => d.Account).WithMany(p => p.ConversationMutes)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_225b4212bb");

            entity.HasOne(d => d.Conversation).WithMany(p => p.ConversationMutes)
                .HasForeignKey(d => d.ConversationId)
                .HasConstraintName("fk_rails_5ab139311f");
        });

        modelBuilder.Entity<CustomEmoji>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("custom_emojis_pkey");

            entity.ToTable("custom_emojis");

            entity.HasIndex(e => new { e.Shortcode, e.Domain }, "index_custom_emojis_on_shortcode_and_domain").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Disabled).HasColumnName("disabled");
            entity.Property(e => e.Domain)
                .HasColumnType("character varying")
                .HasColumnName("domain");
            entity.Property(e => e.ImageContentType)
                .HasColumnType("character varying")
                .HasColumnName("image_content_type");
            entity.Property(e => e.ImageFileName)
                .HasColumnType("character varying")
                .HasColumnName("image_file_name");
            entity.Property(e => e.ImageFileSize).HasColumnName("image_file_size");
            entity.Property(e => e.ImageRemoteUrl)
                .HasColumnType("character varying")
                .HasColumnName("image_remote_url");
            entity.Property(e => e.ImageStorageSchemaVersion).HasColumnName("image_storage_schema_version");
            entity.Property(e => e.ImageUpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("image_updated_at");
            entity.Property(e => e.Shortcode)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("shortcode");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uri)
                .HasColumnType("character varying")
                .HasColumnName("uri");
            entity.Property(e => e.VisibleInPicker)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("visible_in_picker");
        });

        modelBuilder.Entity<CustomEmojiCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("custom_emoji_categories_pkey");

            entity.ToTable("custom_emoji_categories");

            entity.HasIndex(e => e.Name, "index_custom_emoji_categories_on_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CustomFilter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("custom_filters_pkey");

            entity.ToTable("custom_filters");

            entity.HasIndex(e => e.AccountId, "index_custom_filters_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Action).HasColumnName("action");
            entity.Property(e => e.Context)
                .HasDefaultValueSql("'{}'::character varying[]")
                .HasColumnType("character varying[]")
                .HasColumnName("context");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires_at");
            entity.Property(e => e.Phrase)
                .HasDefaultValueSql("''::text")
                .HasColumnName("phrase");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.CustomFilters)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_8b8d786993");
        });

        modelBuilder.Entity<CustomFilterKeyword>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("custom_filter_keywords_pkey");

            entity.ToTable("custom_filter_keywords");

            entity.HasIndex(e => e.CustomFilterId, "index_custom_filter_keywords_on_custom_filter_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomFilterId).HasColumnName("custom_filter_id");
            entity.Property(e => e.Keyword)
                .HasDefaultValueSql("''::text")
                .HasColumnName("keyword");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.WholeWord)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("whole_word");

            entity.HasOne(d => d.CustomFilter).WithMany(p => p.CustomFilterKeywords)
                .HasForeignKey(d => d.CustomFilterId)
                .HasConstraintName("fk_rails_5a49a74012");
        });

        modelBuilder.Entity<CustomFilterStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("custom_filter_statuses_pkey");

            entity.ToTable("custom_filter_statuses");

            entity.HasIndex(e => e.CustomFilterId, "index_custom_filter_statuses_on_custom_filter_id");

            entity.HasIndex(e => e.StatusId, "index_custom_filter_statuses_on_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomFilterId).HasColumnName("custom_filter_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.CustomFilter).WithMany(p => p.CustomFilterStatuses)
                .HasForeignKey(d => d.CustomFilterId)
                .HasConstraintName("fk_rails_e2ddaf5b14");

            entity.HasOne(d => d.Status).WithMany(p => p.CustomFilterStatuses)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_rails_2f6d20c0cf");
        });

        modelBuilder.Entity<DeprecatedPreviewCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_deprecated_preview_cards_on_id");

            entity.ToTable("deprecated_preview_cards");

            entity.HasIndex(e => e.StatusId, "index_deprecated_preview_cards_on_status_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorName)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("author_name");
            entity.Property(e => e.AuthorUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("author_url");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Html)
                .HasDefaultValueSql("''::text")
                .HasColumnName("html");
            entity.Property(e => e.ImageContentType)
                .HasColumnType("character varying")
                .HasColumnName("image_content_type");
            entity.Property(e => e.ImageFileName)
                .HasColumnType("character varying")
                .HasColumnName("image_file_name");
            entity.Property(e => e.ImageFileSize).HasColumnName("image_file_size");
            entity.Property(e => e.ImageUpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("image_updated_at");
            entity.Property(e => e.ProviderName)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("provider_name");
            entity.Property(e => e.ProviderUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("provider_url");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Url)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("url");
            entity.Property(e => e.Width).HasColumnName("width");

            entity.HasOne(d => d.Status).WithOne(p => p.DeprecatedPreviewCard)
                .HasForeignKey<DeprecatedPreviewCard>(d => d.StatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_e0cd3ac7fe");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("devices_pkey");

            entity.ToTable("devices");

            entity.HasIndex(e => e.AccessTokenId, "index_devices_on_access_token_id");

            entity.HasIndex(e => e.AccountId, "index_devices_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessTokenId).HasColumnName("access_token_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("device_id");
            entity.Property(e => e.FingerprintKey)
                .HasDefaultValueSql("''::text")
                .HasColumnName("fingerprint_key");
            entity.Property(e => e.IdentityKey)
                .HasDefaultValueSql("''::text")
                .HasColumnName("identity_key");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.AccessToken).WithMany(p => p.Devices)
                .HasForeignKey(d => d.AccessTokenId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_393f74df68");

            entity.HasOne(d => d.Account).WithMany(p => p.Devices)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_a796b75798");
        });

        modelBuilder.Entity<DomainAllow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("domain_allows_pkey");

            entity.ToTable("domain_allows");

            entity.HasIndex(e => e.Domain, "index_domain_allows_on_domain").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Domain)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("domain");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DomainBlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_domain_blocks_on_id");

            entity.ToTable("domain_blocks");

            entity.HasIndex(e => e.Domain, "index_domain_blocks_on_domain").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Domain)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("domain");
            entity.Property(e => e.Obfuscate).HasColumnName("obfuscate");
            entity.Property(e => e.PrivateComment).HasColumnName("private_comment");
            entity.Property(e => e.PublicComment).HasColumnName("public_comment");
            entity.Property(e => e.RejectMedia).HasColumnName("reject_media");
            entity.Property(e => e.RejectReports).HasColumnName("reject_reports");
            entity.Property(e => e.Severity)
                .HasDefaultValueSql("0")
                .HasColumnName("severity");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<EmailDomainBlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("email_domain_blocks_pkey");

            entity.ToTable("email_domain_blocks");

            entity.HasIndex(e => e.Domain, "index_email_domain_blocks_on_domain").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Domain)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("domain");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_408efe0a15");
        });

        modelBuilder.Entity<EncryptedMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("encrypted_messages_pkey");

            entity.ToTable("encrypted_messages");

            entity.HasIndex(e => e.DeviceId, "index_encrypted_messages_on_device_id");

            entity.HasIndex(e => e.FromAccountId, "index_encrypted_messages_on_from_account_id");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("timestamp_id('encrypted_messages'::text)")
                .HasColumnName("id");
            entity.Property(e => e.Body)
                .HasDefaultValueSql("''::text")
                .HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Digest)
                .HasDefaultValueSql("''::text")
                .HasColumnName("digest");
            entity.Property(e => e.FromAccountId).HasColumnName("from_account_id");
            entity.Property(e => e.FromDeviceId)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("from_device_id");
            entity.Property(e => e.MessageFranking)
                .HasDefaultValueSql("''::text")
                .HasColumnName("message_franking");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Device).WithMany(p => p.EncryptedMessages)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_a83e4df7ae");

            entity.HasOne(d => d.FromAccount).WithMany(p => p.EncryptedMessages)
                .HasForeignKey(d => d.FromAccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_a42ad0f8d5");
        });

        modelBuilder.Entity<Favourite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_favourites_on_id");

            entity.ToTable("favourites");

            entity.HasIndex(e => new { e.AccountId, e.Id }, "index_favourites_on_account_id_and_id");

            entity.HasIndex(e => new { e.AccountId, e.StatusId }, "index_favourites_on_account_id_and_status_id").IsUnique();

            entity.HasIndex(e => e.StatusId, "index_favourites_on_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.Favourites)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_5eb6c2b873");

            entity.HasOne(d => d.Status).WithMany(p => p.Favourites)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_b0e856845e");
        });

        modelBuilder.Entity<FeaturedTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("featured_tags_pkey");

            entity.ToTable("featured_tags");

            entity.HasIndex(e => new { e.AccountId, e.TagId }, "index_featured_tags_on_account_id_and_tag_id").IsUnique();

            entity.HasIndex(e => e.TagId, "index_featured_tags_on_tag_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.LastStatusAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_status_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.StatusesCount).HasColumnName("statuses_count");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.FeaturedTags)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_rails_174efcf15f");

            entity.HasOne(d => d.Tag).WithMany(p => p.FeaturedTags)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("fk_rails_23a9055c7c");
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_follows_on_id");

            entity.ToTable("follows");

            entity.HasIndex(e => new { e.AccountId, e.TargetAccountId }, "index_follows_on_account_id_and_target_account_id").IsUnique();

            entity.HasIndex(e => e.TargetAccountId, "index_follows_on_target_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Languages)
                .HasColumnType("character varying[]")
                .HasColumnName("languages");
            entity.Property(e => e.Notify).HasColumnName("notify");
            entity.Property(e => e.ShowReblogs)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("show_reblogs");
            entity.Property(e => e.TargetAccountId).HasColumnName("target_account_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uri)
                .HasColumnType("character varying")
                .HasColumnName("uri");

            entity.HasOne(d => d.Account).WithMany(p => p.FollowAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_32ed1b5560");

            entity.HasOne(d => d.TargetAccount).WithMany(p => p.FollowTargetAccounts)
                .HasForeignKey(d => d.TargetAccountId)
                .HasConstraintName("fk_745ca29eac");
        });

        modelBuilder.Entity<FollowRecommendation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("follow_recommendations");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Reason).HasColumnName("reason");
        });

        modelBuilder.Entity<FollowRecommendationSuppression>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("follow_recommendation_suppressions_pkey");

            entity.ToTable("follow_recommendation_suppressions");

            entity.HasIndex(e => e.AccountId, "index_follow_recommendation_suppressions_on_account_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithOne(p => p.FollowRecommendationSuppression)
                .HasForeignKey<FollowRecommendationSuppression>(d => d.AccountId)
                .HasConstraintName("fk_rails_dfb9a1dbe2");
        });

        modelBuilder.Entity<FollowRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_follow_requests_on_id");

            entity.ToTable("follow_requests");

            entity.HasIndex(e => new { e.AccountId, e.TargetAccountId }, "index_follow_requests_on_account_id_and_target_account_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Languages)
                .HasColumnType("character varying[]")
                .HasColumnName("languages");
            entity.Property(e => e.Notify).HasColumnName("notify");
            entity.Property(e => e.ShowReblogs)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("show_reblogs");
            entity.Property(e => e.TargetAccountId).HasColumnName("target_account_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uri)
                .HasColumnType("character varying")
                .HasColumnName("uri");

            entity.HasOne(d => d.Account).WithMany(p => p.FollowRequestAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_76d644b0e7");

            entity.HasOne(d => d.TargetAccount).WithMany(p => p.FollowRequestTargetAccounts)
                .HasForeignKey(d => d.TargetAccountId)
                .HasConstraintName("fk_9291ec025d");
        });

        modelBuilder.Entity<Identity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_identities_on_id");

            entity.ToTable("identities");

            entity.HasIndex(e => e.UserId, "index_identities_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Provider)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("provider");
            entity.Property(e => e.Uid)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("uid");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Identities)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_bea040f377");
        });

        modelBuilder.Entity<Import>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_imports_on_id");

            entity.ToTable("imports");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Approved).HasColumnName("approved");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DataContentType)
                .HasColumnType("character varying")
                .HasColumnName("data_content_type");
            entity.Property(e => e.DataFileName)
                .HasColumnType("character varying")
                .HasColumnName("data_file_name");
            entity.Property(e => e.DataFileSize).HasColumnName("data_file_size");
            entity.Property(e => e.DataUpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_updated_at");
            entity.Property(e => e.Overwrite).HasColumnName("overwrite");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.Imports)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_6db1b6e408");
        });

        modelBuilder.Entity<Instance>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("instances");

            entity.Property(e => e.AccountsCount).HasColumnName("accounts_count");
            entity.Property(e => e.Domain)
                .HasColumnType("character varying")
                .HasColumnName("domain");
        });

        modelBuilder.Entity<Invite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("invites_pkey");

            entity.ToTable("invites");

            entity.HasIndex(e => e.Code, "index_invites_on_code").IsUnique();

            entity.HasIndex(e => e.UserId, "index_invites_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Autofollow).HasColumnName("autofollow");
            entity.Property(e => e.Code)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires_at");
            entity.Property(e => e.MaxUses).HasColumnName("max_uses");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Uses).HasColumnName("uses");

            entity.HasOne(d => d.User).WithMany(p => p.Invites)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_rails_ff69dbb2ac");
        });

        modelBuilder.Entity<IpBlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ip_blocks_pkey");

            entity.ToTable("ip_blocks");

            entity.HasIndex(e => e.Ip, "index_ip_blocks_on_ip").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasDefaultValueSql("''::text")
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires_at");
            entity.Property(e => e.Ip)
                .HasDefaultValueSql("'0.0.0.0'::inet")
                .HasColumnName("ip");
            entity.Property(e => e.Severity).HasColumnName("severity");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lists_pkey");

            entity.ToTable("lists");

            entity.HasIndex(e => e.AccountId, "index_lists_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.RepliesPolicy).HasColumnName("replies_policy");
            entity.Property(e => e.Title)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.Lists)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_rails_3853b78dac");
        });

        modelBuilder.Entity<ListAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("list_accounts_pkey");

            entity.ToTable("list_accounts");

            entity.HasIndex(e => new { e.AccountId, e.ListId }, "index_list_accounts_on_account_id_and_list_id").IsUnique();

            entity.HasIndex(e => e.FollowId, "index_list_accounts_on_follow_id").HasFilter("(follow_id IS NOT NULL)");

            entity.HasIndex(e => new { e.ListId, e.AccountId }, "index_list_accounts_on_list_id_and_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.FollowId).HasColumnName("follow_id");
            entity.Property(e => e.ListId).HasColumnName("list_id");

            entity.HasOne(d => d.Account).WithMany(p => p.ListAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_rails_85fee9d6ab");

            entity.HasOne(d => d.Follow).WithMany(p => p.ListAccounts)
                .HasForeignKey(d => d.FollowId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_40f9cc29f1");

            entity.HasOne(d => d.List).WithMany(p => p.ListAccounts)
                .HasForeignKey(d => d.ListId)
                .HasConstraintName("fk_rails_e54e356c88");
        });

        modelBuilder.Entity<LoginActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("login_activities_pkey");

            entity.ToTable("login_activities");

            entity.HasIndex(e => e.UserId, "index_login_activities_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthenticationMethod)
                .HasColumnType("character varying")
                .HasColumnName("authentication_method");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FailureReason)
                .HasColumnType("character varying")
                .HasColumnName("failure_reason");
            entity.Property(e => e.Ip).HasColumnName("ip");
            entity.Property(e => e.Provider)
                .HasColumnType("character varying")
                .HasColumnName("provider");
            entity.Property(e => e.Success).HasColumnName("success");
            entity.Property(e => e.UserAgent)
                .HasColumnType("character varying")
                .HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.LoginActivities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_rails_e4b6396b41");
        });

        modelBuilder.Entity<Marker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("markers_pkey");

            entity.ToTable("markers");

            entity.HasIndex(e => new { e.UserId, e.Timeline }, "index_markers_on_user_id_and_timeline").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.LastReadId).HasColumnName("last_read_id");
            entity.Property(e => e.LockVersion).HasColumnName("lock_version");
            entity.Property(e => e.Timeline)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("timeline");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Markers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_a7009bc2b6");
        });

        modelBuilder.Entity<MediaAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_media_attachments_on_id");

            entity.ToTable("media_attachments");

            entity.HasIndex(e => new { e.AccountId, e.StatusId }, "index_media_attachments_on_account_id_and_status_id").IsDescending(false, true);

            entity.HasIndex(e => e.ScheduledStatusId, "index_media_attachments_on_scheduled_status_id").HasFilter("(scheduled_status_id IS NOT NULL)");

            entity.HasIndex(e => e.Shortcode, "index_media_attachments_on_shortcode")
                .IsUnique()
                .HasFilter("(shortcode IS NOT NULL)")
                .HasOperators(new[] { "text_pattern_ops" });

            entity.HasIndex(e => e.StatusId, "index_media_attachments_on_status_id");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("timestamp_id('media_attachments'::text)")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Blurhash)
                .HasColumnType("character varying")
                .HasColumnName("blurhash");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FileContentType)
                .HasColumnType("character varying")
                .HasColumnName("file_content_type");
            entity.Property(e => e.FileFileName)
                .HasColumnType("character varying")
                .HasColumnName("file_file_name");
            entity.Property(e => e.FileFileSize).HasColumnName("file_file_size");
            entity.Property(e => e.FileMeta)
                .HasColumnType("json")
                .HasColumnName("file_meta");
            entity.Property(e => e.FileStorageSchemaVersion).HasColumnName("file_storage_schema_version");
            entity.Property(e => e.FileUpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("file_updated_at");
            entity.Property(e => e.Processing).HasColumnName("processing");
            entity.Property(e => e.RemoteUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("remote_url");
            entity.Property(e => e.ScheduledStatusId).HasColumnName("scheduled_status_id");
            entity.Property(e => e.Shortcode)
                .HasColumnType("character varying")
                .HasColumnName("shortcode");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.ThumbnailContentType)
                .HasColumnType("character varying")
                .HasColumnName("thumbnail_content_type");
            entity.Property(e => e.ThumbnailFileName)
                .HasColumnType("character varying")
                .HasColumnName("thumbnail_file_name");
            entity.Property(e => e.ThumbnailFileSize).HasColumnName("thumbnail_file_size");
            entity.Property(e => e.ThumbnailRemoteUrl)
                .HasColumnType("character varying")
                .HasColumnName("thumbnail_remote_url");
            entity.Property(e => e.ThumbnailUpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("thumbnail_updated_at");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.MediaAttachments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_96dd81e81b");

            entity.HasOne(d => d.ScheduledStatus).WithMany(p => p.MediaAttachments)
                .HasForeignKey(d => d.ScheduledStatusId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_31fc5aeef1");

            entity.HasOne(d => d.Status).WithMany(p => p.MediaAttachments)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_3ec0cfdd70");
        });

        modelBuilder.Entity<Mention>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_mentions_on_id");

            entity.ToTable("mentions");

            entity.HasIndex(e => new { e.AccountId, e.StatusId }, "index_mentions_on_account_id_and_status_id").IsUnique();

            entity.HasIndex(e => e.StatusId, "index_mentions_on_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Silent).HasColumnName("silent");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.Mentions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_970d43f9d1");

            entity.HasOne(d => d.Status).WithMany(p => p.Mentions)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_59edbe2887");
        });

        modelBuilder.Entity<Mute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_mutes_on_id");

            entity.ToTable("mutes");

            entity.HasIndex(e => new { e.AccountId, e.TargetAccountId }, "index_mutes_on_account_id_and_target_account_id").IsUnique();

            entity.HasIndex(e => e.TargetAccountId, "index_mutes_on_target_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires_at");
            entity.Property(e => e.HideNotifications)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("hide_notifications");
            entity.Property(e => e.TargetAccountId).HasColumnName("target_account_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.MuteAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_b8d8daf315");

            entity.HasOne(d => d.TargetAccount).WithMany(p => p.MuteTargetAccounts)
                .HasForeignKey(d => d.TargetAccountId)
                .HasConstraintName("fk_eecff219ea");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_notifications_on_id");

            entity.ToTable("notifications");

            entity.HasIndex(e => new { e.AccountId, e.Id, e.Type }, "index_notifications_on_account_id_and_id_and_type").IsDescending(false, true, false);

            entity.HasIndex(e => new { e.ActivityId, e.ActivityType }, "index_notifications_on_activity_id_and_activity_type");

            entity.HasIndex(e => e.FromAccountId, "index_notifications_on_from_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.ActivityType)
                .HasColumnType("character varying")
                .HasColumnName("activity_type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FromAccountId).HasColumnName("from_account_id");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.NotificationAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_c141c8ee55");

            entity.HasOne(d => d.FromAccount).WithMany(p => p.NotificationFromAccounts)
                .HasForeignKey(d => d.FromAccountId)
                .HasConstraintName("fk_fbd6b0bf9e");
        });

        modelBuilder.Entity<OauthAccessGrant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_oauth_access_grants_on_id");

            entity.ToTable("oauth_access_grants");

            entity.HasIndex(e => e.ResourceOwnerId, "index_oauth_access_grants_on_resource_owner_id");

            entity.HasIndex(e => e.Token, "index_oauth_access_grants_on_token").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresIn).HasColumnName("expires_in");
            entity.Property(e => e.RedirectUri).HasColumnName("redirect_uri");
            entity.Property(e => e.ResourceOwnerId).HasColumnName("resource_owner_id");
            entity.Property(e => e.RevokedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("revoked_at");
            entity.Property(e => e.Scopes)
                .HasColumnType("character varying")
                .HasColumnName("scopes");
            entity.Property(e => e.Token)
                .HasColumnType("character varying")
                .HasColumnName("token");

            entity.HasOne(d => d.Application).WithMany(p => p.OauthAccessGrants)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("fk_34d54b0a33");

            entity.HasOne(d => d.ResourceOwner).WithMany(p => p.OauthAccessGrants)
                .HasForeignKey(d => d.ResourceOwnerId)
                .HasConstraintName("fk_63b044929b");
        });

        modelBuilder.Entity<OauthAccessToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_oauth_access_tokens_on_id");

            entity.ToTable("oauth_access_tokens");

            entity.HasIndex(e => e.RefreshToken, "index_oauth_access_tokens_on_refresh_token")
                .IsUnique()
                .HasFilter("(refresh_token IS NOT NULL)")
                .HasOperators(new[] { "text_pattern_ops" });

            entity.HasIndex(e => e.ResourceOwnerId, "index_oauth_access_tokens_on_resource_owner_id").HasFilter("(resource_owner_id IS NOT NULL)");

            entity.HasIndex(e => e.Token, "index_oauth_access_tokens_on_token").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresIn).HasColumnName("expires_in");
            entity.Property(e => e.LastUsedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_used_at");
            entity.Property(e => e.LastUsedIp).HasColumnName("last_used_ip");
            entity.Property(e => e.RefreshToken)
                .HasColumnType("character varying")
                .HasColumnName("refresh_token");
            entity.Property(e => e.ResourceOwnerId).HasColumnName("resource_owner_id");
            entity.Property(e => e.RevokedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("revoked_at");
            entity.Property(e => e.Scopes)
                .HasColumnType("character varying")
                .HasColumnName("scopes");
            entity.Property(e => e.Token)
                .HasColumnType("character varying")
                .HasColumnName("token");

            entity.HasOne(d => d.Application).WithMany(p => p.OauthAccessTokens)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_f5fc4c1ee3");

            entity.HasOne(d => d.ResourceOwner).WithMany(p => p.OauthAccessTokens)
                .HasForeignKey(d => d.ResourceOwnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_e84df68546");
        });

        modelBuilder.Entity<OauthApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_oauth_applications_on_id");

            entity.ToTable("oauth_applications");

            entity.HasIndex(e => new { e.OwnerId, e.OwnerType }, "index_oauth_applications_on_owner_id_and_owner_type");

            entity.HasIndex(e => e.Uid, "index_oauth_applications_on_uid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Confidential)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("confidential");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.OwnerType)
                .HasColumnType("character varying")
                .HasColumnName("owner_type");
            entity.Property(e => e.RedirectUri).HasColumnName("redirect_uri");
            entity.Property(e => e.Scopes)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("scopes");
            entity.Property(e => e.Secret)
                .HasColumnType("character varying")
                .HasColumnName("secret");
            entity.Property(e => e.Superapp).HasColumnName("superapp");
            entity.Property(e => e.Uid)
                .HasColumnType("character varying")
                .HasColumnName("uid");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Website)
                .HasColumnType("character varying")
                .HasColumnName("website");

            entity.HasOne(d => d.Owner).WithMany(p => p.OauthApplications)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_b0988c7c0a");
        });

        modelBuilder.Entity<OneTimeKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("one_time_keys_pkey");

            entity.ToTable("one_time_keys");

            entity.HasIndex(e => e.DeviceId, "index_one_time_keys_on_device_id");

            entity.HasIndex(e => e.KeyId, "index_one_time_keys_on_key_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.Key)
                .HasDefaultValueSql("''::text")
                .HasColumnName("key");
            entity.Property(e => e.KeyId)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("key_id");
            entity.Property(e => e.Signature)
                .HasDefaultValueSql("''::text")
                .HasColumnName("signature");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Device).WithMany(p => p.OneTimeKeys)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_d3edd8c878");
        });

        modelBuilder.Entity<PgheroSpaceStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pghero_space_stats_pkey");

            entity.ToTable("pghero_space_stats");

            entity.HasIndex(e => new { e.Database, e.CapturedAt }, "index_pghero_space_stats_on_database_and_captured_at");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CapturedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("captured_at");
            entity.Property(e => e.Database).HasColumnName("database");
            entity.Property(e => e.Relation).HasColumnName("relation");
            entity.Property(e => e.Schema).HasColumnName("schema");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<Poll>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("polls_pkey");

            entity.ToTable("polls");

            entity.HasIndex(e => e.AccountId, "index_polls_on_account_id");

            entity.HasIndex(e => e.StatusId, "index_polls_on_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CachedTallies)
                .HasDefaultValueSql("'{}'::bigint[]")
                .HasColumnName("cached_tallies");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires_at");
            entity.Property(e => e.HideTotals).HasColumnName("hide_totals");
            entity.Property(e => e.LastFetchedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_fetched_at");
            entity.Property(e => e.LockVersion).HasColumnName("lock_version");
            entity.Property(e => e.Multiple).HasColumnName("multiple");
            entity.Property(e => e.Options)
                .HasDefaultValueSql("'{}'::character varying[]")
                .HasColumnType("character varying[]")
                .HasColumnName("options");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.VotersCount).HasColumnName("voters_count");
            entity.Property(e => e.VotesCount).HasColumnName("votes_count");

            entity.HasOne(d => d.Account).WithMany(p => p.Polls)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_5b19a0c011");

            entity.HasOne(d => d.Status).WithMany(p => p.Polls)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_3e0d9f1115");
        });

        modelBuilder.Entity<PollVote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("poll_votes_pkey");

            entity.ToTable("poll_votes");

            entity.HasIndex(e => e.AccountId, "index_poll_votes_on_account_id");

            entity.HasIndex(e => e.PollId, "index_poll_votes_on_poll_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Choice).HasColumnName("choice");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.PollId).HasColumnName("poll_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uri)
                .HasColumnType("character varying")
                .HasColumnName("uri");

            entity.HasOne(d => d.Account).WithMany(p => p.PollVotes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_b6c18cf44a");

            entity.HasOne(d => d.Poll).WithMany(p => p.PollVotes)
                .HasForeignKey(d => d.PollId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_a6e6974b7e");
        });

        modelBuilder.Entity<PreviewCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("preview_cards_pkey");

            entity.ToTable("preview_cards");

            entity.HasIndex(e => e.Url, "index_preview_cards_on_url").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorName)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("author_name");
            entity.Property(e => e.AuthorUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("author_url");
            entity.Property(e => e.Blurhash)
                .HasColumnType("character varying")
                .HasColumnName("blurhash");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.EmbedUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("embed_url");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Html)
                .HasDefaultValueSql("''::text")
                .HasColumnName("html");
            entity.Property(e => e.ImageContentType)
                .HasColumnType("character varying")
                .HasColumnName("image_content_type");
            entity.Property(e => e.ImageFileName)
                .HasColumnType("character varying")
                .HasColumnName("image_file_name");
            entity.Property(e => e.ImageFileSize).HasColumnName("image_file_size");
            entity.Property(e => e.ImageStorageSchemaVersion).HasColumnName("image_storage_schema_version");
            entity.Property(e => e.ImageUpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("image_updated_at");
            entity.Property(e => e.Language)
                .HasColumnType("character varying")
                .HasColumnName("language");
            entity.Property(e => e.LinkType).HasColumnName("link_type");
            entity.Property(e => e.MaxScore).HasColumnName("max_score");
            entity.Property(e => e.MaxScoreAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("max_score_at");
            entity.Property(e => e.ProviderName)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("provider_name");
            entity.Property(e => e.ProviderUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("provider_url");
            entity.Property(e => e.Title)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.Trendable).HasColumnName("trendable");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Url)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("url");
            entity.Property(e => e.Width).HasColumnName("width");
        });

        modelBuilder.Entity<PreviewCardProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("preview_card_providers_pkey");

            entity.ToTable("preview_card_providers");

            entity.HasIndex(e => e.Domain, "index_preview_card_providers_on_domain").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Domain)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("domain");
            entity.Property(e => e.IconContentType)
                .HasColumnType("character varying")
                .HasColumnName("icon_content_type");
            entity.Property(e => e.IconFileName)
                .HasColumnType("character varying")
                .HasColumnName("icon_file_name");
            entity.Property(e => e.IconFileSize).HasColumnName("icon_file_size");
            entity.Property(e => e.IconUpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("icon_updated_at");
            entity.Property(e => e.RequestedReviewAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("requested_review_at");
            entity.Property(e => e.ReviewedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reviewed_at");
            entity.Property(e => e.Trendable).HasColumnName("trendable");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PreviewCardTrend>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("preview_card_trends_pkey");

            entity.ToTable("preview_card_trends");

            entity.HasIndex(e => e.PreviewCardId, "index_preview_card_trends_on_preview_card_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Allowed).HasColumnName("allowed");
            entity.Property(e => e.Language)
                .HasColumnType("character varying")
                .HasColumnName("language");
            entity.Property(e => e.PreviewCardId).HasColumnName("preview_card_id");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Score).HasColumnName("score");

            entity.HasOne(d => d.PreviewCard).WithOne(p => p.PreviewCardTrend)
                .HasForeignKey<PreviewCardTrend>(d => d.PreviewCardId)
                .HasConstraintName("fk_rails_371593db34");
        });

        modelBuilder.Entity<PreviewCardsStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("preview_cards_statuses");

            entity.HasIndex(e => new { e.StatusId, e.PreviewCardId }, "index_preview_cards_statuses_on_status_id_and_preview_card_id");

            entity.Property(e => e.PreviewCardId).HasColumnName("preview_card_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
        });

        modelBuilder.Entity<Relay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("relays_pkey");

            entity.ToTable("relays");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FollowActivityId)
                .HasColumnType("character varying")
                .HasColumnName("follow_activity_id");
            entity.Property(e => e.InboxUrl)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("inbox_url");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_reports_on_id");

            entity.ToTable("reports");

            entity.HasIndex(e => e.AccountId, "index_reports_on_account_id");

            entity.HasIndex(e => e.ActionTakenByAccountId, "index_reports_on_action_taken_by_account_id").HasFilter("(action_taken_by_account_id IS NOT NULL)");

            entity.HasIndex(e => e.AssignedAccountId, "index_reports_on_assigned_account_id").HasFilter("(assigned_account_id IS NOT NULL)");

            entity.HasIndex(e => e.TargetAccountId, "index_reports_on_target_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ActionTakenAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("action_taken_at");
            entity.Property(e => e.ActionTakenByAccountId).HasColumnName("action_taken_by_account_id");
            entity.Property(e => e.AssignedAccountId).HasColumnName("assigned_account_id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Comment)
                .HasDefaultValueSql("''::text")
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Forwarded).HasColumnName("forwarded");
            entity.Property(e => e.RuleIds).HasColumnName("rule_ids");
            entity.Property(e => e.StatusIds)
                .HasDefaultValueSql("'{}'::integer[]")
                .HasColumnName("status_ids");
            entity.Property(e => e.TargetAccountId).HasColumnName("target_account_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uri)
                .HasColumnType("character varying")
                .HasColumnName("uri");

            entity.HasOne(d => d.Account).WithMany(p => p.ReportAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_4b81f7522c");

            entity.HasOne(d => d.ActionTakenByAccount).WithMany(p => p.ReportActionTakenByAccounts)
                .HasForeignKey(d => d.ActionTakenByAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_bca45b75fd");

            entity.HasOne(d => d.AssignedAccount).WithMany(p => p.ReportAssignedAccounts)
                .HasForeignKey(d => d.AssignedAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_4e7a498fb4");

            entity.HasOne(d => d.TargetAccount).WithMany(p => p.ReportTargetAccounts)
                .HasForeignKey(d => d.TargetAccountId)
                .HasConstraintName("fk_eb37af34f0");
        });

        modelBuilder.Entity<ReportNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("report_notes_pkey");

            entity.ToTable("report_notes");

            entity.HasIndex(e => e.AccountId, "index_report_notes_on_account_id");

            entity.HasIndex(e => e.ReportId, "index_report_notes_on_report_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.ReportNotes)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_rails_cae66353f3");

            entity.HasOne(d => d.Report).WithMany(p => p.ReportNotes)
                .HasForeignKey(d => d.ReportId)
                .HasConstraintName("fk_rails_7fa83a61eb");
        });

        modelBuilder.Entity<Rule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rules_pkey");

            entity.ToTable("rules");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Text)
                .HasDefaultValueSql("''::text")
                .HasColumnName("text");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ScheduledStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scheduled_statuses_pkey");

            entity.ToTable("scheduled_statuses");

            entity.HasIndex(e => e.AccountId, "index_scheduled_statuses_on_account_id");

            entity.HasIndex(e => e.ScheduledAt, "index_scheduled_statuses_on_scheduled_at");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Params)
                .HasColumnType("jsonb")
                .HasColumnName("params");
            entity.Property(e => e.ScheduledAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduled_at");

            entity.HasOne(d => d.Account).WithMany(p => p.ScheduledStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_23bd9018f9");
        });

        modelBuilder.Entity<SchemaMigration>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("schema_migrations_pkey");

            entity.ToTable("schema_migrations");

            entity.Property(e => e.Version)
                .HasColumnType("character varying")
                .HasColumnName("version");
        });

        modelBuilder.Entity<SessionActivation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("session_activations_pkey");

            entity.ToTable("session_activations");

            entity.HasIndex(e => e.AccessTokenId, "index_session_activations_on_access_token_id");

            entity.HasIndex(e => e.SessionId, "index_session_activations_on_session_id").IsUnique();

            entity.HasIndex(e => e.UserId, "index_session_activations_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessTokenId).HasColumnName("access_token_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Ip).HasColumnName("ip");
            entity.Property(e => e.SessionId)
                .HasColumnType("character varying")
                .HasColumnName("session_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserAgent)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WebPushSubscriptionId).HasColumnName("web_push_subscription_id");

            entity.HasOne(d => d.AccessToken).WithMany(p => p.SessionActivations)
                .HasForeignKey(d => d.AccessTokenId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_957e5bda89");

            entity.HasOne(d => d.User).WithMany(p => p.SessionActivations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_e5fda67334");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_settings_on_id");

            entity.ToTable("settings");

            entity.HasIndex(e => new { e.ThingType, e.ThingId, e.Var }, "index_settings_on_thing_type_and_thing_id_and_var").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ThingId).HasColumnName("thing_id");
            entity.Property(e => e.ThingType)
                .HasColumnType("character varying")
                .HasColumnName("thing_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.Var)
                .HasColumnType("character varying")
                .HasColumnName("var");
        });

        modelBuilder.Entity<SiteUpload>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("site_uploads_pkey");

            entity.ToTable("site_uploads");

            entity.HasIndex(e => e.Var, "index_site_uploads_on_var").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Blurhash)
                .HasColumnType("character varying")
                .HasColumnName("blurhash");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FileContentType)
                .HasColumnType("character varying")
                .HasColumnName("file_content_type");
            entity.Property(e => e.FileFileName)
                .HasColumnType("character varying")
                .HasColumnName("file_file_name");
            entity.Property(e => e.FileFileSize).HasColumnName("file_file_size");
            entity.Property(e => e.FileUpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("file_updated_at");
            entity.Property(e => e.Meta)
                .HasColumnType("json")
                .HasColumnName("meta");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Var)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("var");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.HasIndex(e => new { e.AccountId, e.Id, e.Visibility, e.UpdatedAt }, "index_statuses_20190820")
                .IsDescending(false, true, false, false)
                .HasFilter("(deleted_at IS NULL)");

            entity.HasIndex(e => new { e.Id, e.AccountId }, "index_statuses_local_20190824")
                .IsDescending(true, false)
                .HasFilter("((local OR (uri IS NULL)) AND (deleted_at IS NULL) AND (visibility = 0) AND (reblog_of_id IS NULL) AND ((NOT reply) OR (in_reply_to_account_id = account_id)))");

            entity.HasIndex(e => e.AccountId, "index_statuses_on_account_id");

            entity.HasIndex(e => e.DeletedAt, "index_statuses_on_deleted_at").HasFilter("(deleted_at IS NOT NULL)");

            entity.HasIndex(e => e.InReplyToAccountId, "index_statuses_on_in_reply_to_account_id").HasFilter("(in_reply_to_account_id IS NOT NULL)");

            entity.HasIndex(e => e.InReplyToId, "index_statuses_on_in_reply_to_id").HasFilter("(in_reply_to_id IS NOT NULL)");

            entity.HasIndex(e => new { e.ReblogOfId, e.AccountId }, "index_statuses_on_reblog_of_id_and_account_id");

            entity.HasIndex(e => e.Uri, "index_statuses_on_uri")
                .IsUnique()
                .HasFilter("(uri IS NOT NULL)")
                .HasOperators(new[] { "text_pattern_ops" });

            entity.HasIndex(e => new { e.Id, e.AccountId }, "index_statuses_public_20200119")
                .IsDescending(true, false)
                .HasFilter("((deleted_at IS NULL) AND (visibility = 0) AND (reblog_of_id IS NULL) AND ((NOT reply) OR (in_reply_to_account_id = account_id)))");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("timestamp_id('statuses'::text)")
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ApplicationId).HasColumnName("application_id");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_at");
            entity.Property(e => e.EditedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("edited_at");
            entity.Property(e => e.InReplyToAccountId).HasColumnName("in_reply_to_account_id");
            entity.Property(e => e.InReplyToId).HasColumnName("in_reply_to_id");
            entity.Property(e => e.Language)
                .HasColumnType("character varying")
                .HasColumnName("language");
            entity.Property(e => e.Local).HasColumnName("local");
            entity.Property(e => e.OrderedMediaAttachmentIds).HasColumnName("ordered_media_attachment_ids");
            entity.Property(e => e.PollId).HasColumnName("poll_id");
            entity.Property(e => e.ReblogOfId).HasColumnName("reblog_of_id");
            entity.Property(e => e.Reply).HasColumnName("reply");
            entity.Property(e => e.Sensitive).HasColumnName("sensitive");
            entity.Property(e => e.SpoilerText)
                .HasDefaultValueSql("''::text")
                .HasColumnName("spoiler_text");
            entity.Property(e => e.Text)
                .HasDefaultValueSql("''::text")
                .HasColumnName("text");
            entity.Property(e => e.Trendable).HasColumnName("trendable");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uri)
                .HasColumnType("character varying")
                .HasColumnName("uri");
            entity.Property(e => e.Url)
                .HasColumnType("character varying")
                .HasColumnName("url");
            entity.Property(e => e.Visibility).HasColumnName("visibility");

            entity.HasOne(d => d.Account).WithMany(p => p.StatusAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_9bda1543f7");

            entity.HasOne(d => d.InReplyToAccount).WithMany(p => p.StatusInReplyToAccounts)
                .HasForeignKey(d => d.InReplyToAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_c7fa917661");

            entity.HasOne(d => d.InReplyTo).WithMany(p => p.InverseInReplyTo)
                .HasForeignKey(d => d.InReplyToId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_94a6f70399");

            entity.HasOne(d => d.ReblogOf).WithMany(p => p.InverseReblogOf)
                .HasForeignKey(d => d.ReblogOfId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_256483a9ab");
        });

        modelBuilder.Entity<StatusEdit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_edits_pkey");

            entity.ToTable("status_edits");

            entity.HasIndex(e => e.AccountId, "index_status_edits_on_account_id");

            entity.HasIndex(e => e.StatusId, "index_status_edits_on_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.MediaDescriptions).HasColumnName("media_descriptions");
            entity.Property(e => e.OrderedMediaAttachmentIds).HasColumnName("ordered_media_attachment_ids");
            entity.Property(e => e.PollOptions)
                .HasColumnType("character varying[]")
                .HasColumnName("poll_options");
            entity.Property(e => e.Sensitive).HasColumnName("sensitive");
            entity.Property(e => e.SpoilerText)
                .HasDefaultValueSql("''::text")
                .HasColumnName("spoiler_text");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Text)
                .HasDefaultValueSql("''::text")
                .HasColumnName("text");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.StatusEdits)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_dc8988c545");

            entity.HasOne(d => d.Status).WithMany(p => p.StatusEdits)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_rails_a960f234a0");
        });

        modelBuilder.Entity<StatusPin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_pins_pkey");

            entity.ToTable("status_pins");

            entity.HasIndex(e => new { e.AccountId, e.StatusId }, "index_status_pins_on_account_id_and_status_id").IsUnique();

            entity.HasIndex(e => e.StatusId, "index_status_pins_on_status_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.StatusPins)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_d4cb435b62");

            entity.HasOne(d => d.Status).WithMany(p => p.StatusPins)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_rails_65c05552f1");
        });

        modelBuilder.Entity<StatusStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_stats_pkey");

            entity.ToTable("status_stats");

            entity.HasIndex(e => e.StatusId, "index_status_stats_on_status_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FavouritesCount).HasColumnName("favourites_count");
            entity.Property(e => e.ReblogsCount).HasColumnName("reblogs_count");
            entity.Property(e => e.RepliesCount).HasColumnName("replies_count");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Status).WithOne(p => p.StatusStat)
                .HasForeignKey<StatusStat>(d => d.StatusId)
                .HasConstraintName("fk_rails_4a247aac42");
        });

        modelBuilder.Entity<StatusTrend>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_trends_pkey");

            entity.ToTable("status_trends");

            entity.HasIndex(e => e.AccountId, "index_status_trends_on_account_id");

            entity.HasIndex(e => e.StatusId, "index_status_trends_on_status_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Allowed).HasColumnName("allowed");
            entity.Property(e => e.Language)
                .HasColumnType("character varying")
                .HasColumnName("language");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Account).WithMany(p => p.StatusTrends)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_rails_a6b527ea49");

            entity.HasOne(d => d.Status).WithOne(p => p.StatusTrend)
                .HasForeignKey<StatusTrend>(d => d.StatusId)
                .HasConstraintName("fk_rails_68c610dc1a");
        });

        modelBuilder.Entity<StatusesTag>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("statuses_tags");

            entity.HasIndex(e => e.StatusId, "index_statuses_tags_on_status_id");

            entity.HasIndex(e => new { e.TagId, e.StatusId }, "index_statuses_tags_on_tag_id_and_status_id").IsUnique();

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");

            entity.HasOne(d => d.Status).WithMany()
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("fk_rails_df0fe11427");

            entity.HasOne(d => d.Tag).WithMany()
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("fk_3081861e21");
        });

        modelBuilder.Entity<SystemKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("system_keys_pkey");

            entity.ToTable("system_keys");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_tags_on_id");

            entity.ToTable("tags");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DisplayName)
                .HasColumnType("character varying")
                .HasColumnName("display_name");
            entity.Property(e => e.LastStatusAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_status_at");
            entity.Property(e => e.Listable).HasColumnName("listable");
            entity.Property(e => e.MaxScore).HasColumnName("max_score");
            entity.Property(e => e.MaxScoreAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("max_score_at");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.RequestedReviewAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("requested_review_at");
            entity.Property(e => e.ReviewedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reviewed_at");
            entity.Property(e => e.Trendable).HasColumnName("trendable");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Usable).HasColumnName("usable");
        });

        modelBuilder.Entity<TagFollow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tag_follows_pkey");

            entity.ToTable("tag_follows");

            entity.HasIndex(e => new { e.AccountId, e.TagId }, "index_tag_follows_on_account_id_and_tag_id").IsUnique();

            entity.HasIndex(e => e.TagId, "index_tag_follows_on_tag_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Account).WithMany(p => p.TagFollows)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_rails_091e831473");

            entity.HasOne(d => d.Tag).WithMany(p => p.TagFollows)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("fk_rails_0deefe597f");
        });

        modelBuilder.Entity<Tombstone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tombstones_pkey");

            entity.ToTable("tombstones");

            entity.HasIndex(e => e.AccountId, "index_tombstones_on_account_id");

            entity.HasIndex(e => e.Uri, "index_tombstones_on_uri");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ByModerator).HasColumnName("by_moderator");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uri)
                .HasColumnType("character varying")
                .HasColumnName("uri");

            entity.HasOne(d => d.Account).WithMany(p => p.Tombstones)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_f95b861449");
        });

        modelBuilder.Entity<UnavailableDomain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("unavailable_domains_pkey");

            entity.ToTable("unavailable_domains");

            entity.HasIndex(e => e.Domain, "index_unavailable_domains_on_domain").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Domain)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("domain");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_users_on_id");

            entity.ToTable("users");

            entity.HasIndex(e => e.AccountId, "index_users_on_account_id");

            entity.HasIndex(e => e.ConfirmationToken, "index_users_on_confirmation_token").IsUnique();

            entity.HasIndex(e => e.CreatedByApplicationId, "index_users_on_created_by_application_id").HasFilter("(created_by_application_id IS NOT NULL)");

            entity.HasIndex(e => e.Email, "index_users_on_email").IsUnique();

            entity.HasIndex(e => e.ResetPasswordToken, "index_users_on_reset_password_token")
                .IsUnique()
                .HasFilter("(reset_password_token IS NOT NULL)")
                .HasOperators(new[] { "text_pattern_ops" });

            entity.HasIndex(e => e.RoleId, "index_users_on_role_id").HasFilter("(role_id IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Admin).HasColumnName("admin");
            entity.Property(e => e.Approved)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("approved");
            entity.Property(e => e.ChosenLanguages)
                .HasColumnType("character varying[]")
                .HasColumnName("chosen_languages");
            entity.Property(e => e.ConfirmationSentAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("confirmation_sent_at");
            entity.Property(e => e.ConfirmationToken)
                .HasColumnType("character varying")
                .HasColumnName("confirmation_token");
            entity.Property(e => e.ConfirmedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("confirmed_at");
            entity.Property(e => e.ConsumedTimestep).HasColumnName("consumed_timestep");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByApplicationId).HasColumnName("created_by_application_id");
            entity.Property(e => e.CurrentSignInAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("current_sign_in_at");
            entity.Property(e => e.Disabled).HasColumnName("disabled");
            entity.Property(e => e.Email)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.EncryptedOtpSecret)
                .HasColumnType("character varying")
                .HasColumnName("encrypted_otp_secret");
            entity.Property(e => e.EncryptedOtpSecretIv)
                .HasColumnType("character varying")
                .HasColumnName("encrypted_otp_secret_iv");
            entity.Property(e => e.EncryptedOtpSecretSalt)
                .HasColumnType("character varying")
                .HasColumnName("encrypted_otp_secret_salt");
            entity.Property(e => e.EncryptedPassword)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("encrypted_password");
            entity.Property(e => e.InviteId).HasColumnName("invite_id");
            entity.Property(e => e.LastEmailedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_emailed_at");
            entity.Property(e => e.LastSignInAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_sign_in_at");
            entity.Property(e => e.Locale)
                .HasColumnType("character varying")
                .HasColumnName("locale");
            entity.Property(e => e.Moderator).HasColumnName("moderator");
            entity.Property(e => e.OtpBackupCodes)
                .HasColumnType("character varying[]")
                .HasColumnName("otp_backup_codes");
            entity.Property(e => e.OtpRequiredForLogin).HasColumnName("otp_required_for_login");
            entity.Property(e => e.ResetPasswordSentAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reset_password_sent_at");
            entity.Property(e => e.ResetPasswordToken)
                .HasColumnType("character varying")
                .HasColumnName("reset_password_token");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.SignInCount).HasColumnName("sign_in_count");
            entity.Property(e => e.SignInToken)
                .HasColumnType("character varying")
                .HasColumnName("sign_in_token");
            entity.Property(e => e.SignInTokenSentAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sign_in_token_sent_at");
            entity.Property(e => e.SignUpIp).HasColumnName("sign_up_ip");
            entity.Property(e => e.SkipSignInToken).HasColumnName("skip_sign_in_token");
            entity.Property(e => e.UnconfirmedEmail)
                .HasColumnType("character varying")
                .HasColumnName("unconfirmed_email");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebauthnId)
                .HasColumnType("character varying")
                .HasColumnName("webauthn_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Users)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("fk_50500f500d");

            entity.HasOne(d => d.CreatedByApplication).WithMany(p => p.Users)
                .HasForeignKey(d => d.CreatedByApplicationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_ecc9536e7c");

            entity.HasOne(d => d.Invite).WithMany(p => p.Users)
                .HasForeignKey(d => d.InviteId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_8fb2a43e88");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_rails_642f17018b");
        });

        modelBuilder.Entity<UserInviteRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_invite_requests_pkey");

            entity.ToTable("user_invite_requests");

            entity.HasIndex(e => e.UserId, "index_user_invite_requests_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserInviteRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_3773f15361");
        });

        modelBuilder.Entity<UserIp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("user_ips");

            entity.Property(e => e.Ip).HasColumnName("ip");
            entity.Property(e => e.UsedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("used_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_roles_pkey");

            entity.ToTable("user_roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Highlighted).HasColumnName("highlighted");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Permissions).HasColumnName("permissions");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<WebPushSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("web_push_subscriptions_pkey");

            entity.ToTable("web_push_subscriptions");

            entity.HasIndex(e => e.AccessTokenId, "index_web_push_subscriptions_on_access_token_id").HasFilter("(access_token_id IS NOT NULL)");

            entity.HasIndex(e => e.UserId, "index_web_push_subscriptions_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessTokenId).HasColumnName("access_token_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Data)
                .HasColumnType("json")
                .HasColumnName("data");
            entity.Property(e => e.Endpoint)
                .HasColumnType("character varying")
                .HasColumnName("endpoint");
            entity.Property(e => e.KeyAuth)
                .HasColumnType("character varying")
                .HasColumnName("key_auth");
            entity.Property(e => e.KeyP256dh)
                .HasColumnType("character varying")
                .HasColumnName("key_p256dh");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.AccessToken).WithMany(p => p.WebPushSubscriptions)
                .HasForeignKey(d => d.AccessTokenId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_751a9f390b");

            entity.HasOne(d => d.User).WithMany(p => p.WebPushSubscriptions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_rails_b006f28dac");
        });

        modelBuilder.Entity<WebSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("index_web_settings_on_id");

            entity.ToTable("web_settings");

            entity.HasIndex(e => e.UserId, "index_web_settings_on_user_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Data)
                .HasColumnType("json")
                .HasColumnName("data");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.WebSetting)
                .HasForeignKey<WebSetting>(d => d.UserId)
                .HasConstraintName("fk_11910667b2");
        });

        modelBuilder.Entity<WebauthnCredential>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("webauthn_credentials_pkey");

            entity.ToTable("webauthn_credentials");

            entity.HasIndex(e => e.ExternalId, "index_webauthn_credentials_on_external_id").IsUnique();

            entity.HasIndex(e => e.UserId, "index_webauthn_credentials_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExternalId)
                .HasColumnType("character varying")
                .HasColumnName("external_id");
            entity.Property(e => e.Nickname)
                .HasColumnType("character varying")
                .HasColumnName("nickname");
            entity.Property(e => e.PublicKey)
                .HasColumnType("character varying")
                .HasColumnName("public_key");
            entity.Property(e => e.SignCount).HasColumnName("sign_count");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.WebauthnCredentials)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_rails_a4355aef77");
        });

        modelBuilder.Entity<Webhook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("webhooks_pkey");

            entity.ToTable("webhooks");

            entity.HasIndex(e => e.Url, "index_webhooks_on_url").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Enabled)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("enabled");
            entity.Property(e => e.Events)
                .HasDefaultValueSql("'{}'::character varying[]")
                .HasColumnType("character varying[]")
                .HasColumnName("events");
            entity.Property(e => e.Secret)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("secret");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Url)
                .HasColumnType("character varying")
                .HasColumnName("url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
