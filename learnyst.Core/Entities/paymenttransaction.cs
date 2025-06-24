using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class paymenttransaction
{
    public int id { get; set; }

    public int subscription_id { get; set; }

    public int payment_gateway_id { get; set; }

    public decimal amount { get; set; }

    public string? status { get; set; }

    public string? gateway_transaction_id { get; set; }

    public DateTime transaction_date { get; set; }

    public string? payment_method { get; set; }

    public virtual paymentgateway payment_gateway { get; set; } = null!;

    public virtual subscription subscription { get; set; } = null!;
}
