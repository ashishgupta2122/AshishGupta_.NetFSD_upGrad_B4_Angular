using NUnit.Framework;
using ContactManagement.Core.Entities;
using ContactManagement.Core.Services;


namespace ContactManagement.tests
{
    public class ContactServiceTests
    {
        private ContactService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ContactService();
        }

        [Test]
        public void AddContact_ShouldAddContactSuccessfully()
        {
            var contact = new Contact
            {
                Id = 1,
                Name = "Ashish",
                Email = "ashish@test.com"
            };

            _service.AddContact(contact);
            var result = _service.GetAllContacts();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAllContacts_ShouldReturnNonEmptyList()
        {
            _service.AddContact(new Contact { Id = 1, Name = "A", Email = "a@test.com" });

            var result = _service.GetAllContacts();

            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetContactById_ShouldReturnCorrectContact()
        {
            var contact = new Contact
            {
                Id = 1,
                Name = "Ashish",
                Email = "ashish@test.com"
            };
            _service.AddContact(contact);

            var result = _service.GetContactById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Ashish", result.Name);
        }

        [Test]
        public void DeleteContact_ShouldRemoveContactSuccessfully()
        {
            _service.AddContact(new Contact
            {
                Id = 1,
                Name = "Ashish",
                Email = "ashish@test.com"
            });

            var result = _service.DeleteContact(1);
            var remaining = _service.GetAllContacts();

            Assert.IsTrue(result);
            Assert.AreEqual(0, remaining.Count);
        }

        [Test]
        public void DeleteContact_ShouldReturnFalse_WhenNotFound()
        {
            var result = _service.DeleteContact(99);

            // Assert
            Assert.IsFalse(result);
        }
    }
}