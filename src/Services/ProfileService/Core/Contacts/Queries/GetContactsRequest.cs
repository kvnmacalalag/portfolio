using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Shared.DataObjects;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace Portfolio.ProfileService.Core.Contacts.Queries
{
    public class GetContactsRequest : IRequest<List<ContactDto>>
    {
        public string Query { get; set; }
    }

    public class GetContactsRequestHandler : IRequestHandler<GetContactsRequest, List<ContactDto>>
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetContactsRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ContactDto>> Handle(GetContactsRequest request, CancellationToken cancellationToken)
        {
            var queries = _context.Contacts
                .OrderByDescending(p => p.Created)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(request.Query))
            {
                queries = queries.Where(p =>
                    p.Address.ToLower().Trim().Contains(request.Query.ToLower().Trim()) ||
                    p.ContactNumber.ToLower().Trim().Contains(request.Query.ToLower().Trim()) ||
                    p.EmailAddress.ToLower().Trim().Contains(request.Query.ToLower().Trim()));
            }

            return await queries
                .ProjectTo<ContactDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}