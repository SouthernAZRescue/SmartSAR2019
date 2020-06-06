using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSar.Infrastructure.Identity;

namespace SSar.Infrastructure.Persistence.TypeConfigurations
{
    internal class AppUserTypeConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users");

            // Seeding User data requires an API call after the database has been
            // created, so will be done at a later stage in the app startup.
        }
    }
}
