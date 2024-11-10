using System;
using System.Collections.Generic;

namespace BO;

public partial class OrderTracking
{
    public int Id { get; set; }

    public string OrderStatus { get; set; } = null!;

    public DateTime? Timestamp { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;
}
