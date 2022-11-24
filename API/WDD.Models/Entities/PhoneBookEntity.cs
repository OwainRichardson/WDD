using System.ComponentModel.DataAnnotations;

namespace WDD.Models.Entities
{
    public class PhoneBookEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
