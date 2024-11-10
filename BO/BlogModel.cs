using System;
using System.Collections.Generic;

namespace BO;

public partial class BlogModel
{
    public int BlogId { get; set; }

    public string? BlogContent { get; set; }

    public byte[]? Image { get; set; }

    public DateOnly? Date { get; set; }

    public string? Title { get; set; }

    public int? Author { get; set; }

    public virtual User? AuthorNavigation { get; set; }
}
