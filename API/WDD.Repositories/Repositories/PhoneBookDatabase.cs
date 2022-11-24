using WDD.Models.Entities;
using WDD.Repositories.Interfaces;

namespace WDD.Repositories.Repositories
{
    public class PhoneBookDatabase : IPhoneBookDatabase
    {
        public List<PhoneBookEntity> phoneBookEntities = new List<PhoneBookEntity>
        {
            new PhoneBookEntity { Id = 1, FirstName = "Eric", LastName = "Elliot", PhoneNumber = "07891 456376" },
            new PhoneBookEntity { Id = 2, FirstName = "Steve", LastName = "Jobs", PhoneNumber = "07291 556781" },
            new PhoneBookEntity { Id = 3, FirstName = "Fred", LastName = "Allen", PhoneNumber = "07743 132765" },
            new PhoneBookEntity { Id = 4, FirstName = "Steve", LastName = "Wozniak", PhoneNumber = "07643 197346" },
            new PhoneBookEntity { Id = 5, FirstName = "Bill", LastName = "Gates", PhoneNumber = "07666 979799" },
        };

        List<PhoneBookEntity> IPhoneBookDatabase.PhoneBookEntities
        {
            get
            {
                return phoneBookEntities;
            }
            set
            {
                phoneBookEntities = value;
            }
        }
    }
}
