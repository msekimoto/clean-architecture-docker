using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using Swashbuckle.AspNetCore.Examples;
using Webmotors.Application.Boundaries.ListarModelosVeiculo;
using Webmotors.WebApi.Extensions.FeatureFlags;

namespace Webmotors.WebApi.UseCases.V1.ListarModelosVeiculo
{
    [FeatureGate(Features.ListarModelosVeiculo)]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ListarModelosVeiculoController : Controller
    {
        private readonly IUseCase _listarModelosUseCase;
        private readonly ListarModelosVeiculoPresenter _listarModelosPresenter;

        public ListarModelosVeiculoController(IUseCase listarModelosUseCase, ListarModelosVeiculoPresenter listarModelosPresenter)
        {
            _listarModelosUseCase = listarModelosUseCase;
            _listarModelosPresenter = listarModelosPresenter;
        }

        [HttpGet("{IdMarca}", Name = "ListarModelos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListarModelosVeiculoResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(ListarModelosVeiculoRequest), typeof(ListarModelosVeiculoExample))]
        public async Task<IActionResult> Get([FromRoute][Required] ListarModelosVeiculoRequest request)
        {
            var listarModelosVeiculoInput = new ListarModelosVeiculoInput(request.IdMarca);
            await _listarModelosUseCase.Execute(listarModelosVeiculoInput);
            return _listarModelosPresenter.ViewModel;
        }
    }
}
