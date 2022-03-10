
using Portfolio.Domain.Common;

namespace Portfolio.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public int ContactId { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}