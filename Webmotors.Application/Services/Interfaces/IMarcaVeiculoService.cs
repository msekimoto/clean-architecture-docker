using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Application.Boundaries.ListarMarcasVeiculo;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.Services.Interfaces
{
    public interface IMarcaVeiculoService
    {
        Task<List<MarcaVeiculo>> Buscar();
    }
}
