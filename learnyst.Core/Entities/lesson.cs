using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class lesson
{
    public int id { get; set; }

    public int? section_id { get; set; }

    public string? type { get; set; }

    public string? title { get; set; }

    public string? content_url { get; set; }

    public int? duration { get; set; }

    public virtual ICollection<liveclass> liveclasses { get; set; } = new List<liveclass>();

    public virtual section? section { get; set; }
}
