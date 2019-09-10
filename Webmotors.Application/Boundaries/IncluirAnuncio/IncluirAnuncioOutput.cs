using System.Collections.Generic;
using Webmotors.Application.Boundaries.ListarModelosVeiculo;
using Webmotors.Domain.Anuncios;

namespace Webmotors.Application.Boundaries.IncluirAnuncio
{
    public class IncluirAnuncioOutput
    {
        public IAnuncio Anuncio { get; }

        public IncluirAnuncioOutput(IAnuncio anuncio)
        {
            Anuncio = anuncio;
        }
    }
}