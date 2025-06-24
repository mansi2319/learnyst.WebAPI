using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class couponcode
{
    public int id { get; set; }

    public string coupon_code { get; set; } = null!;

    public string type { get; set; } = null!;

    public decimal value { get; set; }

    public decimal? min_subscription_price { get; set; }

    public DateTime valid_from { get; set; }

    public DateTime valid_till { get; set; }

    public int? max_user { get; set; }

    public int? max_usage_per_user { get; set; }

    public int? user_used { get; set; }

    public bool? is_active { get; set; }

    public virtual ICollection<referralcode> referralcodes { get; set; } = new List<referralcode>();

    public virtual ICollection<subscription> subscriptions { get; set; } = new List<subscription>();
}
