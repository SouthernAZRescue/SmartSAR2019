using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SSar.BC.Common.Application.Interfaces;
using SSar.BC.Common.Domain.ValueTypes;
using SSar.BC.MemberMgmt.Domain.Entities;

namespace SSar.BC.MemberMgmt.Application.Queries
{
    public class AddMemberCommand : IRequest<int>
    {
        public MemberDto MemberDto { get; set; }

        public class AddMemberCommandHandler : IRequestHandler<AddMemberCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;

            public AddMemberCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<int> Handle(AddMemberCommand request, CancellationToken cancellationToken)
            {
                _dbContext.Members.AddAsync(new Member()
                {
                    Name = new PersonName()
                    {
                        First = request.MemberDto.FirstName,
                        Middle = request.MemberDto.MiddleName,
                        Last = request.MemberDto.LastName,
                        Nickname = request.MemberDto.Nickname
                    }
                });

                return _dbContext.SaveChangesAsync(CancellationToken.None);
            }
        }
    }
}
