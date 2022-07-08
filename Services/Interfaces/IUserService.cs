using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SchoolDataApplication.Models;
using SchoolDataApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<CreateUserViewModel> BuildCreateUserViewModel(CreateUserViewModel? viewModel = null);
        Task<ValidationResult> ValidateCreateUserViewModel(CreateUserViewModel viewModel);
        Task<ActionResult> AddUser(User user);
    }
}
