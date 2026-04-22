using ContactManagement.API.Models;
using ContactManagement.API.Services.Interfaces;

namespace ContactManagement.API.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new();
        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact? GetById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public Contact Add(Contact contact)
        {
            contact.Id = _contacts.Count > 0 ? _contacts.Max(c => c.Id) + 1 : 1;
            _contacts.Add(contact);
            return contact;
        }

        public bool Update(int id, Contact contact)
        {
            var existingContact = GetById(id);
            if (existingContact == null)
            {
                return false;
            }
            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.Phone = contact.Phone;
            return true;
        }

        public bool Delete(int id)
        {
            var contact = GetById(id);
            if (contact == null)
            {
                return false;
            }
            _contacts.Remove(contact);
            return true;
        }
    }
}