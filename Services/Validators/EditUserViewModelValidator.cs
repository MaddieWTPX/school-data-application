using FluentValidation;
using Models.Entities.ViewModels;

namespace Services.Validators
{
    public class EditUserViewModelValidator : AbstractValidator<EditUserViewModel>
    {
        public EditUserViewModelValidator()
        {
            RuleFor(viewModel => viewModel.User).SetValidator(new UserValidator());
        }
    }
}
