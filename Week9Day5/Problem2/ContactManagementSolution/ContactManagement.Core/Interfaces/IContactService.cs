using ContactManagement.Core.Entities;

namespace ContactManagement.Core.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetContacts();
        bool RemoveContact(int id);
    }
}