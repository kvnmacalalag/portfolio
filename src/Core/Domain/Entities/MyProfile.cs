using System.Collections.Generic;
using Portfolio.Domain.Common;
using Portfolio.Domain.Enums;

namespace Portfolio.Domain.Entities
{
    public class MyProfile : BaseEntity
    {
        public MyProfile()
        {
            Skills = new HashSet<Skill>();
            Experiences = new HashSet<Experience>();
        }

        public int MyProfileId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int? ContactId { get; set; }
        public Contact Contact { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Experience> Experiences { get; set; }
    }
}