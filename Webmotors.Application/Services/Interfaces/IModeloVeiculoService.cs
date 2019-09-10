using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Application.Boundaries.ListarModelosVeiculo;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.Services.Interfaces
{
    public interface IModeloVeiculoService
    {
        Task<List<ModeloVeiculo>> Buscar(int idMarcaVeiculo);
    }
}