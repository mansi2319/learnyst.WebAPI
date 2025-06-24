using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class liveclass
{
    public int id { get; set; }

    public string? title { get; set; }

    public int? course_id { get; set; }

    public int? section_id { get; set; }

    public int? lessons_id { get; set; }

    public int? instructor_id { get; set; }

    public DateTime? start_time { get; set; }

    public DateTime? end_time { get; set; }

    public string? meeting_url { get; set; }

    public string? recording_url { get; set; }

    public virtual course? course { get; set; }

    public virtual user? instructor { get; set; }

    public virtual lesson? lessons { get; set; }

    public virtual section? section { get; set; }
}
