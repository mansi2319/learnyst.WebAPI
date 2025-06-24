using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class subscription
{
    public int id { get; set; }

    public int user_id { get; set; }

    public decimal total_amount { get; set; }

    public decimal? discount_amount { get; set; }

    public string? status { get; set; }

    public string? couplon_code { get; set; }

    public DateTime subscription_date { get; set; }

    public virtual couponcode? couplon_codeNavigation { get; set; }

    public virtual ICollection<invoice> invoices { get; set; } = new List<invoice>();

    public virtual ICollection<paymenttransaction> paymenttransactions { get; set; } = new List<paymenttransaction>();

    public virtual ICollection<subscriptionitem> subscriptionitems { get; set; } = new List<subscriptionitem>();

    public virtual user user { get; set; } = null!;
}
