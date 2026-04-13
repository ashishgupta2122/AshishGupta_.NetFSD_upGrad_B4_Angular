using Microsoft.EntityFrameworkCore;
using ContactManagement.DAL.Models;

namespace ContactManagement.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ContactInfo> Contacts
        {
            get;
            set;
        }
        public DbSet<Company> Companies
        {
            get;
            set;
        }
        public DbSet<Department> Departments
        {
            get;
            set;
        }
        public DbSet<User> Users
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PRIMARY KEY FIX (IMPORTANT)
            modelBuilder.Entity<ContactInfo>()
                .HasKey(c => c.ContactId);

            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Contacts)
                .HasForeignKey(c => c.DepartmentId);
        }
    }
}