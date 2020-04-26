using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSar.BC.MemberMgmt.Domain.Aggregates;

namespace SSar.Infrastructure.Persistence.TypeConfigurations
{
    public class MemberTypeConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(b => b.Id).HasField("_id");

            builder.OwnsOne(b => b.Name);
        }
    }
}
