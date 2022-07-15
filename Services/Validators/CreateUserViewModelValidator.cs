using FluentValidation;
using Models.ViewModels;

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
