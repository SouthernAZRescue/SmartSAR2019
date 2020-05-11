using System.Collections.Generic;

namespace SSar.BC.MemberMgmt.Application.Members.Queries.GetMembersList
{
    public class MembersListVm
    {
        public IList<MemberLookupDto> Members { get; set; } 
            = new List<MemberLookupDto>();
    }
}
