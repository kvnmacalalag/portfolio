using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Application.Common.Models;
using Portfolio.Domain.Entities;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace Portfolio.ProfileService.Core.Experiences.Commands
{
    public class DeleteExperienceRequest :
        IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteExperienceRequestHandler :
         IRequestHandler<DeleteExperienceRequest, BaseResponse<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteExperienceRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(DeleteExperienceRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Experiences.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Experience), request.Id);
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponse<int>(request.Id);
        }
    }
}