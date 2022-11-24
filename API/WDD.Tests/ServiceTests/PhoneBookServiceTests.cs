using WDD.Models.DataModels;
using WDD.Repositories.Interfaces;
using WDD.Repositories.Repositories;
using WDD.Services.Interfaces;
using WDD.Services.Services;
using Xunit;

namespace WDD.Tests.ServiceTests
{
    public class PhoneBookServiceTests
    {
        private IPhoneBookDatabase _phoneBookDatabase;
        private readonly IPhoneBookRepository _phoneBookRepository;
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookServiceTests()
        {
            _phoneBookDatabase = new PhoneBookDatabase();
            _phoneBookRepository = new PhoneBookRepository(_phoneBookDatabase);
            _phoneBookService = new PhoneBookService(_phoneBookRepository);
        }

        [Fact]
        public void GetEntries_ReturnsCorrectNumberOfEntities()
        {
            List<PhoneBookEntry> entries = _phoneBookService.GetEntries();

            Assert.Equal(5, entries.Count);
        }

        [Fact]
        public void CreateEntry_ReturnsCorrectlyCreatedEntry()
        {
            PhoneBookEntry newEntry = _phoneBookService.CreateEntry("New", "Entry", "07779 444444");

            Assert.Equal(6, newEntry.Id);
            Assert.Equal("New", newEntry.FirstName);
            Assert.Equal("Entry", newEntry.LastName);
            Assert.Equal("07779 444444", newEntry.PhoneNumber);
            Assert.Equal("New Entry", newEntry.FullName);
        }

        [Fact]
        public void UpdateEntry_EntryDoesNotExist_ThrowsKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() => _phoneBookService.UpdateEntry(98, "Updated", "Entry", "07777 777777"));
        }

        [Fact]
        public void UpdateEntry_EntryExists_EntryIsUpdated_ReturnsUpdatedDetails()
        {
            PhoneBookEntry updatedEntry = _phoneBookService.UpdateEntry(1, "Updated", "Entry", "07946 112445");

            Assert.Equal(1, updatedEntry.Id);
            Assert.Equal("Updated", updatedEntry.FirstName);
            Assert.Equal("Entry", updatedEntry.LastName);
            Assert.Equal("07946 112445", updatedEntry.PhoneNumber);
            Assert.Equal("Updated Entry", updatedEntry.FullName);
        }

        [Fact]
        public void DeleteEntry_EntryDoesNotExist_ThrowsKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() => _phoneBookService.DeleteEntry(98));
        }

        [Fact]
        public void DeleteEntry_EntryExists_EntryIsDeletedFromDatabase()
        {
            _phoneBookService.DeleteEntry(1);

            Assert.Equal(4, _phoneBookDatabase.PhoneBookEntities.Count);
            Assert.Null(_phoneBookDatabase.PhoneBookEntities.SingleOrDefault(entity => entity.Id == 1));
        }
    }
}
