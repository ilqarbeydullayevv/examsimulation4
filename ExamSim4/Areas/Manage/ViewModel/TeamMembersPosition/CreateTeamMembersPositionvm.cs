using FluentValidation;

namespace ExamSim4.Areas.Manage.ViewModel.TeamMembersPosition
{
    public class CreateTeamMembersPositionvm
    {
        public string Name { get; set; }
    }

    public class CreateTeamMembersPositionValidator : AbstractValidator<CreateTeamMembersPositionvm>
    {
        public CreateTeamMembersPositionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("duzgun ad daxil edin zehmet olmasa")
                .MaximumLength(10)
                .MinimumLength(3)
                .WithMessage("adiniz minumum 3 maksimum 10 herifden ibaret olmalidi");
        }
    }
}
