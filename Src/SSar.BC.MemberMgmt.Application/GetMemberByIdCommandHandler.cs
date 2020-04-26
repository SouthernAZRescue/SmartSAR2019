using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSar.BC.Common.Application.Interfaces;
using SSar.BC.Common.Domain.ValueTypes;
using SSar.BC.MemberMgmt.Domain.Aggregates;

namespace SSar.BC.MemberMgmt.Application
{
    // TODO: Write tests after this is not longer just a fake prototype
    public class GetMemberByIdCommandHandler : IRequestHandler<GetMemberByIdCommand, Member>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetMemberByIdCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Member> Handle(GetMemberByIdCommand request, CancellationToken cancellationToken)
        {
            return await _dbContext.Members.FirstOrDefaultAsync();



            //return
            //    Task.Run(
            //        () =>
            //        {
            //            return 
            //                new Member(
            //                    new PersonName("Gaius", "Maximus", "Baltar", "Cylon Lover"));
            //        }
            //    );


        }
    }
}
