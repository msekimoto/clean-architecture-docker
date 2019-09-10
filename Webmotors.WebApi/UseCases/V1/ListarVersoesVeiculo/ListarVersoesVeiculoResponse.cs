using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Webmotors.WebApi.ViewModels;

namespace Webmotors.WebApi.UseCases.V1.ListarVersoesVeiculo
{
    public sealed class ListarVersoesVeiculoResponse
    {
        [Required]
        public IList<VersaoVeiculoModel> Versoes { get; }

        public ListarVersoesVeiculoResponse(List<VersaoVeiculoModel> versoes)
        {
            Versoes = versoes;
        }
    }
}