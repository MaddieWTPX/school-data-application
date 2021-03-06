using Models.Entities;

namespace Models.ViewModels
{
    public class EditUserViewModel
    {
        public User User { get; set; }
        public List<UserType> UserTypeList { get; set; }
        public List<School> SchoolList { get; set; }
        public List<YearGroup> YearGroupList { get; set; }
    }
}
