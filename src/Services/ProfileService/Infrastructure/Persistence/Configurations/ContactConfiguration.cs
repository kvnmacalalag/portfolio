using Portfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.ProfileService.Infrastructure.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");

            builder.Property(p => p.Address)
                .HasMaxLength(125);
            builder.Property(p => p.ContactNumber)
               .HasMaxLength(16);
            builder.Property(p => p.EmailAddress)
               .HasMaxLength(50);
        }
    }
}