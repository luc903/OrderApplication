using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Application.Common
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken ct);
    }
}
