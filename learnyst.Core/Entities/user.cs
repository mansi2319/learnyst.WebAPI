using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class user
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? email { get; set; }

    public string? mobile_number { get; set; }

    public string? password { get; set; }

    public string? role { get; set; }

    public DateOnly? date_of_birth { get; set; }

    public string? profile_image_url { get; set; }

    public DateTime? signup_date { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual ICollection<batch> batches { get; set; } = new List<batch>();

    public virtual ICollection<course> courses { get; set; } = new List<course>();

    public virtual ICollection<liveclass> liveclasses { get; set; } = new List<liveclass>();

    public virtual ICollection<referralcode> referralcodes { get; set; } = new List<referralcode>();

    public virtual ICollection<session> sessions { get; set; } = new List<session>();

    public virtual ICollection<subscription> subscriptions { get; set; } = new List<subscription>();
}
