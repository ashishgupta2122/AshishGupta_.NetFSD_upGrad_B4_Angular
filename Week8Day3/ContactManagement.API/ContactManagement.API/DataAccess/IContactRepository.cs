using ContactManagement.API.Models;

namespace ContactManagement.API.DataAccess
{
    public interface IContactRepository
    {
        Task<List<ContactInfo>> GetAllContactsAsync();
        Task<ContactInfo?> GetContactByIdAsync(int id);
        Task<ContactInfo> AddContactAsync(ContactInfo contact);
        Task<bool> UpdateContactAsync(int id, ContactInfo contact);
        Task<bool> DeleteContactAsync(int id);
    }
}