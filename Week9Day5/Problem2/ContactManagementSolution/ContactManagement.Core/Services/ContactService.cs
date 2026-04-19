using ContactManagement.Core.Entities;
using ContactManagement.Core.Interfaces;

namespace ContactManagement.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public void AddContact(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _repository.Add(contact);
        }

        public List<Contact> GetContacts()
        {
            return _repository.GetAll();
        }

        public bool RemoveContact(int id)
        {
            return _repository.Delete(id);
        }
    }
}