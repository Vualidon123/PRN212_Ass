using System;
using System.Collections.Generic;

namespace BO;

public partial class CartItem
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }  // Consider changing to DateTime if DateOnly causes issues

    public int Quantity { get; set; }
    public decimal Price { get; set; }      // Price of the product


    public int CartId { get; set; }  // Non-nullable if the relationship is required
    public int ProductId { get; set; }  // Non-nullable if the relationship is required

    public virtual Cart Cart { get; set; } = null!;  // Ensuring non-null with initialization
    public virtual Product Product { get; set; } = null!;
}
