using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDataApplication.Data;
using Models.ViewModels;
using Models.Entities;
using Services.Interfaces;
using AutoMapper;
using Models;

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

        //public async Task<List<User>> GetAllUsers()
        //{
        //    var user = await _schoolDataApplicationDbContext.Users
        //        .Include(u => u.UserType)
        //        .Include(u => u.School)
        //        .Include(u => u.YearGroup)
        //        .ToListAsync();
        //    return user;
        //}


        public async Task<UserListViewModel> GetAllUsers(int sortColumn = 1, string sortDirection = "asc")
        {
            var viewModel = new UserListViewModel
            {
                UserResults = await GetUserResults(sortColumn, sortDirection)
            };
            return viewModel;
        }

         private async Task<UserResults> GetUserResults(int sortColumn, string sortDirection)
        {
            UserResults userResults = new UserResults
            {
                Sorting = new Sorting
                {
                    SortDirection = sortDirection,
                    SortColumn = sortColumn
                },
                Users = await SortUserResults(sortColumn, sortDirection)
            };
            return userResults;
        }

        public async Task<List<User>> SortUserResults(int sortColumn, string sortDirection)
        {
            var users = new List<User>();


            if (sortDirection == "asc")
            {
                switch (sortColumn)
                {
                    case 1:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).OrderBy(a => a.FirstName).ToListAsync();
                        break;
                    case 2:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).OrderBy(a => a.LastName).ToListAsync();
                        break;
                    case 3:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).OrderBy(a => a.School.Name).ToListAsync();
                        break;
                    case 4:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).OrderBy(a => a.UserType.Name).ToListAsync();
                        break;
                    case 5:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).OrderBy(a => a.YearGroup.Name).ToListAsync();
                        break;
                    default:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).OrderBy(a => a.FirstName).ToListAsync();
                        break;
                }
            }
            else
            {
                switch (sortColumn)
                {
                    case 1:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).OrderByDescending(a => a.FirstName).ToListAsync();
                        break;
                    case 2:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).OrderByDescending(a => a.LastName).ToListAsync();
                        break;
                    case 3:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School.Name).OrderByDescending(a => a.School.Name).ToListAsync();
                        break;
                    case 4:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).OrderByDescending(a => a.UserType.Name).ToListAsync();
                        break;
                    case 5:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).OrderByDescending(a => a.YearGroup.Name).ToListAsync();
                        break;
                    default:
                        users = await _schoolDataApplicationDbContext.Users.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.School).OrderByDescending(a => a.FirstName).ToListAsync();
                        break;
                }
            }

            return users;
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
            if (viewModel.User.UserTypeId == 1)
            {
                user.DateOfBirth = null;
                user.YearGroupId = null;
            }
            else
            {
                user.DateOfBirth = viewModel.User.DateOfBirth;
                user.YearGroupId = viewModel.User.YearGroupId;
            }
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

            user = _mapper.Map(user, userToUpdate);

            _schoolDataApplicationDbContext.Users.Update(userToUpdate);

            await _schoolDataApplicationDbContext.SaveChangesAsync();
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
