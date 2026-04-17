using ContactService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Data   // ✅ MUST BE THIS
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}