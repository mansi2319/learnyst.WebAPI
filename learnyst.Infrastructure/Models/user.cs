using System;
using System.Collections.Generic;

namespace learnyst.Infrastructure.Models;

public partial class user
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? email { get; set; }

    public string? role { get; set; }

    public DateTime? created_at { get; set; }
}
