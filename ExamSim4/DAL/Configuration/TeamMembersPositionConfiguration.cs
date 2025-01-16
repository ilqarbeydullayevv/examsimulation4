using ExamSim4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamSim4.DAL.Configuration
{
    public class TeamMembersPositionConfiguration : IEntityTypeConfiguration<TeamMembersPosition>
    {
        public void Configure(EntityTypeBuilder<TeamMembersPosition> builder)
        {
            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(10);
                
        }
    }
}
