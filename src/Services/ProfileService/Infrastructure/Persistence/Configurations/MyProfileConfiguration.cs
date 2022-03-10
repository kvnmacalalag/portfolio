using Portfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.ProfileService.Infrastructure.Persistence.Configurations
{
    public class MyProfileConfiguration : IEntityTypeConfiguration<MyProfile>
    {
        public void Configure(EntityTypeBuilder<MyProfile> builder)
        {
            builder.ToTable("MyProfile");

            builder.Property(p => p.FirstName)
                .HasMaxLength(25);
            builder.Property(p => p.MiddleName)
                .HasMaxLength(25);
            builder.Property(p => p.LastName)
                .HasMaxLength(50);

        }
    }
}