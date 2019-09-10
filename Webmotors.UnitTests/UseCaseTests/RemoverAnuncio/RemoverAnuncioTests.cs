using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webmotors.Application.Boundaries.RemoverAnuncio;
using Webmotors.Infrastructure.Entities;
using Webmotors.WebApi.UseCases.V1.RemoverAnuncio;
using Xunit;

namespace Webmotors.UnitTests.UseCaseTests.RemoverAnuncio
{
    public sealed class RemoverAnuncioTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public RemoverAnuncioTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task DadosValidos_Sucesso()
        {
            var anuncio = new Anuncio($"Chevrolet", $"Agile", $"1.5 DX 16V FLEX 4P AUTOMÁTICO", 2014, 59000, $"Teste Exclusao");
            await _fixture.AnuncioRepository.Add(anuncio);

            var outputHandler = new RemoverAnuncioPresenter();
            Application.UseCases.RemoverAnuncio removerAnuncio = new Application.UseCases.RemoverAnuncio(outputHandler, _fixture.AnuncioRepository);

            await removerAnuncio.Execute(new RemoverAnuncioInput(anuncio.ID));

            var actual = Assert.IsType<OkObjectResult>(outputHandler.ViewModel);
            Assert.Equal((int)HttpStatusCode.OK, actual.StatusCode);
            Assert.Equal($"Excluido com Sucesso.", actual.Value);
        }
    }
}
