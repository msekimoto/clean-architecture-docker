using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using Swashbuckle.AspNetCore.Examples;
using Webmotors.Application.Boundaries.ListarVersoesVeiculo;
using Webmotors.WebApi.Extensions.FeatureFlags;

namespace Webmotors.WebApi.UseCases.V1.ListarVersoesVeiculo
{
    [FeatureGate(Features.ListarVersoesVeiculo)]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ListarVersoesVeiculoController : Controller
    {
        private readonly IUseCase _listarVersoesVeiculoUseCase;
        private readonly ListarVersoesVeiculoPresenter _listarModelosPresenter;

        public ListarVersoesVeiculoController(IUseCase listarVersoesVeiculoUseCase, ListarVersoesVeiculoPresenter listarModelosPresenter)
        {
            _listarVersoesVeiculoUseCase = listarVersoesVeiculoUseCase;
            _listarModelosPresenter = listarModelosPresenter;
        }

        [HttpGet("{IdModelo}", Name = "ListarVersoes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListarVersoesVeiculoResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(ListarVersoesVeiculoRequest), typeof(ListarVersoesVeiculoExample))]
        public async Task<IActionResult> Get([FromRoute][Required] ListarVersoesVeiculoRequest request)
        {
            var ListarVersoesVeiculoInput = new ListarVersoesVeiculoInput(request.IdModelo);
            await _listarVersoesVeiculoUseCase.Execute(ListarVersoesVeiculoInput);
            return _listarModelosPresenter.ViewModel;
        }
    }
}
