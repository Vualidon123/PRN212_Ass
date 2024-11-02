using System;
using System.Collections.Generic;

namespace BO;

public partial class NewsModel
{
    public int NewsId { get; set; }

    public DateOnly? Date { get; set; }

    public string? Headline { get; set; }

    public string? NewsContent { get; set; }

    public int? Author { get; set; }

    public virtual User? AuthorNavigation { get; set; }
}
