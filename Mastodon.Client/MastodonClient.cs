using System.Text;

namespace Mastodon.Client;

public sealed class MastodonClient {
    public readonly HttpClient HttpClient;

    public readonly AccountClient Accounts;
    public readonly BookmarkClient Bookmark;
    public readonly TimelineClient Timeline;
    public readonly InstanceClient Instance;
    public readonly ListClient Lists;
    public readonly MediaClient Media;
    public readonly StatusClient Statuses;
    public readonly PollClient Polls;
    public readonly ConversationClient Conversations;
    public readonly TrendsClient Trends;
    public readonly DirectoryClient Directory;
    public readonly AppsClient Apps;
    public readonly OAuthClient OAuth;
    public readonly SearchClient Search;

    private readonly Uri baseAddress;

    internal static JsonSerializerOptions _options = new() {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
    };

    public MastodonClient(Uri baseAddress) {
        this.baseAddress = baseAddress;
        HttpClient = new HttpClient { BaseAddress = baseAddress };

        Timeline = new TimelineClient(this);
        Instance = new InstanceClient(this);
        Media = new MediaClient(this);
        Statuses = new StatusClient(this);
        Accounts = new AccountClient(this);
        Polls = new PollClient(this);
        Conversations = new ConversationClient(this);
        Trends = new TrendsClient(this);
        Directory = new DirectoryClient(this);
        Apps = new AppsClient(this);
        OAuth = new OAuthClient(this);
        Lists = new ListClient(this);
        Search = new SearchClient(this);
        Bookmark = new BookmarkClient(this);
    }

    private sealed class SnakeCaseNamingPolicy : JsonNamingPolicy {
        public override string ConvertName(string name) => JsonUtils.ToSnakeCase(name);


        private static class JsonUtils {
            private enum SeparatedCaseState {
                Start,
                Lower,
                Upper,
                NewWord
            }

            public static string ToSnakeCase(string s) => ToSeparatedCase(s, '_');

            private static string ToSeparatedCase(string s, char separator) {
                if (string.IsNullOrEmpty(s)) {
                    return s;
                }

                StringBuilder sb = new StringBuilder();
                SeparatedCaseState state = SeparatedCaseState.Start;

                for (int i = 0; i < s.Length; i++) {
                    if (s[i] == ' ') {
                        if (state != SeparatedCaseState.Start) {
                            state = SeparatedCaseState.NewWord;
                        }
                    }
                    else if (char.IsUpper(s[i])) {
                        switch (state) {
                            case SeparatedCaseState.Upper:
                                bool hasNext = (i + 1 < s.Length);
                                if (i > 0 && hasNext) {
                                    char nextChar = s[i + 1];
                                    if (!char.IsUpper(nextChar) && nextChar != separator) {
                                        sb.Append(separator);
                                    }
                                }
                                break;
                            case SeparatedCaseState.Lower:
                            case SeparatedCaseState.NewWord:
                                sb.Append(separator);
                                break;
                        }

                        char c;
                        c = char.ToLowerInvariant(s[i]);
                        sb.Append(c);

                        state = SeparatedCaseState.Upper;
                    }
                    else if (s[i] == separator) {
                        sb.Append(separator);
                        state = SeparatedCaseState.Start;
                    }
                    else {
                        if (state == SeparatedCaseState.NewWord) {
                            sb.Append(separator);
                        }

                        sb.Append(s[i]);
                        state = SeparatedCaseState.Lower;
                    }
                }

                return sb.ToString();
            }
        }
    }
}
