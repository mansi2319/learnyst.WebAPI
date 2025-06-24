using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class subscriptionitem
{
    public int id { get; set; }

    public int subscription_id { get; set; }

    public string item_type { get; set; } = null!;

    public int item_id { get; set; }

    public decimal price { get; set; }

    public decimal? discount { get; set; }

    public virtual subscription subscription { get; set; } = null!;
}
