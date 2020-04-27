namespace SSar.BC.MemberMgmt.Application.Queries
{
    public class MemberDto
    {
        /// <summary>
        /// Parameterless constructor required for deserialization
        /// </summary>
        public MemberDto()
        {
        }

        public MemberDto(string firstName, string middleName, string lastName, string nickname)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Nickname = nickname;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
    }
}
