using System.Collections.Generic;

namespace SSar.BC.MemberMgmt.Application.Queries
{
    public class MemberMgmtVm
    {
        public IEnumerable<MemberDto> Members { get; set; } 
            = new List<MemberDto>();
    }
}
