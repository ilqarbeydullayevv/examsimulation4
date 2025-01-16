using ExamSim4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamSim4.DAL.Configuration
{
    public class TeamMembersConfiguration : IEntityTypeConfiguration<TeamMembers>
    {
        public void Configure(EntityTypeBuilder<TeamMembers> builder)
        {
            builder.Property(x => x.FullName).IsRequired()
                .HasMaxLength(15);

            builder.HasOne(x => x.position)
                .WithMany(u => u.Members);
        }
    }
}
