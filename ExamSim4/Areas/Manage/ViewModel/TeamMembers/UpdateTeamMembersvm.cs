﻿namespace ExamSim4.Areas.Manage.ViewModel.TeamMembers
{
    public class UpdateTeamMembersvm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int TeamMembersPositionId { get; set; }
        public IFormFile MyFile { get; set; }

    }
}