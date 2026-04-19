using NUnit.Framework;
using Moq;
using ContactManagement.Core.Entities;
using ContactManagement.Core.Interfaces;
using ContactManagement.Core.Services;

namespace ContactManagement.Tests
{
    public class ContactServiceTests
    {
        private Mock<IContactRepository> _mockRepo;
        private ContactService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IContactRepository>();
            _service = new ContactService(_mockRepo.Object);
        }

        [Test]
        public void AddContact_ShouldCallRepository()
        {
            // Arrange
            var contact = new Contact { Id = 1, Name = "Ashish", Email = "ashish@test.com" };

            // Act
            _service.AddContact(contact);

            // Assert
            _mockRepo.Verify(r => r.Add(contact), Times.Once);
        }

        [Test]
        public void GetContacts_ShouldReturnData()
        {
            // Arrange
            var contacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "A", Email = "a@test.com" }
            };

            _mockRepo.Setup(r => r.GetAll()).Returns(contacts);

            // Act
            var result = _service.GetContacts();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void RemoveContact_ShouldReturnTrue()
        {
            // Arrange
            _mockRepo.Setup(r => r.Delete(1)).Returns(true);

            // Act
            var result = _service.RemoveContact(1);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AddContact_ShouldThrowException_WhenNull()
        {
            // Arrange
            Contact contact = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _service.AddContact(contact));
        }
    }
}