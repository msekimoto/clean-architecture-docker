using System.Collections.Generic;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.Boundaries.ListarModelosVeiculo
{
    public class ListarModelosVeiculoOutput
    {
        public List<ModeloVeiculo> Modelos { get; }

        public ListarModelosVeiculoOutput(List<ModeloVeiculo> modelos)
        {
            Modelos = new List<ModeloVeiculo>();

            foreach (var modelo in modelos)
            {
                if (modelo.MakeID == 0)
                    continue;

                if (modelo.ID == 0)
                    continue;

                if (string.IsNullOrWhiteSpace(modelo.Name))
                    continue;

                Modelos.Add(modelo);
            }
        }
    }
}