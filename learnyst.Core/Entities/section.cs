using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class section
{
    public int id { get; set; }

    public int? course_id { get; set; }

    public string? title { get; set; }

    public int? position { get; set; }

    public virtual course? course { get; set; }

    public virtual ICollection<lesson> lessons { get; set; } = new List<lesson>();

    public virtual ICollection<liveclass> liveclasses { get; set; } = new List<liveclass>();
}
