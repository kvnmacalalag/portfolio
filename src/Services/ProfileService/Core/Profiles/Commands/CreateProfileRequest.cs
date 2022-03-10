using System.Threading;
using System.Threading.Tasks;
using Application.Shared.ViewModels;
using AutoMapper;
using MediatR;
using Portfolio.Application.Common.Models;
using Portfolio.Domain.Entities;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace ProfileService.Core.Profiles.Commands
{
    public class CreateProfileRequest :
        IRequest<BaseResponse<CreateRecordResponse<int>>>
    {
        public MyProfileVm Profile { get; set; }
    }

    public class CreateProfileRequestHandler :
        IRequestHandler<CreateProfileRequest, BaseResponse<CreateRecordResponse<int>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateProfileRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateRecordResponse<int>>> Handle(CreateProfileRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MyProfile>(request.Profile);

            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponse<CreateRecordResponse<int>>(
                new CreateRecordResponse<int>(entity.MyProfileId)
            );
        }
    }
}