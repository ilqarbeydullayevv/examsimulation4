using ExamSim4.Models.Base;

namespace ExamSim4.Models
{
    public class TeamMembers : BaseEntity
    {
        public string FullName { get; set; }
        public int TeamMembersPositionId { get; set; }
        public TeamMembersPosition position { get; set; }
        public string ImgUrl { get; set; }

    }
}
