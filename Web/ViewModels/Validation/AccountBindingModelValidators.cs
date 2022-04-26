using FluentValidation;

namespace Web.ViewModels.Validation
{
    /// <summary>
    /// RegisterBindingModelValidator
    /// </summary>
    public class RegisterBindingModelValidator : AbstractValidator<RegisterBindingModel>
    {
        /// <summary>
        /// RegisterBindingModelValidator
        /// </summary>
        public RegisterBindingModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty().Length(3, 100);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}