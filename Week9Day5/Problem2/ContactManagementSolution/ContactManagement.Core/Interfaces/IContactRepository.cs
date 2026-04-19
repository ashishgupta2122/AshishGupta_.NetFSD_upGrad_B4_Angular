using ContactManagement.Core.Entities;

namespace ContactManagement.Core.Interfaces
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        List<Contact> GetAll();
        bool Delete(int id);
    }
}