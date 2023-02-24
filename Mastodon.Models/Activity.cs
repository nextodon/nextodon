namespace Mastodon.Models;

/// <summary>
/// Instance activity over the last 3 months, binned weekly.
/// </summary>
public sealed class Activity {
    /// <summary>
    /// Midnight at the first day of the week.
    /// </summary>
    public required string Week { get; set; }

    /// <summary>
    /// The number of Statuses created since the week began.
    /// </summary>
    public required string Statuses { get; set; }

    /// <summary>
    /// The number of user logins since the week began.
    /// </summary>
    public required string Logins { get; set; }

    /// <summary>
    /// The number of user registrations since the week began.
    /// </summary>
    public required string Registrations { get; set; }
}
