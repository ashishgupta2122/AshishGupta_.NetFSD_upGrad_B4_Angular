namespace ContactManagement.API.Repositories.Interfaces
{
    public interface IContactRepository
    {
        List<ContactManagement.API.Models.Contact> GetAll();
        ContactManagement.API.Models.Contact GetById(int id);
    }
}