using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using SSar.BC.MemberMgmt.Domain.Aggregates;

namespace SSar.BC.MemberMgmt.Application
{
    public class GetMemberByIdCommand : IRequest<Member>
    {
        public GetMemberByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
