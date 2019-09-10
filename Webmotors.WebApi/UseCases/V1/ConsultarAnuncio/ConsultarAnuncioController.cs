using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using Swashbuckle.AspNetCore.Examples;
using Webmotors.Application.Boundaries.ConsultarAnuncio;
using Webmotors.WebApi.Extensions.FeatureFlags;

namespace Webmotors.WebApi.UseCases.V1.ConsultarAnuncio
{
    [FeatureGate(Features.ConsultarAnuncio)]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConsultarAnuncioController : Controller
    {
        private readonly IUseCase _consultarAnuncioUseCase;
        private readonly ConsultarAnuncioPresenter _consultarAnuncioPresenter;

        public ConsultarAnuncioController(IUseCase consultarAnuncioUseCase, ConsultarAnuncioPresenter consultarAnuncioPresenter)
        {
            _consultarAnuncioUseCase = consultarAnuncioUseCase;
            _consultarAnuncioPresenter = consultarAnuncioPresenter;
        }

        [HttpGet("{IdAnuncio}", Name = "ConsultarAnuncio")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultarAnuncioResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(ConsultarAnuncioRequest), typeof(ConsultarAnuncioExample))]
        public async Task<IActionResult> Get([FromRoute][Required] ConsultarAnuncioRequest request)
        {
            var consultarAnuncioInput = new ConsultarAnuncioInput(request.IdAnuncio);
            await _consultarAnuncioUseCase.Execute(consultarAnuncioInput);
            return _consultarAnuncioPresenter.ViewModel;
        }
    }
}
