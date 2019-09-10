using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using Swashbuckle.AspNetCore.Examples;
using Webmotors.Application.Boundaries.IncluirAnuncio;
using Webmotors.WebApi.Extensions.FeatureFlags;

namespace Webmotors.WebApi.UseCases.V1.IncluirAnuncio
{
    [FeatureGate(Features.IncluirAnuncio)]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IncluirAnuncioController : Controller
    {
        private readonly IUseCase _IncluirAnuncioUseCase;
        private readonly IncluirAnuncioPresenter _incluirAnuncioPresenter;

        public IncluirAnuncioController(IUseCase incluirAnuncioUseCase, IncluirAnuncioPresenter incluirAnuncioPresenter)
        {
            _IncluirAnuncioUseCase = incluirAnuncioUseCase;
            _incluirAnuncioPresenter = incluirAnuncioPresenter;
        }

        [HttpPost(Name = "IncluirAnuncio")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IncluirAnuncioResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(IncluirAnuncioRequest), typeof(IncluirAnuncioExample))]
        public async Task<IActionResult> Post([FromBody][Required] IncluirAnuncioRequest request)
        {
            var IncluirAnuncioInput = new IncluirAnuncioInput(request.IdMarca, request.IdModelo,request.IdVersao, request.Ano, request.Quilometragem, request.Observacao);
            await _IncluirAnuncioUseCase.Execute(IncluirAnuncioInput);
            return _incluirAnuncioPresenter.ViewModel;
        }
    }
}
