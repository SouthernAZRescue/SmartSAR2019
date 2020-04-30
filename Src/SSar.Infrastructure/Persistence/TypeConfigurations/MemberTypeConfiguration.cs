using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSar.BC.Common.Domain.ValueTypes;
using SSar.BC.MemberMgmt.Domain.Entities;

namespace SSar.Infrastructure.Persistence.TypeConfigurations
{
    public class MemberTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(b => b.EntityId);

            builder.OwnsOne(
                b => b.Name,
                name =>
                {
                    name.Property(x => x.First).HasColumnName("First");
                    name.Property(x => x.Middle).HasColumnName("Middle");
                    name.Property(x => x.Last).HasColumnName("Last");
                    name.Property(x => x.Nickname).HasColumnName("Nickname");
                });
        }
    }
}
