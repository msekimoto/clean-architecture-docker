using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using Swashbuckle.AspNetCore.Examples;
using Webmotors.Application.Boundaries.AtualizarAnuncio;
using Webmotors.WebApi.Extensions.FeatureFlags;

namespace Webmotors.WebApi.UseCases.V1.AtualizarAnuncio
{
    [FeatureGate(Features.AtualizarAnuncio)]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AtualizarAnuncioController : Controller
    {
        private readonly IUseCase _atualizarAnuncioUseCase;
        private readonly AtualizarAnuncioPresenter _atualizarAnuncioPresenter;

        public AtualizarAnuncioController(IUseCase atualizarAnuncioUseCase, AtualizarAnuncioPresenter atualizarAnuncioPresenter)
        {
            _atualizarAnuncioUseCase = atualizarAnuncioUseCase;
            _atualizarAnuncioPresenter = atualizarAnuncioPresenter;
        }

        [HttpPut(Name = "AtualizarAnuncio")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AtualizarAnuncioResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(AtualizarAnuncioRequest), typeof(AtualizarAnuncioExample))]
        public async Task<IActionResult> Put([FromBody][Required] AtualizarAnuncioRequest request)
        {
            var atualizarAnuncioInput = new AtualizarAnuncioInput(request.Id, request.IdMarca, request.IdModelo,request.IdVersao, request.Ano, request.Quilometragem, request.Observacao);
            await _atualizarAnuncioUseCase.Execute(atualizarAnuncioInput);
            return _atualizarAnuncioPresenter.ViewModel;
        }
    }
}
