using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSar.BC.Common.Application.Interfaces;

namespace SSar.BC.MemberMgmt.Application.Queries
{
    public class GetMembersQuery : IRequest<IQueryable<MemberDto>>
    {
        public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, IQueryable<MemberDto>>
    
        {
            private readonly IApplicationDbContext _dbContext;
            public GetMembersQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<IQueryable<MemberDto>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
            {
                var members = _dbContext.Members.ToList();

                List<MemberDto> memberDtos = new List<MemberDto>();

                foreach (var member in members)
                {
                    memberDtos.Add(new MemberDto()
                    {
                        EntityId = member.EntityId,
                        FirstName = member.Name.First,
                        MiddleName = member.Name.Middle,
                        LastName = member.Name.Last,
                        Nickname = member.Name.Nickname
                    });
                }

                return memberDtos.AsQueryable();
            }
        }
    }
}
