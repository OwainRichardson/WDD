using WDD.Models.Entities;

namespace WDD.Repositories.Interfaces
{
    public interface IPhoneBookDatabase
    {
        List<PhoneBookEntity> PhoneBookEntities { get; set; }
    }
}
