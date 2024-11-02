using System;
using System.Collections.Generic;

namespace BO;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<BlogModel> BlogModels { get; set; } = new List<BlogModel>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ComExampleDemoServiceShop? ComExampleDemoServiceShop { get; set; }

    public virtual ForgotPassword? ForgotPassword { get; set; }

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();

    public virtual ICollection<NewsModel> NewsModels { get; set; } = new List<NewsModel>();

    public virtual ICollection<Pond> Ponds { get; set; } = new List<Pond>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Role? Role { get; set; }
}
