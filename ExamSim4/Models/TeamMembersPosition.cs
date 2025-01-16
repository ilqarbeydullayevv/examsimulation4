using ExamSim4.Models.Base;

namespace ExamSim4.Models
{
    public class TeamMembersPosition : BaseEntity
    {
        public string Name { get; set; }
        public List<TeamMembers> Members { get; set; }

    }
}
