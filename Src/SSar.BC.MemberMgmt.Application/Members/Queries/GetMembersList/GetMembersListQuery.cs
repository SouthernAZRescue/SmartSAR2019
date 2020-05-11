using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.Common.Application.Interfaces;
using SSar.BC.MemberMgmt.Application.Members.Queries.GetMemberDetails;

namespace SSar.BC.MemberMgmt.Application.Members.Queries.GetMembersList
{
    public class GetMembersListQuery : IRequest<MembersListVm>
    {
        public class GetMembersListQueryHandler : IRequestHandler<GetMembersListQuery, MembersListVm>
    
        {
            private readonly IApplicationDbContext _dbContext;
            public GetMembersListQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<MembersListVm> Handle(GetMembersListQuery request, CancellationToken cancellationToken)
            {
                    MembersListVm membersList = new MembersListVm();

                    foreach (var member in _dbContext.Members)
                    {
                        membersList.Members.Add(new MemberLookupDto()
                        {
                            EntityId = member.EntityId,
                            FirstName = member.Name.First,
                            MiddleName = member.Name.Middle,
                            LastName = member.Name.Last,
                            Nickname = member.Name.Nickname
                        });
                    }

                    return Task.FromResult(membersList);
            }
        }
    }
}
