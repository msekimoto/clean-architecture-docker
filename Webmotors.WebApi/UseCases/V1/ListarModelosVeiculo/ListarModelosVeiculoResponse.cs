using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.ListarModelosVeiculo
{
    public sealed class ListarModelosVeiculoResponse
    {
        [Required]
        public IList<ModeloVeiculoModel> Modelos { get; }

        public ListarModelosVeiculoResponse(List<ModeloVeiculoModel> modelos)
        {
            Modelos = modelos;
        }
    }
}