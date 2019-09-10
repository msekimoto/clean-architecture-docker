using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Application.Boundaries.ListarVersoesVeiculo;
using Webmotors.Application.Services.Interfaces;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.Services
{
    public class VersaoVeiculoService : IVersaoVeiculoService
    {
        public async Task<List<VersaoVeiculo>> Buscar(int idModeloVeiculo)
        {
            List<VersaoVeiculo> versoes = new List<VersaoVeiculo>();

            try
            {
                var client = new IClient<List<VersaoVeiculo>>($"http://desafioonline.webmotors.com.br", $"/api/OnlineChallenge/Version?ModelID={idModeloVeiculo}");
                return await client.Get();
            }
            catch (Exception)
            {
                return versoes;
            }
        }
    }
}