using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Webmotors.Application
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
