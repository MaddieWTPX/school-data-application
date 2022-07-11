using System.ComponentModel;

namespace Models.Entities
{
    public class YearGroup
    {
        [DisplayName("Year Group")]
        public int YearGroupId { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}