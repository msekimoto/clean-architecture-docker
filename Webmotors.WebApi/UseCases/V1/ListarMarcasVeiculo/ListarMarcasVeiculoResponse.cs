using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.ListarMarcasVeiculo
{
    public sealed class ListarMarcasVeiculoResponse
    {
        [Required]
        public IList<MarcaVeiculoModel> Marcas { get; }

        public ListarMarcasVeiculoResponse(List<MarcaVeiculoModel> marcas)
        {
            Marcas = marcas;
        }
    }
}