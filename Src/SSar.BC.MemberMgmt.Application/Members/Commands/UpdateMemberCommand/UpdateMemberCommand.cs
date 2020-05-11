using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.Common.Application.Interfaces;
using SSar.BC.Common.Domain.ValueTypes;
using SSar.BC.MemberMgmt.Domain.Entities;

namespace SSar.BC.MemberMgmt.Application.Members.Commands.UpdateMemberCommand
{
    public class UpdateMemberCommand : IRequest
    {
        public int EntityId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public UpdateMemberCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Unit> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
            {
                _applicationDbContext.Members.Update(new Member()
                {
                    EntityId = request.EntityId,
                    Name = new PersonName()
                    {
                        First = request.FirstName,
                        Middle = request.MiddleName,
                        Last = request.LastName,
                        Nickname = request.Nickname?.Length > 0
                                   ? request.Nickname
                                   : request.FirstName
                    }
                });

                await _applicationDbContext.SaveChangesAsync(CancellationToken.None);

                return Unit.Value;
            }
        }
    }
}
