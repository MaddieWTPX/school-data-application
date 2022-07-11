using FluentValidation;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotNull().WithMessage("Please enter first name");
            RuleFor(user => user.FirstName).Length(3, 20);
            RuleFor(user => user.LastName).NotNull().WithMessage("Please enter last name");
            RuleFor(user => user.LastName).Length(3, 30);
            RuleFor(user => user.UserTypeId).NotNull().WithMessage("Please select user type");
            RuleFor(user => user.SchoolId).NotNull().WithMessage("Please select school");

            // optional fields (UserTypeId #2 = Student)
            When(user => user.UserTypeId == 2, () =>
            {
                RuleFor(user => user.YearGroupId)
                .NotNull()
                .WithMessage("Please select year group");
            });

            When(user => user.UserTypeId == 2, () =>
            {
                RuleFor(user => user.DateOfBirth)
                                .NotNull()
                                .WithMessage("Please enter date of birth");
                RuleFor(user => user.DateOfBirth)
                .Must(AgeValidate)
                .WithMessage("You must be aged between 4 and 18");
            });


        }
    private bool AgeValidate(DateTime? date)
    {
        DateTime now = DateTime.Today;
        int age = now.Year - Convert.ToDateTime(date).Year;
        bool result = age >= 4 && age <= 18 ? true : false;
        return result;
    }
}
}
