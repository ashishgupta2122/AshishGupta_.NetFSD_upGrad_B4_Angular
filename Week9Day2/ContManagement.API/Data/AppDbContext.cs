using Microsoft.EntityFrameworkCore;
using ContManagement.API.Models;

namespace ContManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts => Set<Contact>();
    }
}