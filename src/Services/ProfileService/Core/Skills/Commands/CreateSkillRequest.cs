using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Portfolio.Application.Common.Models;
using Portfolio.Application.Shared.ViewModels;
using Portfolio.Domain.Entities;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace Portfolio.ProfileService.Core.Skills.Commands
{
    public class CreateSkillRequest :
        IRequest<BaseResponse<CreateRecordResponse<int>>>
    {
        public SkillVm Skill { get; set; }
    }
    public class CreateSkillRequestHandler :
        IRequestHandler<CreateSkillRequest, BaseResponse<CreateRecordResponse<int>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateSkillRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateRecordResponse<int>>> Handle(CreateSkillRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Skill>(request.Skill);

            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponse<CreateRecordResponse<int>>(
                new CreateRecordResponse<int>(entity.SkillId)
            );
        }
    }
}