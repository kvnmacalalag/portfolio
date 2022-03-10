using System.Threading;
using System.Threading.Tasks;
using Portfolio.Application.Common.Interfaces;
using Portfolio.Domain.Common;
using Portfolio.Domain.Entities;
using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Portfolio.ProfileService.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private static DbContextHelper _helper = new();
        private readonly IAuditDbContext _auditContext;
        private readonly IDateTimeService _dateTimeService;
        public DbSet<MyProfile> MyProfiles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IDateTimeService dateTimeService)
            : base(options)
        {
            _dateTimeService = dateTimeService;
            _auditContext = new DefaultAuditContext(this);
            _helper.SetConfig(_auditContext);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AuditRecord();
            var result = await _helper.SaveChangesAsync(_auditContext,
                () => base.SaveChangesAsync(cancellationToken));

            return result;
        }

        public void AuditRecord()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTimeService.Now;
                        entry.Entity.CreatedBy = "dev";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTimeService.Now;
                        entry.Entity.ModifiedBy = "dev";
                        break;
                }
            }
        }
    }
}