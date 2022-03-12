using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Application.Common.Models;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace Portfolio.ProfileService.Core.Skills.Commands
{
    public class DeleteSkillRequest :
        IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSkillRequestHandler :
        IRequestHandler<DeleteSkillRequest, BaseResponse<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteSkillRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(DeleteSkillRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Skills.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(entity), request.Id);

            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponse<int>(request.Id);
        }
    }
}