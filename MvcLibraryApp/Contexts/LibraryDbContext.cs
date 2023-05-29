using Microsoft.EntityFrameworkCore;
using MvcLibraryApp.Models.Entities;

namespace MvcLibraryApp.Contexts
{
    public class LibraryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MvcLibraryDb;" +
                "Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
                "Application Intent=ReadWrite;Multi Subnet Failover=False", builder =>
                {
                    builder.EnableRetryOnFailure(5,TimeSpan.FromSeconds(10), null);
                });
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Book>(a =>
            {
                a.ToTable("Books").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Author).HasColumnName("Author");
                a.Property(p => p.ReleaseDate).HasColumnName("ReleaseDate");
            });
            modelBuilder.Entity<Employee>(a =>
            {
                a.ToTable("Employees").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.Age).HasColumnName("Age");
            });
            modelBuilder.Entity<Student>(a =>
            {
                a.ToTable("Students").HasKey(s => s.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a=>a.Name).HasColumnName("Name");
                a.Property(a => a.LastName).HasColumnName("LastName");
                a.Property(a => a.Language).HasColumnName("Language");
                a.Property(a=>a.Number).HasColumnName("Number");
            });
            modelBuilder.Entity<Teacher>(a =>
            {
                a.ToTable("Teachers").HasKey(s => s.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.Name).HasColumnName("Name");
                a.Property(a => a.LastName).HasColumnName("LastName");
                a.Property(a => a.ExperienceYear).HasColumnName("Number");
            });
        }
    }
}
