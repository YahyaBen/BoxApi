using Microsoft.EntityFrameworkCore;

namespace BoxApi.Models
{
    public class ContextApi: DbContext
    {
        public ContextApi(DbContextOptions<ContextApi> options) : base(options)
        {

        }
        public DbSet<Box> Boxs {get; set;}
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<OStock> OStock { get; set; }
        public DbSet<Commande> Commandes { get; set; }
    }
}
