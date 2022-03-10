using System.Collections.Generic;
using Portfolio.Application.Common.Mappings;
using Portfolio.Application.Shared.ViewModels;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Enums;

namespace Application.Shared.ViewModels
{
    public class MyProfileVm : IMapFrom<MyProfile>
    {
        public MyProfileVm()
        {
            Skills = new List<SkillVm>();
            Experiences = new List<ExperienceVm>();
        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int? ContactId { get; set; }

        public List<SkillVm> Skills { get; set; }
        public List<ExperienceVm> Experiences { get; set; }
    }
}