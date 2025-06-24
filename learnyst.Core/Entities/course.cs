using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class course
{
    public int id { get; set; }

    public string? title { get; set; }

    public string? description { get; set; }

    public decimal? price { get; set; }

    public int? access_duration { get; set; }

    public string? visibility { get; set; }

    public string? status { get; set; }

    public int? instructor_id { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual ICollection<batch> batches { get; set; } = new List<batch>();

    public virtual user? instructor { get; set; }

    public virtual ICollection<liveclass> liveclasses { get; set; } = new List<liveclass>();

    public virtual ICollection<section> sections { get; set; } = new List<section>();
}
