using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Models.Entities;
using Models;

namespace Services.Interfaces
{
    public interface IUserService
    { 
        Task<UserListViewModel> BuildInitialUserListViewModel();
        Task<UserListViewModel> BuildUserListViewModel(UserListViewModel? viewModel);
        Task<CreateUserViewModel> BuildCreateUserViewModel(CreateUserViewModel? viewModel = null);
        Task<ValidationResult> ValidateCreateUserViewModel(CreateUserViewModel viewModel);
        Task<EditUserViewModel> BuildEditUserViewModel(int id, EditUserViewModel? viewModel = null);
        Task<ValidationResult> ValidateEditUserViewModel(EditUserViewModel viewModel);
        Task<ActionResult> AddUser(User user);
        Task<ActionResult> EditUser(User user);
    }
}
