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

namespace Portfolio.ProfileService.Core.Experiences.Queries
{
    public class GetExperiencesRequest : IRequest<List<ExperienceDto>>
    {
        public string Query { get; set; }
    }

    public class GetExperiencesRequestHandler : IRequestHandler<GetExperiencesRequest, List<ExperienceDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetExperiencesRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ExperienceDto>> Handle(GetExperiencesRequest request, CancellationToken cancellationToken)
        {
            var queries = _context.Experiences
                .OrderByDescending(p => p.Created)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(request.Query))
            {
                queries = queries.Where(p =>
                    p.Name.ToLower().Trim().Contains(request.Query.ToLower().Trim()) ||
                    p.Description.ToLower().Trim().Contains(request.Query.ToLower().Trim()));
            }

            return await queries
                .ProjectTo<ExperienceDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}