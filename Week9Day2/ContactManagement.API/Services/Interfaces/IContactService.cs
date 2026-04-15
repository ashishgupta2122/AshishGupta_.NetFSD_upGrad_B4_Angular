using ContactManagement.API.Models;

namespace ContactManagement.API.Services.Interfaces
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
    }
}