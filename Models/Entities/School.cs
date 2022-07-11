using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class School
    {
        [Key]
        [DisplayName("School ID")]
        public int SchoolId { get; set; }
        [DisplayName("School Name")]
        public string? Name { get; set; }
        [DisplayName("School Address")]
        public string? Address { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
