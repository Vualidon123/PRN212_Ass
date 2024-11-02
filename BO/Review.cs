using System;
using System.Collections.Generic;

namespace BO;

public partial class Review
{
    public int Id { get; set; }

    public string? Comment { get; set; }

    public float Rating { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
