using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class referralcode
{
    public int id { get; set; }

    public int coupon_id { get; set; }

    public int referred_user_id { get; set; }

    public virtual couponcode coupon { get; set; } = null!;

    public virtual user referred_user { get; set; } = null!;
}
