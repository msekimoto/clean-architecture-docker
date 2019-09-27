using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Moq;
using Webmotors.Application.Boundaries.IncluirAnuncio;
using Webmotors.Application.Services.Interfaces;
using Webmotors.Domain.Veiculos;
using Webmotors.WebApi.UseCases.V1.IncluirAnuncio;
using Xunit;

namespace Webmotors.UnitTests.UseCaseTests.IncluirAnuncio
{
    public sealed class IncluirAnuncioTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public IncluirAnuncioTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task DadosValidos_Sucesso()
        {
            var marcas = new List<MarcaVeiculo> { new MarcaVeiculo(1, $"Chevrolet") };
            var modelos = new List<ModeloVeiculo> { new ModeloVeiculo(1, $"Agile", 1) };
            var versoes = new List<VersaoVeiculo> { new VersaoVeiculo(6, $"1.5 DX 16V FLEX 4P AUTOMÁTICO", 1) };

            var mockMarcaVeiculoService = new Mock<IMarcaVeiculoService>();
            mockMarcaVeiculoService.Setup(ma => ma.Buscar())
                                   .Returns(Task.FromResult(marcas));

            var mockModeloVeiculoService = new Mock<IModeloVeiculoService>();
            mockModeloVeiculoService.Setup(mo => mo.Buscar(It.IsAny<int>()))
                                    .Returns(Task.FromResult(modelos));

            var mockVersaoVeiculoService = new Mock<IVersaoVeiculoService>();
            mockVersaoVeiculoService.Setup(mo => mo.Buscar(It.IsAny<int>()))
                                    .Returns(Task.FromResult(versoes));

            var mockDistrbutedCacheService = new Mock<IDistributedCache>();
            mockDistrbutedCacheService.Setup(c => c.SetString(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DistributedCacheEntryOptions>()));

            var outputHandler = new IncluirAnuncioPresenter();

            Application.UseCases.IncluirAnuncio incluirAnuncio = new Application.UseCases.IncluirAnuncio(
                outputHandler,
                mockMarcaVeiculoService.Object,
                mockModeloVeiculoService.Object,
                mockVersaoVeiculoService.Object,
                _fixture.AnuncioRepository,
                _fixture.UnitOfWork,
                _fixture.EntityFactory,
                It.IsAny<IConfiguration>(),
                mockDistrbutedCacheService.Object);

            await incluirAnuncio.Execute(new IncluirAnuncioInput(1, 1, 6, 2014, 59000, $"Unit Test"));

            var actual = Assert.IsType<OkObjectResult>(outputHandler.ViewModel);
            Assert.Equal((int)HttpStatusCode.OK, actual.StatusCode);

            var actualValue = (IncluirAnuncioResponse)actual.Value;
            Assert.True(actualValue.IncluirAnuncioModel.ID > 0);
        }
    }
}
