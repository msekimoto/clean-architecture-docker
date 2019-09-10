using Swashbuckle.AspNetCore.Examples;

namespace Webmotors.WebApi.UseCases.V1.ListarVersoesVeiculo
{
    public sealed class ListarVersoesVeiculoExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new ListarVersoesVeiculoRequest
            {
                IdModelo = 1
            };

            return request;
        }
    }
}