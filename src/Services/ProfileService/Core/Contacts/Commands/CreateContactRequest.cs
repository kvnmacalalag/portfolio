using System.Threading;
using System.Threading.Tasks;
using Portfolio.Application.Common.Models;
using Portfolio.Application.Shared.DataObjects;
using Portfolio.Application.Shared.ViewModels;
using AutoMapper;
using Portfolio.Domain.Entities;
using MediatR;
using Portfolio.ProfileService.Infrastructure.Persistence;

namespace Portfolio.ProfileService.Core.Contacts.Commands
{
    public class CreateContactRequest :
        IRequest<BaseResponse<CreateRecordResponse<int>>>
    {
        public ContactVm Contact { get; set; }
    }
    public class CreateContactRequestHandler : 
        IRequestHandler<CreateContactRequest, BaseResponse<CreateRecordResponse<int>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateContactRequestHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateRecordResponse<int>>> Handle(CreateContactRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Contact>(request.Contact);

            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResponse<CreateRecordResponse<int>>(
                    new CreateRecordResponse<int>(entity.ContactId));
        }
    }
}