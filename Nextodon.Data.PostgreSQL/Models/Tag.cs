using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class Tag
{
    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long Id { get; set; }

    public bool? Usable { get; set; }

    public bool? Trendable { get; set; }

    public bool? Listable { get; set; }

    public DateTime? ReviewedAt { get; set; }

    public DateTime? RequestedReviewAt { get; set; }

    public DateTime? LastStatusAt { get; set; }

    public double? MaxScore { get; set; }

    public DateTime? MaxScoreAt { get; set; }

    public string? DisplayName { get; set; }

    public virtual ICollection<FeaturedTag> FeaturedTags { get; } = new List<FeaturedTag>();

    public virtual ICollection<TagFollow> TagFollows { get; } = new List<TagFollow>();
}
