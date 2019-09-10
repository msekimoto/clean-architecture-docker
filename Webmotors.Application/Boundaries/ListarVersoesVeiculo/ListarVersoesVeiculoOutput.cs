using System.Collections.Generic;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.Boundaries.ListarVersoesVeiculo
{
    public class ListarVersoesVeiculoOutput
    {
        public List<VersaoVeiculo> Versoes { get; }

        public ListarVersoesVeiculoOutput(List<VersaoVeiculo> versoes)
        {
            Versoes = new List<VersaoVeiculo>();

            foreach (var modelo in versoes)
            {
                if (modelo.ModelID == 0)
                    continue;

                if (modelo.ID == 0)
                    continue;

                if (string.IsNullOrWhiteSpace(modelo.Name))
                    continue;

                Versoes.Add(modelo);
            }
        }
    }
}