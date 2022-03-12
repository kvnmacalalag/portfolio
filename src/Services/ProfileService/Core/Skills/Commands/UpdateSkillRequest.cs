
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Application.Common.Models;
using Portfolio.Application.Shared.ViewModels;
using Portfolio.Domain.Entities;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace Portfolio.ProfileService.Core.Skills.Commands
{
    public class UpdateSkillRequest :
        IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
        public SkillVm Skill { get; set; }
    }

    public class UpdateSkillRequestHandler :
        IRequestHandler<UpdateSkillRequest, BaseResponse<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateSkillRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(UpdateSkillRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Skills.FindAsync(request.Id);
            if (entity == null)
                throw new NotFoundException(nameof(Skill), request.Id);

            _mapper.Map(request.Skill, entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponse<int>(request.Id);
        }
    }
}