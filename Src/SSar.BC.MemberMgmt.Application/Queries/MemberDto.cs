using System;

namespace SSar.BC.MemberMgmt.Application.Queries
{
    public class MemberDto
    {
        public Guid MemberId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
    }
}
