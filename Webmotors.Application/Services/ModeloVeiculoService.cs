using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Application.Boundaries.ListarModelosVeiculo;
using Webmotors.Application.Services.Interfaces;
using Webmotors.Domain.Veiculos;

namespace Webmotors.Application.Services
{
    public class ModeloVeiculoService : IModeloVeiculoService
    {
        public async Task<List<ModeloVeiculo>> Buscar(int idMarcaVeiculo)
        {
            List<ModeloVeiculo> modelos = new List<ModeloVeiculo>();

            try
            {
                var client = new IClient<List<ModeloVeiculo>>($"http://desafioonline.webmotors.com.br", $"/api/OnlineChallenge/Model?MakeID={idMarcaVeiculo}");
                return await client.Get();
            }
            catch (Exception)
            {
                return modelos;
            }
        }
    }
}