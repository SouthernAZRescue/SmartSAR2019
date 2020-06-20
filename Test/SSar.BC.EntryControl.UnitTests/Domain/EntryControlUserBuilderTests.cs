using Shouldly;
using SSar.BC.Common.Domain.ValueTypes;
using SSar.BC.EntryControl.Domain.Aggregates;
using System;
using Xunit;

namespace SSar.BC.EntryControl.UnitTests.Domain
{
    public class EntryControlUserBuilderTests
    {
        [Fact]
        public void ECUBuilder_ImplicitOperatorReturnsEntryControlUser()
        {
            var builder = new EntryControlUserBuilder();

            EntryControlUser ecUser = builder.CreateEntryControlUser("Bob", "George");

            ecUser.ShouldBeOfType<EntryControlUser>();
        }

        [Fact]
        public void Ctor_ShouldSetNonEmptyAppUserId()
        {
            var builder = new EntryControlUserBuilder();

            builder.AppUserId.ShouldNotBe(Guid.Empty);
        }

        [Fact]
        public void CreateEntryControlUser_ShouldSetNameProperties()
        {
            var firstName = "Boy";
            var lastName = "George";

            var builder = new EntryControlUserBuilder();

            builder.CreateEntryControlUser(firstName, lastName);

            builder.ShouldSatisfyAllConditions(
                () => builder.FirstName.ShouldBe(firstName),
                () => builder.LastName.ShouldBe(lastName));
        }

        [Fact]
        public void WithAppUserId_ShouldSetProperty()
        {
            var appUserId = Guid.NewGuid();

            var builder = new EntryControlUserBuilder()
                .WithAppUserId(appUserId);

            builder.AppUserId.ShouldBe(appUserId);
        }

        [Fact]
        public void WithEmailAddress_ShouldSetProperty()
        {
            var emailAddress = new EmailAddress();

            var builder = new EntryControlUserBuilder()
                .WithEmailAddress(emailAddress);

            builder.EmailAddress.ShouldBe(emailAddress);
        }

        [Fact]
        public void WithPhoneNumber_ShouldSetProperty()
        {
            var phoneNumber = new PhoneNumber();

            var builder = new EntryControlUserBuilder()
                .WithPhoneNumber(phoneNumber);

            builder.PhoneNumber.ShouldBe(phoneNumber);
        }

        [Fact]
        public void WithComments_ShouldSetProperty()
        {
            var comment = "A swell strudeler yodeler.";

            var builder = new EntryControlUserBuilder()
                .WithComments(comment);

            builder.Comments.ShouldBe(comment);
        }

        [Fact]
        public void Build_ShouldReturnPopulatedECUser()
        {
            var firstName = "Freddie";
            var lastName = "Mac";

            var ecUser = new EntryControlUserBuilder()
                .CreateEntryControlUser(firstName, lastName)
                .Build();

            ecUser.FirstName.ShouldBe(firstName);
        }
    }
}
