using EfCodeFirst.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirst.Data
{
    class EfContext : DbContext
    {
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Abteilung> Abteilungen { get; set; }
        public DbSet<Person> Personen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Kunde>().ToTable("Kunde");
            modelBuilder.Entity<Mitarbeiter>().ToTable("Mitarbeiter");

            modelBuilder.Entity<Abteilung>().Property(x => x.Bezeichnung)
                                            .HasMaxLength(55)
                                            .IsRequired()
                                            .HasColumnName("DepName");
        }

        public EfContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfCodeFirst;Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(Properties.Settings.Default.ConString);

            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
