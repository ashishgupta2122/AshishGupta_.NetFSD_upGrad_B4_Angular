using ContactManagement.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.API.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo> {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Ashish",
                LastName = "Gupta",
                EmailId = "ashish@gmail.com",
                MobileNo = 9876543210,
                Designation = "Software Developer",
                CompanyId = 101,
                DepartmentId = 201
            }
        };

        public async Task<List<ContactInfo>> GetAllContactsAsync()
        {
            return await Task.FromResult(contacts);
        }

        public async Task<ContactInfo?> GetContactByIdAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return await Task.FromResult(contact);
        }

        public async Task<ContactInfo> AddContactAsync(ContactInfo contact)
        {
            contact.ContactId = contacts.Any() ? contacts.Max(c => c.ContactId) + 1 : 1;
            contacts.Add(contact);

            return await Task.FromResult(contact);
        }

        public async Task<bool> UpdateContactAsync(int id, ContactInfo contact)
        {
            var existing = contacts.FirstOrDefault(c => c.ContactId == id);
            if (existing == null)
            {
                return await Task.FromResult(false);
            }

            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.EmailId = contact.EmailId;
            existing.MobileNo = contact.MobileNo;
            existing.Designation = contact.Designation;
            existing.CompanyId = contact.CompanyId;
            existing.DepartmentId = contact.DepartmentId;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
            {
                return await Task.FromResult(false);
            }

            contacts.Remove(contact);
            return await Task.FromResult(true);
        }
    }
}