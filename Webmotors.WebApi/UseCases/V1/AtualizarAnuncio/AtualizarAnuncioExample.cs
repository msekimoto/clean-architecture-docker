using Swashbuckle.AspNetCore.Examples;

namespace Webmotors.WebApi.UseCases.V1.AtualizarAnuncio
{
    public sealed class AtualizarAnuncioExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new AtualizarAnuncioRequest
            {
                Id = 1,
                IdMarca = 1,
                IdModelo = 1,
                IdVersao = 8,
                Ano = 2017,
                Quilometragem = 59000,
                Observacao = $"Todas as revisões feitas na concessionaria"
            };

            return request;
        }
    }
}