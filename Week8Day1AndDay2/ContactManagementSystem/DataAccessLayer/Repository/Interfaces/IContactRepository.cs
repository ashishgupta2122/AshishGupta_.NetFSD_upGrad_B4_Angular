using System.Collections.Generic;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repository.Interfaces;

public interface IContactRepository
{
    IEnumerable<ContactInfo> GetAllContacts();
    ContactInfo GetContactById(int id);
    void AddContact(ContactInfo contact);
    void UpdateContact(ContactInfo contact);
    void DeleteContact(int id);

    IEnumerable<Company> GetAllCompanies();
    IEnumerable<Department> GetAllDepartments();
}