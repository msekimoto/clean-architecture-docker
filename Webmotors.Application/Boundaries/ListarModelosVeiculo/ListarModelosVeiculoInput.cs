using Webmotors.Application.Exceptions;

namespace Webmotors.Application.Boundaries.ListarModelosVeiculo
{
    public sealed class ListarModelosVeiculoInput
    {
        public int IdMarcaVeiculo { get; }

        public ListarModelosVeiculoInput(int idMarcaVeiculo)
        {
            if (idMarcaVeiculo == 0)
                throw new InputValidationException($"{nameof(idMarcaVeiculo)} não pode ser zero.");

            IdMarcaVeiculo = idMarcaVeiculo;
        }
    }
}