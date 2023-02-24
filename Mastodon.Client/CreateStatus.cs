namespace Mastodon.Client;

public sealed class CreateStatus {
    public required string Visibility { get; set; }
    public List<string>? MediaIds { get; set; }
    public Types.Poll? Poll { get; set; }
    public bool Sensitive { get; set; }
    public required string Status { get; set; }

    public static class Types {
        public sealed class Poll {
            public uint ExpiresIn { get; set; }
            public bool HideTotals { get; set; }
            public bool Multiple { get; set; }
            public required List<string> Options { get; set; }
        }
    }
}
