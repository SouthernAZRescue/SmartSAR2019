using System;
using MediatR;
using SSar.BC.MemberMgmt.Domain.Entities;

namespace SSar.BC.MemberMgmt.Application.Queries
{
    public class GetMemberByIdQuery : IRequest<MemberDto>
    {
        public GetMemberByIdQuery(int entityId)
        {
            EntityId = entityId;
        }

        public int EntityId { get; }
    }
}
