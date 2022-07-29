using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;
using Models.Constants;

namespace Models.ViewModels
{
    public class UserListViewModel
    {
        public UserListViewModel()
        {
            UserResults = new PagedResults<List<User>, ConstantStrings>
            {
                TableControls = new TableControls<ConstantStrings>
                {
                    Paging = new Paging(),
                    Sorting = new Sorting<ConstantStrings>
                    {
                        SortColumn = new ConstantStrings().FIRST_NAME,
                        SortDirection = "asc",
                        SortingFields = new ConstantStrings(),
                    }
                },
                Results = new List<User>()
            };

        }

        public UserListViewModel(Sorting<ConstantStrings> sorting, Paging paging)
        {
            UserResults = new PagedResults<List<User>, ConstantStrings>
            {
                TableControls = new TableControls<ConstantStrings>
                {
                    Paging = paging,
                    Sorting = sorting
                },
                Results = new List<User>()
            };
            sorting.SortingFields = new ConstantStrings();
            UserResults.TableControls.Sorting = sorting;
            UserResults.TableControls.Paging.CurrentPage = paging.CurrentPage;
        }

        public PagedResults<List<User>, ConstantStrings> UserResults { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? SelectedUserTypeId { get; set; }
        public int? SelectedSchoolId { get; set; }
        public int? SelectedYearGroupId { get; set; }
        public List<UserType> UserTypeList { get; set; }
        public List<School> SchoolList { get; set; }
        public List<YearGroup> YearGroupList { get; set; }
    }
}
