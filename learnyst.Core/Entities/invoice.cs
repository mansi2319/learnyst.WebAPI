using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class invoice
{
    public int id { get; set; }

    public int subscription_id { get; set; }

    public string invoice_number { get; set; } = null!;

    public string? billing_info { get; set; }

    public decimal total_amount { get; set; }

    public DateTime issued_at { get; set; }

    public string? status { get; set; }

    public virtual subscription subscription { get; set; } = null!;
}
