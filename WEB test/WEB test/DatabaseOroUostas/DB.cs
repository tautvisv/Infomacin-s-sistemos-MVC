using System.Data.Entity;

namespace OroUostoSistema.DatabaseOroUostas
{
    public class DB:DbContext
    {
        public DbSet<Uzsakovas> Users { get; set; }
        public DbSet<Bilietas> Tickets { get; set; }
        public DbSet<Pardavejas> Sellers{ get; set; }
        public DbSet<Paslauga> Services { get; set; }
        public DbSet<SedimaVieta> Seats{ get; set; }
        public DbSet<Veiksmas> Action { get; set; }
        public DbSet<Skrydis> Flights { get; set; }
        public DB(): base("DB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        
    }
}