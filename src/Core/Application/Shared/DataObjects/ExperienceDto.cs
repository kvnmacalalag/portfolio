
using System;
using Portfolio.Application.Common.Mappings;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Shared.DataObjects
{

    public class ExperienceDto : IMapFrom<Experience>
    {
        public int ExperienceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsPresent { get; set; }
        public int? MyProfileId { get; set; }
    }
}