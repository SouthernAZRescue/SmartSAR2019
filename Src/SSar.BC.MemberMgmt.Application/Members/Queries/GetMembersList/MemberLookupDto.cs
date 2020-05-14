using System.ComponentModel.DataAnnotations;

namespace SSar.BC.MemberMgmt.Application.Members.Queries.GetMembersList
{
    public class MemberLookupDto
    {
        // Validation attributes are required for the SyncFusion validation system

        public int EntityId { get; set; }

        [Required(ErrorMessage = "A first name is required.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "A last name is required.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Nickname { get; set; }
    }
}
