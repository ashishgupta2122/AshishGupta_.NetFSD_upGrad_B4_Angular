using ContactManagement.Core.Entities;

namespace ContactManagement.Core.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
        List<Contact> GetAllContacts();
    }
}