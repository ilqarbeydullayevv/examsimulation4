using FluentValidation;

namespace ExamSim4.Areas.Manage.ViewModel.TeamMembers
{
    public class CreateTeamMembersvm
    {
        public string FullName { get; set; }
        public int TeamMembersPositionId { get; set; }
        public IFormFile MyFile { get; set; }
    }
    public class  CreatTeamMembersValidator : AbstractValidator<CreateTeamMembersvm>
    {
        public CreatTeamMembersValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("duzgun ad daxil edin")
                .MinimumLength(3)
                .MaximumLength(15)
                .WithMessage("adiniz maksimum 15 minumum 3 herifden ibaret olmalidir");

            
                 
        }
    }
}
