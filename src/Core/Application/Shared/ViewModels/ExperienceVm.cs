using System;
using Portfolio.Application.Common.Mappings;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Shared.ViewModels
{
    public class ExperienceVm : IMapFrom<Experience>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsPresent { get; set; }
    }
}