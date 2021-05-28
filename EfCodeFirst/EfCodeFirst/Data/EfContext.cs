using EfCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using System;

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
            //fluent-API

            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Kunde>().ToTable("Kunde");
            modelBuilder.Entity<Mitarbeiter>().ToTable("Mitarbeiter");

            modelBuilder.Entity<Abteilung>().Property(x => x.Bezeichnung)
                                            .HasMaxLength(55)
                                            .IsRequired()
                                            .HasColumnName("DepName");


            //todo conventions
            modelBuilder.Entity<Person>().Property(x => x.LastModified).IsConcurrencyToken();
            modelBuilder.Entity<Person>().Property(x => x.RowVersion).IsRowVersion().IsConcurrencyToken();

            //modelBuilder.Entity<Mitarbeiter>().Property(x => x.Beruf).IsConcurrencyToken(); 
        }

        public EfContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            Database.Migrate();
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries<Entity>())
            {
                if (item.State == EntityState.Added || item.State == EntityState.Modified)
                {
                    item.Entity.LastModified = DateTime.Now;
                    item.Entity.LastModifier = Environment.UserName;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfCodeFirst;Trusted_Connection=true;");
            //optionsBuilder.UseSqlServer(Properties.Settings.Default.ConString);

            optionsBuilder.UseLazyLoadingProxies();


            base.OnConfiguring(optionsBuilder);
        }
    }
}
