using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.Common.Application.Interfaces;
using SSar.BC.Common.Domain.ValueTypes;
using SSar.BC.MemberMgmt.Application.Members.Queries.GetMembersList;
using SSar.BC.MemberMgmt.Domain.Entities;

namespace SSar.BC.MemberMgmt.Application.Members.Commands.CreateMemberCommand
{
    public class CreateMemberCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateMemberCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<int> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
            {
                await _dbContext.Members.AddAsync(new Member()
                {
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

                return await _dbContext.SaveChangesAsync(CancellationToken.None);
            }
        }
    }
}
