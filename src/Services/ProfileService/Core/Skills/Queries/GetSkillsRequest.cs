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

namespace Portfolio.ProfileService.Core.Skills.Queries
{
    public class GetSkillsRequest : IRequest<List<SkillDto>>
    {
        public string Query { get; set; }
    }

    public class GetSkillsRequestHandler : IRequestHandler<GetSkillsRequest, List<SkillDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSkillsRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SkillDto>> Handle(GetSkillsRequest request, CancellationToken cancellationToken)
        {
            var queries = _context.Skills
                .OrderByDescending(p => p.Created)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(request.Query))
            {
                queries = queries.Where(p => p.Name.ToLower().Trim().Contains(request.Query.ToLower().Trim()) ||
                    p.Description.ToLower().Trim().Contains(request.Query.ToLower().Trim()));
            }

            return await queries
                .ProjectTo<SkillDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}