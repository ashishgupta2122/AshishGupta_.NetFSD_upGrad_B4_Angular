using ContactManagement.Core.Entities;

namespace ContactManagement.Core.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        bool DeleteContact(int id);
    }
}