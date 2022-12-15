namespace Mastodon.Models;

public sealed class InstanceV1
{
    public required string Uri { get; set; }
    public required string Title { get; set; }
    public required string ShortDescription { get; set; }
    public required string Description { get; set; }
    public required string Email { get; set; }
    public required string Version { get; set; }
    public required UrlsHash Urls { get; set; }
    public required StatsHash Stats { get; set; }
    public required string Thumbnail { get; set; }
    public required List< string> Languages { get; set; }
    public required bool Registrations { get; set; }
    public required bool ApprovalRequired { get; set; }
    public required bool InvitesEnabled { get; set; }
    public required ConfigurationHash Configuration { get; set; }
    public required Account ContactAccount { get; set; }
    public required List<Rule> Rules { get; set; }

    public sealed class UrlsHash
    {
        public required string StreamingApi { get; set; }
    }

    public sealed class StatsHash
    {
        public uint UserCount { get; set; }
        public uint StatusCount { get; set; }
        public uint DomainCount { get; set; }
    }

    /// <summary>
    /// Configured values and limits for this website.
    /// </summary>
    public sealed partial class ConfigurationHash
    {
        /// <summary>
        /// Limits related to authoring statuses.
        /// </summary>
        public required Instance.ConfigurationHash.StatusesHash Statuses { get; set; }

        /// <summary>
        /// Hints for which attachments will be accepted.
        /// </summary>
        public required Instance.ConfigurationHash.MediaAttachmentsHash MediaAttachments { get; set; }

        /// <summary>
        /// Limits related to polls.
        /// </summary>
        public required Instance.ConfigurationHash.PollsHash Polls { get; set; }
    }
}