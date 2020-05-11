namespace SSar.BC.MemberMgmt.Application.Members.Queries.GetMembersList
{
    public class MemberLookupDto
    {
        public int EntityId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
    }
}
