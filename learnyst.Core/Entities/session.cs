using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class session
{
    public int id { get; set; }

    public int? user_id { get; set; }

    public string? device_info { get; set; }

    public string? ip_address { get; set; }

    public string? token { get; set; }

    public DateTime? login_at { get; set; }

    public DateTime? logout_at { get; set; }

    public virtual user? user { get; set; }
}
