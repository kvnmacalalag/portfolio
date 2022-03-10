using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Portfolio.Application.Common.Models;
using Portfolio.Application.Shared.ViewModels;
using Portfolio.Domain.Entities;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace Portfolio.ProfileService.Core.Experiences.Commands
{
    public class CreateExperienceRequest :
        IRequest<BaseResponse<CreateRecordResponse<int>>>
    {
        public ExperienceVm Experience { get; set; }
    }

    public class CreateExperienceRequestHandler :
        IRequestHandler<CreateExperienceRequest, BaseResponse<CreateRecordResponse<int>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateExperienceRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateRecordResponse<int>>> Handle(CreateExperienceRequest request,
             CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Experience>(request.Experience);

            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponse<CreateRecordResponse<int>>(
                    new CreateRecordResponse<int>(entity.ExperienceId));
        }
    }
}