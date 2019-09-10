using System.Collections.Generic;
using Webmotors.Application.Boundaries.ListarModelosVeiculo;
using Webmotors.Domain.Anuncios;

namespace Webmotors.Application.Boundaries.ConsultarAnuncio
{
    public class ConsultarAnuncioOutput
    {
        public IAnuncio Anuncio { get; }

        public ConsultarAnuncioOutput(IAnuncio anuncio)
        {
            Anuncio = anuncio;
        }
    }
}