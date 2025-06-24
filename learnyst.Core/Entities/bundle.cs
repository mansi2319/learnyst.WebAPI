using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class bundle
{
    public int id { get; set; }

    public string? title { get; set; }

    public string? description { get; set; }

    public decimal? price { get; set; }

    public string? course_ids { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}
