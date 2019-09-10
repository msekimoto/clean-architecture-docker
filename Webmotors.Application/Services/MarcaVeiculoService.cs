using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmotors.Application.Boundaries.ListarMarcasVeiculo;
using Webmotors.Application.Services.Interfaces;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.Services
{
    public class MarcaVeiculoService : IMarcaVeiculoService
    {
        public async Task<List<MarcaVeiculo>> Buscar()
        {
            List<MarcaVeiculo> marcas = new List<MarcaVeiculo>();

            try
            {
                var client = new IClient<List<MarcaVeiculo>>($"http://desafioonline.webmotors.com.br", $"/api/OnlineChallenge/Make");
                return await client.Get();
            }
            catch (Exception)
            {
                return marcas;
            }
        }
    }
}
