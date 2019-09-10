using Swashbuckle.AspNetCore.Examples;

namespace Webmotors.WebApi.UseCases.V1.ConsultarAnuncio
{
    public sealed class ConsultarAnuncioExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new ConsultarAnuncioRequest
            {
                IdAnuncio = 1
            };

            return request;
        }
    }
}