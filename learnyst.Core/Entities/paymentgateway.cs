using System;
using System.Collections.Generic;

namespace learnyst.Core.Entities;

public partial class paymentgateway
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string? config_data { get; set; }

    public bool? is_active { get; set; }

    public virtual ICollection<paymenttransaction> paymenttransactions { get; set; } = new List<paymenttransaction>();
}
