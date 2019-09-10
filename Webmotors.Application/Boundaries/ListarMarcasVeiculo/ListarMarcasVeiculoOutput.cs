using System.Collections.Generic;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.Boundaries.ListarMarcasVeiculo
{
    public class ListarMarcasVeiculoOutput
    {
        public List<MarcaVeiculo> Marcas { get; }

        public ListarMarcasVeiculoOutput(List<MarcaVeiculo> marcas)
        {
            Marcas = new List<MarcaVeiculo>();

            foreach (var marca in marcas)
            {
                if (marca.ID == 0)
                    continue;

                if (string.IsNullOrWhiteSpace(marca.Name))
                    continue;

                Marcas.Add(marca);
            }
        }
    }
}