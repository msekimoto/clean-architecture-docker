using Swashbuckle.AspNetCore.Examples;

namespace Webmotors.WebApi.UseCases.V1.ListarModelosVeiculo
{
    public sealed class ListarModelosVeiculoExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new ListarModelosVeiculoRequest
            {
                IdMarca = 1
            };

            return request;
        }
    }
}