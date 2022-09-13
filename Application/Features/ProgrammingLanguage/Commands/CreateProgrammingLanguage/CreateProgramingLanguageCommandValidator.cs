using FluentValidation;

namespace Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage
{
    public class CreateProgramingLanguageCommandValidator : AbstractValidator<CreateProgramingLanguageCommand>
    {
        public CreateProgramingLanguageCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MinimumLength(2);
        }
    }
}
