using FluentValidation;
using SchoolDataApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class CreateUserViewModelValidator: AbstractValidator<CreateUserViewModel>
    {
        public CreateUserViewModelValidator()
        {
            RuleFor(viewModel => viewModel.User).SetValidator(new UserValidator());
        }
    }
}
