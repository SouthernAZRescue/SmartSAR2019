using Xunit;
using Shouldly;
using SSar.BC.EntryControl.Domain.Aggregates;
using SSar.BC.Common.Domain.ValueTypes;

namespace SSar.BC.EntryControl.UnitTests.Domain
{
    public class EntryControlUserTests
    {
        [Fact]
        public void ECUser_Ctor_ShouldSetAllPropsFromBuilder()
        {
            //var builder = new EntryControlUserBuilder
            //{
            //    FirstName = "First",
            //    LastName = "Last",
            //    AppUserId = 42,
            //    EmailAddress = new EmailAddress{ Address = "sleepy@sietehombres.com" },
            //    PhoneNumber = new PhoneNumber { Number = "111-222-3333"},
            //    Comments = "Nothing to see here, move along."
            //};

            var firstName = "First";
            var lastName = "Last";
            var appUserId = 42;
            var phoneNumber = new PhoneNumber { Number = "111-222-3333" };
            var emailAddress = new EmailAddress { Address = "sleepy@sietrehombres.com" };
            var comments = "Nothing to see here, move along.";

            var builder = new EntryControlUserBuilder()
                .CreateEntryControlUser(firstName, lastName)
                .WithAppUserId(appUserId)
                .WithPhoneNumber(phoneNumber)
                .WithEmailAddress(emailAddress)
                .WithComments(comments);

            var ecUser = new EntryControlUser(builder);

            ecUser.ShouldSatisfyAllConditions(
                () => ecUser.FirstName.ShouldBe(firstName),
                () => ecUser.LastName.ShouldBe(lastName),
                () => ecUser.AppUserId.ShouldBe(appUserId),
                () => ecUser.PhoneNumber.Number.ShouldBe(phoneNumber),
                () => ecUser.EmailAddress.Address.ShouldBe(emailAddress),
                () => ecUser.Comments.ShouldBe(comments));
        }
    }
}
