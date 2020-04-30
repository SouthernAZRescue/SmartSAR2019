using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.Common.Application.Interfaces;
using SSar.BC.Common.Domain.ValueTypes;
using SSar.BC.MemberMgmt.Domain.Entities;

namespace SSar.BC.MemberMgmt.Application.Commands
{
    public class UpdateMemberCommand : IRequest
    {
        public MemberDto MemberDto { get; set; }

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
                    EntityId = request.MemberDto.EntityId,
                    Name = new PersonName()
                    {
                        First = request.MemberDto.FirstName,
                        Middle = request.MemberDto.MiddleName,
                        Last = request.MemberDto.LastName,
                        Nickname = request.MemberDto.Nickname
                    }
                });

                await _applicationDbContext.SaveChangesAsync(CancellationToken.None);

                return Unit.Value;
            }
        }

    }
}
