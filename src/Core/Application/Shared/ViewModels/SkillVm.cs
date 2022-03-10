using Portfolio.Application.Common.Mappings;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Enums;

namespace Portfolio.Application.Shared.ViewModels
{
    public class SkillVm : IMapFrom<Skill>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Level Level { get; set; }
    }
}