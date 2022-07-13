using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDataApplication.Data;
using Models.Entities.ViewModels;
using Models.Entities;
using Services.Interfaces;
using AutoMapper;

namespace Services.Implementations
{
    public class UserService : BaseService, IUserService
    {
        private readonly IValidator<CreateUserViewModel> _createUserViewModelValidator;
        private readonly IValidator<EditUserViewModel> _editUserViewModelValidator;
        private readonly IMapper _mapper;

        public UserService(SchoolDataApplicationDbContext schoolDataApplicationDbContext, IValidator<CreateUserViewModel> createUserViewModelValidator, IValidator<EditUserViewModel> editUserViewModelValidator, IMapper mapper) : base(schoolDataApplicationDbContext)
        {
            _createUserViewModelValidator = createUserViewModelValidator;
            _editUserViewModelValidator = editUserViewModelValidator;
            _mapper = mapper;
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
                viewModel = new CreateUserViewModel { User = new User() };
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
            var user = _schoolDataApplicationDbContext.Users.SingleOrDefault(u => u.UserId == id);
            if (viewModel == null)
            {
                viewModel = new EditUserViewModel { User = user };
            }

            viewModel.UserTypeList = await _schoolDataApplicationDbContext.UserTypes.ToListAsync();
            viewModel.SchoolList = await _schoolDataApplicationDbContext.Schools.ToListAsync();
            viewModel.YearGroupList = await _schoolDataApplicationDbContext.YearGroups.ToListAsync();

            user.UserId = viewModel.User.UserId;
            user.FirstName = viewModel.User.FirstName;
            user.LastName = viewModel.User.LastName;
            user.UserTypeId = viewModel.User.UserTypeId;
            user.SchoolId = viewModel.User.SchoolId;
            user.DateOfBirth = viewModel.User.DateOfBirth;
            user.YearGroupId = viewModel.User.YearGroupId;

            return viewModel;
        }

        public async Task<ValidationResult> ValidateEditUserViewModel(EditUserViewModel viewModel)
        {
            ValidationResult result = await _editUserViewModelValidator.ValidateAsync(viewModel);
            return result;
        }

        public async Task<ActionResult> EditUser(User user)
        {
            try
            {
                if (!await DoesUserExist(user.UserId))
                {
                    return new BadRequestObjectResult(user);
                }

                var userToUpdate = await _schoolDataApplicationDbContext.Users.SingleAsync(a => a.UserId == user.UserId);

                user = Mapper.Map<User, User>(userToUpdate, user);

                _schoolDataApplicationDbContext.Users.Update(userToUpdate);

                await _schoolDataApplicationDbContext.SaveChangesAsync();

                //_schoolDataApplicationDbContext.Entry(user).State = EntityState.Modified;
                //_schoolDataApplicationDbContext.SaveChanges();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        private async Task<bool> DoesUserExist(int userId)
        {
            return await _schoolDataApplicationDbContext.Users.AnyAsync(a => a.UserId == userId);
        }
    }
}
