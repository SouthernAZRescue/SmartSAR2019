using System.Collections.Generic;

namespace SSar.BC.MemberMgmt.Application.Members.Queries.GetMembersList
{
    /// <summary>
    /// Viewmodel that contains a list of members.
    /// </summary>
    public class MembersListVm
    {
        /// <summary>
        /// List of members
        /// </summary>
        public IList<MemberLookupDto> Members { get; set; } 
            = new List<MemberLookupDto>();
    }
}
