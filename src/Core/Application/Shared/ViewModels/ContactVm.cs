using Portfolio.Application.Common.Mappings;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Shared.ViewModels
{
    public class ContactVm : IMapFrom<Contact>
    {
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}