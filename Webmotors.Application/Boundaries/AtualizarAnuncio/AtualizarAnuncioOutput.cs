using System.Collections.Generic;
using Webmotors.Application.Boundaries.ListarModelosVeiculo;
using Webmotors.Domain.Anuncios;

namespace Webmotors.Application.Boundaries.AtualizarAnuncio
{
    public class AtualizarAnuncioOutput
    {
        public IAnuncio Anuncio { get; }

        public AtualizarAnuncioOutput(IAnuncio anuncio)
        {
            Anuncio = anuncio;
        }
    }
}