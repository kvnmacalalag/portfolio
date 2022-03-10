using Portfolio.Domain.Common;
using Portfolio.Domain.Enums;

namespace Portfolio.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Level Level { get; set; }

        public int? MyProfileId { get; set; }
        public MyProfile MyProfile { get; set; }
    }
}