
namespace Mastodon.Data;

public sealed class Instance
{
    [BsonElement("_id")]
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public string Id = default!;

    [BsonRequired]
    public required List<Rule> Rules;

    [BsonRequired]
    public required string Description;

    [BsonRequired]
    public required string ShortDescription;

    [BsonRequired]
    public required string Title;

    [BsonRequired]
    public required string Version;

    [BsonRequired]
    public required List<string> Languages;

    [BsonRequired]
    public required Types.Thumbnail Thumbnail;

    /// <summary>
    /// Configured values and limits for this website.
    /// </summary>
    [BsonRequired]
    public required Types.Configuration Configuration;

    /// <summary>
    /// Information about registering for this website.
    /// </summary>
    [BsonRequired]
    public required Types.Registrations Registrations;

    [BsonRequired]
    public required Types.Contact Contact;

    public static class Types
    {

        public sealed class Thumbnail
        {

            [BsonRequired]
            // The URL for the thumbnail image.
            public required string Url;

            [BsonRequired]
            // A hash computed by the Blur algorithm, for generating colorful preview thumbnails when media has not been downloaded yet.
            public string? Blurhash;

            /// <summary>
            /// Links to scaled resolution images, for high DPI screens.
            /// </summary>
            public Types.Versions? Versions;

            public static class Types
            {
                public sealed class Versions
                {
                    // The URL for the thumbnail image at 1x resolution.
                    [JsonPropertyName("@1x")]
                    public required string OneX;

                    // The URL for the thumbnail image at 2x resolution.
                    [JsonPropertyName("@2x")]
                    public required string TwoX;
                }
            }

        }

        /// <summary>
        /// Configured values and limits for this website.
        /// </summary>
        public sealed class Configuration
        {
            /// <summary>
            /// URLs of interest for clients apps.
            /// </summary>
            public required Types.Urls Urls;

            /// <summary>
            /// Limits related to accounts.
            /// </summary>
            public required Types.Accounts Accounts;

            /// <summary>
            /// Limits related to authoring statuses.
            /// </summary>
            public required Types.Statuses Statuses;

            /// <summary>
            /// Hints for which attachments will be accepted.
            /// </summary>
            public Types.MediaAttachments? MediaAttachments;

            /// <summary>
            /// Limits related to polls.
            /// </summary>
            public required Types.Polls Polls;

            /// <summary>
            /// Hints related to translation.
            /// </summary>
            public required Types.Translation Translation;

            public static class Types
            {

                /// <summary>
                /// URLs of interest for clients apps.
                /// </summary>
                public sealed class Urls
                {
                    /// <summary>
                    /// The Websockets URL for connecting to the streaming API.
                    /// </summary>
                    public string? Streaming;
                }

                /// <summary>
                /// Limits related to accounts.
                /// </summary>
                public sealed class Accounts
                {
                    /// <summary>
                    /// The maximum number of featured tags allowed for each account.
                    /// </summary>
                    public uint? MaxFeaturedTags;
                }

                /// <summary>
                /// Limits related to authoring statuses.
                /// </summary>
                public sealed class Statuses
                {
                    /// <summary>
                    /// The maximum number of allowed characters per status.
                    /// </summary>
                    public uint? MaxCharacters;

                    /// <summary>
                    /// The maximum number of media attachments that can be added to a status.
                    /// </summary>
                    public uint? MaxMediaAttachments;

                    /// <summary>
                    /// Each URL in a status will be assumed to be exactly this many characters.
                    /// </summary>
                    public uint? CharactersReservedPerUrl;
                }

                /// <summary>
                /// Hints for which attachments will be accepted.
                /// </summary>
                public sealed class MediaAttachments
                {
                    /// <summary>
                    /// Contains MIME types that can be uploaded.
                    /// </summary>
                    public required List<string> SupportedMimeTypes;

                    /// <summary>
                    /// The maximum size of any uploaded image, in bytes.
                    /// </summary>
                    public required uint ImageSizeLimit;

                    /// <summary>
                    /// The maximum number of pixels (width times height) for image uploads.
                    /// </summary>
                    public required uint ImageMatrixLimit;

                    /// <summary>
                    /// The maximum size of any uploaded video, in bytes.
                    /// </summary>
                    public required uint VideoSizeLimit;

                    /// <summary>
                    /// The maximum frame rate for any uploaded video.
                    /// </summary>
                    public required uint VideoFrameRateLimit;

                    /// <summary>
                    /// The maximum number of pixels (width times height) for video uploads.
                    /// </summary>
                    public required uint VideoMatrixLimit;
                }

                /// <summary>
                /// Limits related to polls.
                /// </summary>
                public sealed class Polls
                {
                    /// <summary>
                    /// Each poll is allowed to have up to this many options.
                    /// </summary>
                    public uint? MaxOptions;

                    /// <summary>
                    /// Each poll option is allowed to have this many characters.
                    /// </summary>
                    public uint? MaxCharactersPerOption;

                    /// <summary>
                    /// The shortest allowed poll duration, in seconds.
                    /// </summary>
                    public uint? MinExpiration;

                    /// <summary>
                    /// The longest allowed poll duration, in seconds.
                    /// </summary>
                    public uint? MaxExpiration;
                }

                /// <summary>
                /// Hints related to translation.
                /// </summary>
                public sealed class Translation
                {
                    /// <summary>
                    /// Whether the Translations API is available on this instance.
                    /// </summary>
                    public bool Enabled;
                }
            }

        }

        /// <summary>
        /// Information about registering for this website.
        /// </summary>
        public sealed class Registrations
        {
            [BsonRequired]
            public required bool Enabled;
            [BsonRequired]
            public required bool ApprovalRequired;
            [BsonRequired]
            public string? Message;
        }

        /// <summary>
        /// Hints related to contacting a representative of the website.
        /// </summary>
        public sealed class Contact
        {

            [BsonRequired]
            public required string Email;

            [BsonRequired]
            public required string AccountId;
        }
    }
}
