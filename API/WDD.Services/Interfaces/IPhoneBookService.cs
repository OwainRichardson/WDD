using WDD.Models.DataModels;

namespace WDD.Services.Interfaces
{
    public interface IPhoneBookService
    {
        List<PhoneBookEntry> GetEntries();
        PhoneBookEntry CreateEntry(string firstName, string lastName, string phoneNumber);
        PhoneBookEntry UpdateEntry(int id, string firstName, string lastName, string phoneNumber);
        void DeleteEntry(int entryId);
    }
}
