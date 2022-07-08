using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDataApplication.Data;
using SchoolDataApplication.Models;
using SchoolDataApplication.Models.ViewModels;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UserService : BaseService, IUserService
    {
        private readonly IValidator<CreateUserViewModel> _validator;

        public UserService(SchoolDataApplicationDbContext schoolDataApplicationDbContext, IValidator<CreateUserViewModel> validator) : base(schoolDataApplicationDbContext)
        {
            _validator = validator;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var user = await _schoolDataApplicationDbContext.Users
                .Include(u => u.UserType)
                .Include(u => u.School)
                .Include(u => u.YearGroup)
                .ToListAsync();
            return user;
        }

        public async Task<CreateUserViewModel> BuildCreateUserViewModel(CreateUserViewModel? viewModel = null)
        {
            if (viewModel == null)
            {
                viewModel = new CreateUserViewModel { User = new User () };
            }

            viewModel.UserTypeList = await _schoolDataApplicationDbContext.UserTypes.ToListAsync();
            viewModel.SchoolList = await _schoolDataApplicationDbContext.Schools.ToListAsync();
            viewModel.YearGroupList = await _schoolDataApplicationDbContext.YearGroups.ToListAsync();

            return viewModel;
        }

        public async Task<ValidationResult> ValidateCreateUserViewModel(CreateUserViewModel viewModel)
        {
            ValidationResult result = await _validator.ValidateAsync(viewModel);
            return result;
        }

        public async Task<ActionResult> AddUser(User user)
        {
            await _schoolDataApplicationDbContext.Users.AddAsync(user);
            await _schoolDataApplicationDbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
