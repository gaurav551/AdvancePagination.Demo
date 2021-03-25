using AdvancePagination.Demo.Models;
using FluentValidation;

namespace AdvancePagination.Demo.Validation
{
  public class PostValidator : AbstractValidator<Post>
    {
        [System.Obsolete]
        public PostValidator()
        {
            {
            RuleFor(p => p.Title)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .Length(2, 25).WithMessage("Must be 2 to 25");
              
            RuleFor(p => p.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .Length(10, 25).WithMessage("Must be 10 to 25");
            RuleFor(p => p.CreatedBy)
                .EmailAddress();
        }
        }
    }
}