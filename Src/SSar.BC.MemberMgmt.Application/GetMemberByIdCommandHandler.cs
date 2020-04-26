using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SSar.BC.Common.Domain.ValueTypes;
using SSar.BC.MemberMgmt.Domain.Aggregates;

namespace SSar.BC.MemberMgmt.Application
{
    // TODO: Write tests after this is not longer just a fake prototype
    public class GetMemberByIdCommandHandler : IRequestHandler<GetMemberByIdCommand, Member>
    {
        public Task<Member> Handle(GetMemberByIdCommand request, CancellationToken cancellationToken)
        {
            return
                Task.Run(
                    () =>
                    {
                        return 
                            new Member(
                                new PersonName("Gaius", "Maximus", "Baltar", "Cylon Lover"));
                    }
                );
                
                
        }
    }
}
