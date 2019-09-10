using Swashbuckle.AspNetCore.Examples;

namespace Webmotors.WebApi.UseCases.V1.IncluirAnuncio
{
    public sealed class IncluirAnuncioExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new IncluirAnuncioRequest
            {
                IdMarca = 1,
                IdModelo = 1,
                IdVersao = 6,
                Ano = 2016,
                Quilometragem = 59000,
                Observacao = $"Todas as revisões feitas na concessionaria"
            };

            return request;
        }
    }
}