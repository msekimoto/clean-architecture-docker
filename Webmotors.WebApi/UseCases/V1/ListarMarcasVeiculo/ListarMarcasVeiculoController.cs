using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using Webmotors.Application.Boundaries.ListarMarcasVeiculo;
using Webmotors.WebApi.Extensions.FeatureFlags;

namespace Webmotors.WebApi.UseCases.V1.ListarMarcasVeiculo
{
    [FeatureGate(Features.ListarMarcasVeiculo)]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ListarMarcasVeiculoController : Controller
    {
        private readonly IUseCase _listarMarcasUseCase;
        private readonly ListarMarcasVeiculoPresenter _listarMarcasVeiculoPresenter;

        public ListarMarcasVeiculoController(IUseCase listarMarcasUseCase, ListarMarcasVeiculoPresenter listarMarcasVeiculoPresenter)
        {
            _listarMarcasUseCase = listarMarcasUseCase;
            _listarMarcasVeiculoPresenter = listarMarcasVeiculoPresenter;
        }

        [HttpGet(Name = "ListarMarcas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListarMarcasVeiculoResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            await _listarMarcasUseCase.Execute();
            return _listarMarcasVeiculoPresenter.ViewModel;
        }
    }
}
