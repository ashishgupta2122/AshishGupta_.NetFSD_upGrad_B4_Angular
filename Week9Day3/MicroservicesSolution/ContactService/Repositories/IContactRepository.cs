using ContactService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactService.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task Add(Contact contact);
        Task Update(Contact contact);
        Task Delete(int id);
    }
}