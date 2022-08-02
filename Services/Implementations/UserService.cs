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
using Models.Constants;

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


        public async Task<UserListViewModel> BuildInitialUserListViewModel()
        {
            var viewModel = new UserListViewModel();
            try
            {
                viewModel.UserTypeList = await _schoolDataApplicationDbContext.UserTypes.ToListAsync();
                viewModel.SchoolList = await _schoolDataApplicationDbContext.Schools.ToListAsync();
                viewModel.YearGroupList = await _schoolDataApplicationDbContext.YearGroups.ToListAsync();

                var query = BuildUserResultsQuery();
                query = FilterUserResults(query, viewModel.FirstName, viewModel.LastName, viewModel.SelectedUserTypeId, viewModel.SelectedSchoolId, viewModel.SelectedYearGroupId);

                viewModel.UserResults.TableControls.Paging = new Paging(await query.CountAsync());

                query = (IQueryable<User>)viewModel.UserResults.TableControls.Sorting.SortUserResults(viewModel.UserResults.TableControls.Sorting, viewModel.UserResults.TableControls.Paging, query);

                viewModel.UserResults.Results = await query.ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return viewModel;
        }


        private IQueryable<User> BuildUserResultsQuery()
        {
            return _schoolDataApplicationDbContext.Users.Include(u => u.UserType).Include(u => u.School).Include(u => u.YearGroup).AsQueryable();
        }

        private IQueryable<User> FilterUserResults(IQueryable<User> query, string? firstName, string? lastName, int? userTypeId, int? schoolId, int? yearGroupId)
        {
            if(!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(u => u.FirstName.Contains(firstName));
            }
            if(!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(u => u.LastName.Contains(lastName));
            }
            if(userTypeId != 0 && userTypeId != null)
            {
                query = query.Where(u => u.UserTypeId == userTypeId);
            }
            if(schoolId != 0 && schoolId != null)
            {
                query = query.Where(u => u.SchoolId == schoolId);
            }
            if(yearGroupId != 0 && yearGroupId != null)
            {
                query = query.Where(u => u.YearGroupId == yearGroupId);
            }
            return query;
        }


        public async Task<UserListViewModel> BuildUserListViewModel(UserListViewModel viewModel)
        {
            viewModel.UserTypeList = await _schoolDataApplicationDbContext.UserTypes.ToListAsync();
            viewModel.SchoolList = await _schoolDataApplicationDbContext.Schools.ToListAsync();
            viewModel.YearGroupList = await _schoolDataApplicationDbContext.YearGroups.ToListAsync();

            if (viewModel.UserResults.TableControls.Sorting == null)
            {
                viewModel.UserResults.TableControls.Sorting = new Sorting<ConstantStrings>
                {
                    SortColumn = new ConstantStrings().FIRST_NAME,
                    SortingFields = new ConstantStrings()
                };
            };
            var query = BuildUserResultsQuery();
            query = FilterUserResults(query, viewModel.FirstName, viewModel.LastName, viewModel.SelectedUserTypeId, viewModel.SelectedYearGroupId, viewModel.SelectedSchoolId);

            viewModel.UserResults.TableControls.Paging = new Paging(await query.CountAsync());
            query = (IQueryable<User>)viewModel.UserResults.TableControls.Sorting.SortUserResults(viewModel.UserResults.TableControls.Sorting, viewModel.UserResults.TableControls.Paging, query);

            viewModel.UserResults.Results = await query.ToListAsync();
            return viewModel;
        }

        //
        // Create User

        public async Task<CreateUserViewModel> BuildCreateUserViewModel(CreateUserViewModel? viewModel = null)
        {
            if (viewModel == null)
            {
                viewModel = new CreateUserViewModel { User = new User() };
            }
            try
            {
                viewModel.UserTypeList = await _schoolDataApplicationDbContext.UserTypes.ToListAsync();
                viewModel.SchoolList = await _schoolDataApplicationDbContext.Schools.ToListAsync();
                viewModel.YearGroupList = await _schoolDataApplicationDbContext.YearGroups.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        //
        // Edit User
        public async Task<EditUserViewModel> BuildEditUserViewModel(int id, EditUserViewModel? viewModel = null)
        {
            var user = _schoolDataApplicationDbContext.Users.SingleOrDefault(u => u.UserId == id);
            
            if (viewModel == null)
            {
                viewModel = new EditUserViewModel { User = user };
            }
            try
            {
                viewModel.UserTypeList = await _schoolDataApplicationDbContext.UserTypes.ToListAsync();
                viewModel.SchoolList = await _schoolDataApplicationDbContext.Schools.ToListAsync();
                viewModel.YearGroupList = await _schoolDataApplicationDbContext.YearGroups.ToListAsync();
                //_mapper.Map(user, user);
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
            }
            catch (Exception ex)
            {
                throw ex;
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
