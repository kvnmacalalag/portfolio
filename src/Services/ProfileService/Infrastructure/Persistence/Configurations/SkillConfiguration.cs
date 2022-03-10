using Portfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.ProfileService.Infrastructure.Persistence.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skill");

            builder.Property(p => p.Name)
                .HasMaxLength(55);
            builder.Property(p => p.Description)
                .HasMaxLength(255);
        }
    }
}