using WDD.Models.DataModels;
using WDD.Models.Entities;
using WDD.Repositories.Interfaces;

namespace WDD.Repositories.Repositories
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly IPhoneBookDatabase _phoneBookDatabase;

        public PhoneBookRepository(IPhoneBookDatabase phoneBookDatabase)
        {
            _phoneBookDatabase = phoneBookDatabase;
        }

        public PhoneBookEntry CreateEntry(string firstName, string lastName, string phoneNumber)
        {
            int id = !_phoneBookDatabase.PhoneBookEntities.Any() ? 1 : _phoneBookDatabase.PhoneBookEntities.Max(booking => booking.Id) + 1;

            PhoneBookEntity newEntity = new PhoneBookEntity
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };

            _phoneBookDatabase.PhoneBookEntities.Add(newEntity);

            return new PhoneBookEntry
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
            };
        }

        public void DeleteEntry(int entryId)
        {
            PhoneBookEntity entity = _phoneBookDatabase.PhoneBookEntities.SingleOrDefault(entity => entity.Id == entryId);

            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            _phoneBookDatabase.PhoneBookEntities = _phoneBookDatabase.PhoneBookEntities.Where(entity => entity.Id != entryId).ToList();
        }

        public List<PhoneBookEntry> GetEntries()
        {
            return _phoneBookDatabase.PhoneBookEntities.OrderBy(entity => entity.LastName)
                            .Select(entity => new PhoneBookEntry
                            {
                                Id = entity.Id,
                                FirstName = entity.FirstName,
                                LastName = entity.LastName,
                                PhoneNumber = entity.PhoneNumber
                            })
                            .ToList();
        }

        public PhoneBookEntry UpdateEntry(int id, string firstName, string lastName, string phoneNumber)
        {
            PhoneBookEntity entity = _phoneBookDatabase.PhoneBookEntities.SingleOrDefault(entity => entity.Id == id);

            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            entity.FirstName = firstName;
            entity.LastName = lastName;
            entity.PhoneNumber = phoneNumber;

            return new PhoneBookEntry
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
            };
        }
    }
}
