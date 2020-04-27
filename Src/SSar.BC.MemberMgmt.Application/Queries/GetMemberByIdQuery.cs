using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSar.BC.Common.Application.Interfaces;
using SSar.BC.MemberMgmt.Domain.Entities;

namespace SSar.BC.MemberMgmt.Application.Queries
{
    public class GetMemberByIdQuery : IRequest<MemberDto>
    {
        public GetMemberByIdQuery(int entityId)
        {
            EntityId = entityId;
        }

        public int EntityId { get; }


        // TODO: Write tests after this is not longer just a fake prototype
        public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, MemberDto>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetMemberByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<MemberDto> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
            {
                // TODO: FINISH PROTOTYPE - This is a stub and only returns the first member in the table

                var member = await _dbContext.Members.FirstOrDefaultAsync();

                var memberDto = new MemberDto
                {
                    EntityId = member.EntityId,
                    FirstName = member.Name.First,
                    MiddleName = member.Name.Middle,
                    LastName = member.Name.Last,
                    Nickname = member.Name.Nickname
                };

                return memberDto;
            }
        }
    }
}
