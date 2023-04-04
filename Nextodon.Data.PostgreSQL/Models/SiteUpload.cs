using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class SiteUpload
{
    public long Id { get; set; }

    public string Var { get; set; } = null!;

    public string? FileFileName { get; set; }

    public string? FileContentType { get; set; }

    public long? FileFileSize { get; set; }

    public DateTime? FileUpdatedAt { get; set; }

    public string? Meta { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Blurhash { get; set; }
}
