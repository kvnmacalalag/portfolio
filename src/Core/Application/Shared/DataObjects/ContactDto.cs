using Portfolio.Application.Common.Mappings;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Shared.DataObjects
{
    public class ContactDto : IMapFrom<Contact>
    {
        public int ContactId { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}