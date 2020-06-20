using SSar.BC.Common.Domain.ValueTypes;
using System;

namespace SSar.BC.EntryControl.Domain.Aggregates
{
    public class EntryControlUserBuilder
    {
        private string _firstName;
        private string _lastName = "";
        private Guid _appUserId = Guid.NewGuid();
        private EmailAddress _emailAddress = new EmailAddress();
        private PhoneNumber _phoneNumber = new PhoneNumber();
        private string _comments = "";

        public string FirstName => _firstName;
        public string LastName => _lastName;
        public Guid AppUserId => _appUserId;
        public EmailAddress EmailAddress => _emailAddress;
        public PhoneNumber PhoneNumber => _phoneNumber;
        public string Comments => _comments;


        public EntryControlUserBuilder CreateEntryControlUser(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;

            return this;
        }

        public EntryControlUserBuilder WithAppUserId(Guid appUserId)
        {
            _appUserId = appUserId;

            return this;
        }

        public EntryControlUserBuilder WithEmailAddress(EmailAddress emailAddress)
        {
            _emailAddress = emailAddress;

            return this;
        }

        public EntryControlUserBuilder WithPhoneNumber(PhoneNumber phoneNumber)
        {
            _phoneNumber = phoneNumber;

            return this;
        }

        public EntryControlUserBuilder WithComments(string comments)
        {
            _comments = comments;

            return this;
        }

        public EntryControlUser Build()
        {
            // Uses implicit operator to new up an EntryControlUser
            return (EntryControlUser)this;
        }

        public static implicit operator EntryControlUser(EntryControlUserBuilder builder)
        {
            return new EntryControlUser(builder);
        }
    }
}
