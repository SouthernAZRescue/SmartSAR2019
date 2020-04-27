using System;
using MediatR;
using SSar.BC.MemberMgmt.Domain.Entities;

namespace SSar.BC.MemberMgmt.Application.Queries
{
    public class GetMemberByIdQuery : IRequest<Member>
    {
        public GetMemberByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
