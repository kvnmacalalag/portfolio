using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Application.Common.Models;
using Portfolio.Application.Shared.ViewModels;
using Portfolio.Domain.Entities;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace Portfolio.ProfileService.Core.Contacts.Commands
{
    public class UpdateContactRequest : IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
        public ContactVm Contact { get; set; }
    }
    public class UpdateContactRequestHandler : IRequestHandler<UpdateContactRequest, BaseResponse<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateContactRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> Handle(UpdateContactRequest request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contacts.FindAsync(request.Id);

            if (entity == null) throw new NotFoundException(nameof(Contact), request.Id);

            _mapper.Map(request.Contact, entity);

            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResponse<int>(request.Id);
        }
    }
}