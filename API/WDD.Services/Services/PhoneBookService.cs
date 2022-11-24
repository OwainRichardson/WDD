using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDD.Models.DataModels;
using WDD.Repositories.Interfaces;
using WDD.Services.Interfaces;

namespace WDD.Services.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public PhoneBookService(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public PhoneBookEntry CreateEntry(string firstName, string lastName, string phoneNumber)
        {
            return _phoneBookRepository.CreateEntry(firstName, lastName, phoneNumber);
        }

        public void DeleteEntry(int entryId)
        {
            _phoneBookRepository.DeleteEntry(entryId);
        }

        public List<PhoneBookEntry> GetEntries()
        {
            return _phoneBookRepository.GetEntries();
        }

        public PhoneBookEntry UpdateEntry(int id, string firstName, string lastName, string phoneNumber)
        {
            return _phoneBookRepository.UpdateEntry(id, firstName, lastName, phoneNumber);
        }
    }
}
