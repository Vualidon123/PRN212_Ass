using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BO;

public partial class TestyContext : DbContext
{
    public TestyContext()
    {
    }

    public TestyContext(DbContextOptions<TestyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BlogModel> BlogModels { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ForgotPassword> ForgotPasswords { get; set; }

    public virtual DbSet<GrowthRecord> GrowthRecords { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<NewsModel> NewsModels { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderTracking> OrderTrackings { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Revenue> Revenues { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WaterMonitor> WaterMonitors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DOHV4PE;uid=sa;pwd=12345;database=testy;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogModel>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__blog_mod__2975AA28447B850B");

            entity.ToTable("blog_model");

            entity.Property(e => e.BlogId).HasColumnName("blog_id");
            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.BlogContent).HasColumnName("blog_content");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.BlogModels)
                .HasForeignKey(d => d.Author)
                .HasConstraintName("FKrb9k5qpj8pn2vcfnvln0envyh");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cart__3213E83FD04EDC94");

            entity.ToTable("cart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasPrecision(6)
                .HasColumnName("date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FKg5uhi8vpsuy0lgloxk2h4w5o6");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cart_ite__3213E83F60936EE0");

            entity.ToTable("cart_item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK1uobyhgl1wvgt1jpccia8xxs3");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FKjcyd5wv4igqnw413rgxbfu4nv");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__category__D54EE9B4297EBFE2");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<ForgotPassword>(entity =>
        {
            entity.HasKey(e => e.Fpid).HasName("PK__forgot_p__330FD28F4A4C05CF");

            entity.ToTable("forgot_password");

            entity.HasIndex(e => e.UserId, "UKss96nm4ed1jmllpxib14p1r7v")
                .IsUnique()
                .HasFilter("([user_id] IS NOT NULL)");

            entity.Property(e => e.Fpid).HasColumnName("fpid");
            entity.Property(e => e.ExpirationTime)
                .HasPrecision(6)
                .HasColumnName("expiration_time");
            entity.Property(e => e.Otp).HasColumnName("otp");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Verified).HasColumnName("verified");

            entity.HasOne(d => d.User).WithOne(p => p.ForgotPassword)
                .HasForeignKey<ForgotPassword>(d => d.UserId)
                .HasConstraintName("FKjfa13lhndn1q66kheuyjk2i5l");
        });

        modelBuilder.Entity<GrowthRecord>(entity =>
        {
            entity.HasKey(e => new { e.Date, e.KoiFishKoiFishId }).HasName("PK__growth_r__FA2EB53B16C2E940");

            entity.ToTable("growth_record");

            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.KoiFishKoiFishId).HasColumnName("koi_fish_koi_fish_id");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.LengthRate).HasColumnName("length_rate");
            entity.Property(e => e.Physique)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("physique");
            entity.Property(e => e.PondId).HasColumnName("pond_id");
            entity.Property(e => e.UpdateAt)
                .HasPrecision(6)
                .HasColumnName("update_at");
            entity.Property(e => e.Weight).HasColumnName("weight");
            entity.Property(e => e.WeightRate).HasColumnName("weight_rate");

            entity.HasOne(d => d.KoiFishKoiFish).WithMany(p => p.GrowthRecords)
                .HasForeignKey(d => d.KoiFishKoiFishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKrlpiaiopo5m2hpq3dd1g268km");

            entity.HasOne(d => d.Pond).WithMany(p => p.GrowthRecords)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK63urc0uif24lfa66vp6ys3vn");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiFishId).HasName("PK__koi_fish__55AA1AFCE23EEC99");

            entity.ToTable("koi_fish");

            entity.Property(e => e.KoiFishId).HasColumnName("koi_fish_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Breeder)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("breeder");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.InPondSince).HasColumnName("in_pond_since");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Origin)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("origin");
            entity.Property(e => e.Physique)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("physique");
            entity.Property(e => e.PondId).HasColumnName("pond_id");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(38, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Sex)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sex");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Variety)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("variety");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Pond).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FKlrrrl78gs3102vgsixw7xmp9x");

            entity.HasOne(d => d.User).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FKbvlnquk56p7ests0ydsayxc73");
        });

        modelBuilder.Entity<NewsModel>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__news_mod__4C27CCD8619BCB82");

            entity.ToTable("news_model");

            entity.Property(e => e.NewsId).HasColumnName("news_id");
            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Headline)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("headline");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.NewsContent).HasColumnName("news_content");

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.NewsModels)
                .HasForeignKey(d => d.Author)
                .HasConstraintName("FKqjwmsky8fmlvua9ub9wr1h0x3");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__465962297FEF1C6E");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate)
                .HasPrecision(6)
                .HasColumnName("order_date");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("order_status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("numeric(38, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK32ql8ubntj5uh44ph9659tiih");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_it__3213E83F91D59F81");

            entity.ToTable("order_items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(38, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FKbioxgbv59vetrxe0ejfubep1w");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FKlf6f9q956mt144wiv6p1yko16");
        });

        modelBuilder.Entity<OrderTracking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_tr__3213E83FF834CEBC");

            entity.ToTable("order_tracking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("order_status");
            entity.Property(e => e.Timestamp)
                .HasPrecision(6)
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderTrackings)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKeu0lumcx8bcx6lk035xiklty0");
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.HasKey(e => e.PondId).HasName("PK__pond__890F243F48BC8BE6");

            entity.ToTable("pond");

            entity.Property(e => e.PondId).HasColumnName("pond_id");
            entity.Property(e => e.Depth).HasColumnName("depth");
            entity.Property(e => e.Drain).HasColumnName("drain");
            entity.Property(e => e.Location)
                .HasColumnType("text")
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NumberOfFish).HasColumnName("number_of_fish");
            entity.Property(e => e.Picture).HasColumnName("picture");
            entity.Property(e => e.PumpingCapacity).HasColumnName("pumping_capacity");
            entity.Property(e => e.Skimmers).HasColumnName("skimmers");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Volume).HasColumnName("volume");
            entity.Property(e => e.WaterSource)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("water_source");

            entity.HasOne(d => d.User).WithMany(p => p.Ponds)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK667ltpr5926616gxsfchiv45a");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3213E83F2723814E");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ExpiresAt)
                .HasPrecision(6)
                .HasColumnName("expires_at");
            entity.Property(e => e.Price)
                .HasColumnType("numeric(38, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductImage).HasColumnName("product_image");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductRating).HasColumnName("product_rating");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1mtsbur82frn64de7balymq9s");
        });

        modelBuilder.Entity<Revenue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__revenue__3213E83F0216F49F");

            entity.ToTable("revenue");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("numeric(38, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Revenues)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FKsvv589ciyfpf7yncrmhuftu3v");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__review__3213E83FB290CDF2");

            entity.ToTable("review");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKiyof1sindb9qiqr9o8npj8klt");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK6cpw2nlklblpvc7hyt7ko6v3e");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3213E83F2053BE02");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Name, "UKofx66keruapi6vyqpv6f2or37")
                .IsUnique()
                .HasFilter("([name] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FDB970471");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FKp56c1712k691lhsyewcssf40f");
        });

        modelBuilder.Entity<WaterMonitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__water_mo__3213E83FCD2243C2");

            entity.ToTable("water_monitor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ammonium).HasColumnName("ammonium");
            entity.Property(e => e.AmountFed).HasColumnName("amount_fed");
            entity.Property(e => e.CarbonHardnesskh).HasColumnName("carbon_hardnesskh");
            entity.Property(e => e.Co2).HasColumnName("co2");
            entity.Property(e => e.Date)
                .HasPrecision(6)
                .HasColumnName("date");
            entity.Property(e => e.DateTime)
                .HasPrecision(6)
                .HasColumnName("date_time");
            entity.Property(e => e.Hardnessgh).HasColumnName("hardnessgh");
            entity.Property(e => e.Nitrate).HasColumnName("nitrate");
            entity.Property(e => e.Nitrite).HasColumnName("nitrite");
            entity.Property(e => e.OutdoorTemperature).HasColumnName("outdoor_temperature");
            entity.Property(e => e.Oxygen).HasColumnName("oxygen");
            entity.Property(e => e.Ph).HasColumnName("ph");
            entity.Property(e => e.Phosphate).HasColumnName("phosphate");
            entity.Property(e => e.PondId).HasColumnName("pond_id");
            entity.Property(e => e.Salt).HasColumnName("salt");
            entity.Property(e => e.Temperature).HasColumnName("temperature");
            entity.Property(e => e.TotalChlorine).HasColumnName("total_chlorine");

            entity.HasOne(d => d.Pond).WithMany(p => p.WaterMonitors)
                .HasForeignKey(d => d.PondId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKn5sqq8371wfjvbglj8rqemfoq");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
