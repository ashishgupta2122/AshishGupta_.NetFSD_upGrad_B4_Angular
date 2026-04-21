using ContactManagement.Core.Entities;
using ContactManagement.Core.Interfaces;
using ContactManagement.Infrastructure.Services;

IContactService service = new ContactService();

service.AddContact(new Contact
{
    Name = "Ashish",
    Email = "ashish@gmail.com",
    Phone = "9999999999"
});

service.AddContact(new Contact
{
    Name = "Kiya",
    Email = "kiya@gmail.com",
    Phone = "8888888888"
});

foreach (var contact in service.GetAllContacts())
{
    Console.WriteLine($"{contact.Id} - {contact.Name} - {contact.Email}");
}