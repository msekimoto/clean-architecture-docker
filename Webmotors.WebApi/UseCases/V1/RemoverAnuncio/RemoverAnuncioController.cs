using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using Swashbuckle.AspNetCore.Examples;
using Webmotors.Application.Boundaries.RemoverAnuncio;
using Webmotors.WebApi.Extensions.FeatureFlags;

namespace Webmotors.WebApi.UseCases.V1.RemoverAnuncio
{
    [FeatureGate(Features.RemoverAnuncio)]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RemoverAnuncioController : Controller
    {
        private readonly IUseCase _removerAnuncioUseCase;
        private readonly RemoverAnuncioPresenter _removerAnuncioPresenter;

        public RemoverAnuncioController(IUseCase removerAnuncioUseCase, RemoverAnuncioPresenter removerAnuncioPresenter)
        {
            _removerAnuncioUseCase = removerAnuncioUseCase;
            _removerAnuncioPresenter = removerAnuncioPresenter;
        }

        [HttpDelete("{IdAnuncio}", Name = "RemoverAnuncio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(RemoverAnuncioRequest), typeof(RemoverAnuncioExample))]
        public async Task<IActionResult> Delete([FromRoute][Required] RemoverAnuncioRequest request)
        {
            var removerAnuncioInput = new RemoverAnuncioInput(request.IdAnuncio);
            await _removerAnuncioUseCase.Execute(removerAnuncioInput);
            return _removerAnuncioPresenter.ViewModel;
        }
    }
}
