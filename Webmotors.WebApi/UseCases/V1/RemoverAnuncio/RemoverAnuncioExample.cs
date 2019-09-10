using Swashbuckle.AspNetCore.Examples;

namespace Webmotors.WebApi.UseCases.V1.RemoverAnuncio
{
    public sealed class RemoverAnuncioExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var request = new RemoverAnuncioRequest
            {
                IdAnuncio = 1,
            };

            return request;
        }
    }
}