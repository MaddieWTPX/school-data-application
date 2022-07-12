using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDataApplication.Data;
using Models.Entities.ViewModels;
using Models.Entities;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UserService : BaseService, IUserService
    {
        private readonly IValidator<CreateUserViewModel> _createUserViewModelValidator;
        private readonly IValidator<EditUserViewModel> _editUserViewModelValidator;

        public UserService(SchoolDataApplicationDbContext schoolDataApplicationDbContext, IValidator<CreateUserViewModel> createUserViewModelValidator, IValidator<EditUserViewModel> editUserViewModelValidator) : base(schoolDataApplicationDbContext)
        {
            _createUserViewModelValidator = createUserViewModelValidator;
            _editUserViewModelValidator = editUserViewModelValidator;
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
            ValidationResult result = await _createUserViewModelValidator.ValidateAsync(viewModel);
            return result;
        }

        public async Task<ActionResult> AddUser(User user)
        {
            await _schoolDataApplicationDbContext.Users.AddAsync(user);
            await _schoolDataApplicationDbContext.SaveChangesAsync();

            return new OkResult();
        }

        //public async Task<User> GetUser(int id)
        //{
        //    var user = _schoolDataApplicationDbContext.Users.Where(u => u.UserId == id).FirstOrDefault();
        //    return user;
        //}

        public async Task<EditUserViewModel> BuildEditUserViewModel(int id, EditUserViewModel? viewModel = null)
        {
            if (viewModel == null)
            {
                viewModel = new EditUserViewModel { User = _schoolDataApplicationDbContext.Users.Find(id) };
            }

            viewModel.UserTypeList = await _schoolDataApplicationDbContext.UserTypes.ToListAsync();
            viewModel.SchoolList = await _schoolDataApplicationDbContext.Schools.ToListAsync();
            viewModel.YearGroupList = await _schoolDataApplicationDbContext.YearGroups.ToListAsync();

            return viewModel;
        }

        public async Task<ValidationResult> ValidateEditUserViewModel(EditUserViewModel viewModel)
        {
            ValidationResult result = await _editUserViewModelValidator.ValidateAsync(viewModel);
            return result;
        }

        public async Task<ActionResult> EditUser(User user)
        {
            
            //await _schoolDataApplicationDbContext.Users.Update(user);
            await _schoolDataApplicationDbContext.SaveChangesAsync();
            return new OkResult();
        }
    }
}
