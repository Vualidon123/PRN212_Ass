using System;
using System.Collections.Generic;

namespace BO;

public partial class Revenue
{
    public int Id { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? Date { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
