using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class DeprecatedPreviewCard
{
    public long? StatusId { get; set; }

    public string Url { get; set; } = null!;

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? ImageFileName { get; set; }

    public string? ImageContentType { get; set; }

    public long? ImageFileSize { get; set; }

    public DateTime? ImageUpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int Type { get; set; }

    public string Html { get; set; } = null!;

    public string AuthorName { get; set; } = null!;

    public string AuthorUrl { get; set; } = null!;

    public string ProviderName { get; set; } = null!;

    public string ProviderUrl { get; set; } = null!;

    public int Width { get; set; }

    public int Height { get; set; }

    public long Id { get; set; }

    public virtual Status? Status { get; set; }
}
