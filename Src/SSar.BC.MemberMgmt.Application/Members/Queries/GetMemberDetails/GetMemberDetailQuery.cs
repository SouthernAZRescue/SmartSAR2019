using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSar.BC.Common.Application.Interfaces;
using SSar.BC.MemberMgmt.Application.Members.Queries.GetMembersList;

namespace SSar.BC.MemberMgmt.Application.Members.Queries.GetMemberDetails
{
    public class GetMemberDetailQuery : IRequest<MemberLookupDto>
    {
        public int EntityId { get; set; }

        public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberDetailQuery, MemberLookupDto>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetMemberByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<MemberLookupDto> Handle(GetMemberDetailQuery request, CancellationToken cancellationToken)
            {
                var member = await _dbContext.Members.FirstOrDefaultAsync();

                var memberDto = new MemberLookupDto
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
