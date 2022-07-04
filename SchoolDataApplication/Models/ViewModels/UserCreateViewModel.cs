using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolDataApplication.Models.ViewModels
{
    public class UserCreateViewModel
    {
        public UserCreateViewModel()
        {

        }
        public User User { get; set; }
        public SelectList UserTypeList { get; set; }
        public SelectList SchoolList { get; set; }
        public SelectList YearGroupList { get; set; }

    }
}
