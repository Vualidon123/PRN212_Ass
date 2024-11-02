using System;
using System.Collections.Generic;

namespace BO;

public partial class NewsModelNewsImage
{
    public int NewsModelNewsId { get; set; }

    public byte[]? NewsImage { get; set; }

    public virtual NewsModel NewsModelNews { get; set; } = null!;
}
