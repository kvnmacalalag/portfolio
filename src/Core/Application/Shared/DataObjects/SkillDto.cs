using Portfolio.Application.Common.Mappings;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Enums;

namespace Portfolio.Application.Shared.DataObjects
{
    public class SkillDto : IMapFrom<Skill>
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Level Level { get; set; }
        public int? MyProfileId { get; set; }
    }
}