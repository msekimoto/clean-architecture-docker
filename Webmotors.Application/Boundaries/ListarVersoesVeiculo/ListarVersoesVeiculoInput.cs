using Webmotors.Application.Exceptions;

namespace Webmotors.Application.Boundaries.ListarVersoesVeiculo
{
    public sealed class ListarVersoesVeiculoInput
    {
        public int IdModeloVeiculo { get; }

        public ListarVersoesVeiculoInput(int idModeloVeiculo)
        {
            if (idModeloVeiculo == 0)
                throw new InputValidationException($"{nameof(idModeloVeiculo)} não pode ser zero.");

            IdModeloVeiculo = idModeloVeiculo;
        }
    }
}