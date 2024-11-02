using System;
using System.Collections.Generic;

namespace BO;

public partial class BlogModelBlogImage
{
    public int BlogModelBlogId { get; set; }

    public byte[]? BlogImage { get; set; }

    public virtual BlogModel BlogModelBlog { get; set; } = null!;
}
