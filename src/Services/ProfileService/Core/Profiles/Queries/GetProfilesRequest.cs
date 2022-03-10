using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Shared.DataObjects;
using Portfolio.Domain.Entities;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace ProfileService.Core.Profiles.Queries
{
    public class GetProfilesRequest : IRequest<List<MyProfileDto>>
    {
        public string Query { get; set; }
    }
    public class GetProfilesRequestHandler : IRequestHandler<GetProfilesRequest, List<MyProfileDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProfilesRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MyProfileDto>> Handle(GetProfilesRequest request, CancellationToken cancellationToken)
        {
            var queries = _context.MyProfiles
                .Include(p => p.Contact)
                .AsSingleQuery()
                .OrderByDescending(p => p.Created)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(request.Query))
            {
                queries = CreateFilter(queries, request);
            }

            return await queries
                .ProjectTo<MyProfileDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        private IQueryable<MyProfile> CreateFilter(IQueryable<MyProfile> queries, GetProfilesRequest request)
        {
            queries = queries.Where(p =>
                p.FirstName.ToLower().Trim().Contains(request.Query.ToLower().Trim()) ||
                p.MiddleName.ToLower().Trim().Contains(request.Query.ToLower().Trim()) ||
                p.LastName.ToLower().Trim().Contains(request.Query.ToLower().Trim()) ||
                p.FirstName.ToLower().Trim() + " " + p.LastName.ToLower().Trim() == request.Query.ToLower().Trim());


            return queries;
        }
    }
}