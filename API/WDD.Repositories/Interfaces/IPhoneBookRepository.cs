using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDD.Models.DataModels;

namespace WDD.Repositories.Interfaces
{
    public interface IPhoneBookRepository
    {
        List<PhoneBookEntry> GetEntries();
        PhoneBookEntry CreateEntry(string firstName, string lastName, string phoneNumber);
        PhoneBookEntry UpdateEntry(int id, string firstName, string lastName, string phoneNumber);
        void DeleteEntry(int entryId);
    }
}
