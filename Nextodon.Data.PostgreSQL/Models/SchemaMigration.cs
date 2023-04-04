using System;
using System.Collections.Generic;

namespace Nextodon.Data.PostgreSQL.Models;

public partial class SchemaMigration
{
    public string Version { get; set; } = null!;
}
