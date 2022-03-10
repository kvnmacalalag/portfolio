using System.Collections.Generic;
using Portfolio.Application.Common.Mappings;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Enums;

namespace Portfolio.Application.Shared.DataObjects
{
    public class MyProfileDto : IMapFrom<MyProfile>
    {
        public MyProfileDto()
        {
            Skills = new HashSet<SkillDto>();
            Experiences = new HashSet<ExperienceDto>();
        }
        public int MyProfileId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public int? ContactId { get; set; }
        public ContactDto Contact { get; set; }
        public ICollection<SkillDto> Skills { get; set; }
        public ICollection<ExperienceDto> Experiences { get; set; }
    }
}