using ContactPaging.API.Data;
using ContactPaging.API.Models;
using ContactPaging.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactPaging.API.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetPagedAsync(int skip, int take)
        {
            return await _context.Contacts.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Contacts.CountAsync();
        }

    }
}