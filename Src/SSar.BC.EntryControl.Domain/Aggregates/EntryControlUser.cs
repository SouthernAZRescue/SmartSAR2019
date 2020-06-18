using System;
using System.Collections.Generic;
using System.Text;
using SSar.BC.Common.Domain.ValueTypes;

namespace SSar.BC.EntryControl.Domain.Aggregates
{
    public class EntryControlUser
    {
        private string _firstName = "";
        private string _lastName = "";
        private int _appUserId = 0;    // User id for the web login acct
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
        public int AppUserId => _appUserId;
        public EmailAddress EmailAddress => _emailAddress;
        public PhoneNumber PhoneNumber => _phoneNumber;
        public string Comments => _comments;
    }
}
