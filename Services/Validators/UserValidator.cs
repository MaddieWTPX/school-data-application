using FluentValidation;
using SchoolDataApplication.Models;
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
            RuleFor(user => user.LastName).NotNull().WithMessage("Please enter last name");
            RuleFor(user => user.UserTypeId).NotNull().WithMessage("Please select user type");
        }
    }
}
