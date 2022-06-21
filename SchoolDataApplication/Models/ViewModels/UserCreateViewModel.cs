using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolDataApplication.Models.ViewModels
{
    public class UserCreateViewModel
    {
        public UserCreateViewModel()
        {

        }
        public User User { get; set; }
        public IEnumerable<SelectListItem> UserTypesNames { get; set; }  
        public string UserTypeName { get; set; }

        public string Title { get; set; }
    }
}
