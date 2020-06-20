using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSar.BC.MemberMgmt.Domain.Entities;
using SSar.Infrastructure.Identity;

namespace SSar.Infrastructure.Persistence.TypeConfigurations
{
    internal class AppRoleTypeConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(b => b.Id);

            // Aggregate rood IDs are assigned on construction
            builder.Property("Id").ValueGeneratedNever();

            builder.HasData(
                new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Super Admin",
                    ConcurrencyStamp = "new",
                    NormalizedName = "SUPER ADMIN"
                },
                new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "App Security Admin",
                    ConcurrencyStamp = "new",
                    NormalizedName = "APP SECURITY ADMIN"
                },
                new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Member Data Admin",
                    ConcurrencyStamp = "new",
                    NormalizedName = "MEMBER RECORDS ADMIN"
                },
                new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Organization Member",
                    ConcurrencyStamp = "new",
                    NormalizedName = "ORGANIZATION MEMBER"
                },
                new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Affiliate User",
                    ConcurrencyStamp = "new",
                    NormalizedName = "AFFILIATE USER"
                },
                new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Guest User",
                    ConcurrencyStamp = "new",
                    NormalizedName = "GUEST USER"
                });
        }
    }
}
