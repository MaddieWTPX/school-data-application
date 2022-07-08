﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolDataApplication.Models.ViewModels
{
    public class CreateUserViewModel
    {
        public User User { get; set; }
        public List<UserType> UserTypeList { get; set; }
        public List<School> SchoolList { get; set; }
        public List<YearGroup> YearGroupList { get; set; }

    }
}
