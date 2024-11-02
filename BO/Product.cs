using System;
using System.Collections.Generic;

namespace BO;

public partial class Product
{
    public int Id { get; set; }

    public long Amount { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public byte[]? ProductImage { get; set; }

    public string? ProductName { get; set; }

    public double ProductRating { get; set; }

    public int StockQuantity { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
