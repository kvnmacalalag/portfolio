using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Application.Common.Models;
using Portfolio.Domain.Entities;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace Portfolio.ProfileService.Core.Contacts.Commands
{
    public class DeleteContactRequest :
        IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteContactRequestHandler :
        IRequestHandler<DeleteContactRequest, BaseResponse<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteContactRequestHandler(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<BaseResponse<int>> Handle(DeleteContactRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contacts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), request.Id);
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResponse<int>(request.Id);
        }
    }
}