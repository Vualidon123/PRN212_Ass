using System;
using System.Collections.Generic;

namespace BO;

public partial class ComExampleDemoServiceShop
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public string? ShopName { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
