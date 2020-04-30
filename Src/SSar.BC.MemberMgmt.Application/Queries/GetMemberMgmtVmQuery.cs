using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSar.BC.Common.Application.Interfaces;

namespace SSar.BC.MemberMgmt.Application.Queries
{
    public class GetMemberMgmtVmQuery : IRequest<MemberMgmtVm>
    {
        public class GetMembersQueryHandler : IRequestHandler<GetMemberMgmtVmQuery, MemberMgmtVm>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetMembersQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<MemberMgmtVm> Handle(GetMemberMgmtVmQuery request, CancellationToken cancellationToken)
            {
                var members = await _dbContext.Members.ToListAsync();
                List<MemberDto> memberDtos = new List<MemberDto>();

                foreach (var member in _dbContext.Members)
                {
                    memberDtos.Add(new MemberDto
                    {
                        EntityId = member.EntityId,
                        FirstName = member.Name.First,
                        MiddleName = member.Name.Middle,
                        LastName = member.Name.Last,
                        Nickname = member.Name.Nickname
                    });
                }

                return new MemberMgmtVm {Members = memberDtos};
            }
        }
    }
}
