using Portfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.ProfileService.Infrastructure.Persistence.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("Experience");

            builder.Property(p => p.Name)
                .HasMaxLength(50);
            builder.Property(p => p.Description)
                .HasMaxLength(255);
        }
    }
}