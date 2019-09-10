using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webmotors.Infrastructure.Context;
using Webmotors.Infrastructure.Entities;
using Webmotors.Infrastructure.Repositories;
using Xunit;

namespace Webmotors.IntegrationTests.EntityFrameworkTests
{
    public class AnuncioRepositoryTests
    {
        [Fact]
        public async Task Add_Database()
        {
            var connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=teste_webmotors;Persist Security Info=True;User ID=USERDB;Password=USERPWD;" +
                                   "Max Pool Size=1000;MultipleActiveResultSets=True;Trusted_Connection=true;";

            var options = new DbContextOptionsBuilder<WebmotorsContext>()
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies()
                .Options;

            using (var context = new WebmotorsContext(options))
            {
                context.Database.EnsureCreated();

                var qtdaAnunciosAtual = context.Anuncios.Count();

                var repository = new AnuncioRepository(context);
                var anuncio = new Anuncio($"Chevrolet", $"Agile", $"1.5 DX 16V FLEX 4P AUTOMÁTICO", 2014, 59000, $"Teste Exclusao");
                await repository.Add(anuncio);

                Assert.Equal(qtdaAnunciosAtual + 1, context.Anuncios.Count());
            }
        }
    }
}
