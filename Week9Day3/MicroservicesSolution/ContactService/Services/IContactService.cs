using ContactService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactService.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task Add(Contact contact);
        Task Update(Contact contact); // ✅ FIXED
        Task Delete(int id);
    }
}