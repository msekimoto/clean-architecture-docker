using System.Threading.Tasks;
using Webmotors.Application;
using Webmotors.Infrastructure.Context;

namespace Webmotors.Infrastructure.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private WebmotorsContext context;

        public UnitOfWork(WebmotorsContext context)
        {
            this.context = context;
        }

        public async Task<int> Save()
        {
            return await Task.FromResult<int>(0);
        }
    }
}
