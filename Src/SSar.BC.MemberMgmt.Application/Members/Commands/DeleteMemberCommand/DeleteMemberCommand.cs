using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSar.BC.Common.Application.Interfaces;

namespace SSar.BC.MemberMgmt.Application.Members.Commands.DeleteMemberCommand
{
    public class DeleteMemberCommand : IRequest
    {
        public int EntityId { get; set; }

        public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public DeleteMemberCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Unit> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
            {
                var member = await  _applicationDbContext.Members.Where(m => m.EntityId == request.EntityId)
                    .FirstOrDefaultAsync();
                _applicationDbContext.Members.Remove(member);
                await _applicationDbContext.SaveChangesAsync(CancellationToken.None);

                return Unit.Value;
            }
        }
    }
}
