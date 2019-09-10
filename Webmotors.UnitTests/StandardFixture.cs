using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Webmotors.Infrastructure.Context;
using Webmotors.Infrastructure.Factories;
using Webmotors.Infrastructure.Repositories;
using Webmotors.Infrastructure.UoW;

namespace Webmotors.UnitTests
{
    public sealed class StandardFixture
    {
        public EntityFactory EntityFactory { get; }
        public WebmotorsContext Context { get; }
        public AnuncioRepository AnuncioRepository { get; }
        public UnitOfWork UnitOfWork { get; }

        public StandardFixture()
        {
            var options = new DbContextOptionsBuilder<WebmotorsContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseLazyLoadingProxies()
                .Options;

            Context = new WebmotorsContext(options);
            AnuncioRepository = new AnuncioRepository(Context);
            UnitOfWork = new UnitOfWork(Context);
            EntityFactory = new EntityFactory();
        }
    }
}
