using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class PreviewCardsStatus
{
    public long PreviewCardId { get; set; }

    public long StatusId { get; set; }
}
