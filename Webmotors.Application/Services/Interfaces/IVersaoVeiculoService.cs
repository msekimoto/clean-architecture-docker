using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Application.Boundaries.ListarVersoesVeiculo;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.Services.Interfaces
{
    public interface IVersaoVeiculoService
    {
        Task<List<VersaoVeiculo>> Buscar(int idMarcaVeiculo);
    }
}