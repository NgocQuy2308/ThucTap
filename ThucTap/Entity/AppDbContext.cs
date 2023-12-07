using Microsoft.EntityFrameworkCore;

namespace ThucTap.Entity
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<PaymentDestination> PaymentDestinations { get; set; }
        public virtual DbSet<ConfirmEmail> ConfirmEmails { get; set; }
        public virtual DbSet<RefreshToken> Tokens { get; set; }
        public virtual DbSet<Decentralization> Decentralizations { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_type> Product_Types { get; set; }
        public virtual DbSet<Product_image> Product_Images { get; set; }
        public virtual DbSet<Product_review> Product_Reviews { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Cart_item> Cart_Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_detail> Order_Details { get; set; }
        public virtual DbSet<Order_status> Order_Statuses { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = DESKTOP-DD35A02\\QUY; " +
                                        $"Database=ThucTap;" +
                                        $"Trusted_Connection = True; " +
                                        $"TrustServerCertificate=True");
        }
    }
}
