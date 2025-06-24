using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class batch
{
    public int id { get; set; }

    public string? title { get; set; }

    public decimal? price { get; set; }

    public int? course_id { get; set; }

    public DateOnly? start_date { get; set; }

    public DateOnly? end_date { get; set; }

    public int? instructor_id { get; set; }

    public virtual course? course { get; set; }

    public virtual user? instructor { get; set; }
}
