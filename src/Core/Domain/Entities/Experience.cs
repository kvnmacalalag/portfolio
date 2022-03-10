using System;
using Portfolio.Domain.Common;

namespace Portfolio.Domain.Entities
{
    public class Experience : BaseEntity
    {
        public int ExperienceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsPresent { get; set; }
        public int? MyProfileId { get; set; }
        public MyProfile MyProfile { get; set; }
    }
}