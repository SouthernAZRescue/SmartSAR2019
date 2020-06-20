using System;
using SSar.BC.Common.Domain.BaseTypes;
using SSar.BC.Common.Domain.ValueTypes;

namespace SSar.BC.EntryControl.Domain.Aggregates
{
    public class EntryControlUser : AggregateRootBase
    {
        private string _firstName = "";
        private string _lastName = "";
        private Guid _appUserId = Guid.Empty;
        private EmailAddress _emailAddress = new EmailAddress();
        private PhoneNumber _phoneNumber = new PhoneNumber();
        private string _comments = "";

        public EntryControlUser(EntryControlUserBuilder builder)
        {
            _firstName = builder.FirstName;
            _lastName = builder.LastName;
            _appUserId = builder.AppUserId;
            _emailAddress = builder.EmailAddress;
            _phoneNumber = builder.PhoneNumber;
            _comments = builder.Comments;
        }

        public string FirstName => _firstName;
        public string LastName => _lastName;
        public Guid AppUserId => _appUserId;
        public EmailAddress EmailAddress => _emailAddress;
        public PhoneNumber PhoneNumber => _phoneNumber;
        public string Comments => _comments;
    }
}
