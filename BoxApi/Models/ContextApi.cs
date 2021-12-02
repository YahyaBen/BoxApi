using Microsoft.EntityFrameworkCore;

namespace BoxApi.Models
{
    public class ContextApi: DbContext
    {
        public ContextApi(DbContextOptions<ContextApi> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock_Categories>()
                .HasOne(bc => bc.Stock)
                .WithMany(b => b.Stock_Categories)
                .HasForeignKey(bc => bc.StockID);
            modelBuilder.Entity<Stock_Categories>()
                .HasOne(bc => bc.Categorie)
                .WithMany(c => c.Stock_Categories)
                .HasForeignKey(bc => bc.CategoryId);
        }
        public DbSet<Box> Boxs {get; set;}
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<OStock> OStock { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Stock_Categories> Stocks_Categories { get; set; }
    }
}
