using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSar.BC.MemberMgmt.Domain.Entities;

namespace SSar.BC.Common.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Member> Members { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}
