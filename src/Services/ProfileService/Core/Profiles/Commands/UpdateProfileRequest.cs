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
    public class UpdateProfileRequest :
        IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
        public MyProfile MyProfile { get; set; }
    }

    public class UpdateProfileRequestHandler :
        IRequestHandler<UpdateProfileRequest, BaseResponse<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProfileRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(UpdateProfileRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.MyProfiles.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(MyProfile), request.Id);

            _mapper.Map(request.MyProfile, entity);

            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResponse<int>(request.Id);
        }
    }
}