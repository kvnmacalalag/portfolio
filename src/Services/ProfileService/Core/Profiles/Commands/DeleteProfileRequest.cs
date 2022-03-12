using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Application.Common.Models;
using Portfolio.Domain.Entities;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace Portfolio.ProfileService.Core.Profiles.Commands
{
    public class DeleteProfileRequest :
        IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteProfileRequestHandler :
        IRequestHandler<DeleteProfileRequest, BaseResponse<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteProfileRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BaseResponse<int>> Handle(DeleteProfileRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.MyProfiles.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(MyProfile), request.Id);

            _context.Remove(entity);

            await _context.SaveChangesAsync();
            return new BaseResponse<int>(request.Id);
        }
    }
}