using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webmotors.Application.Repositories;
using Webmotors.Domain.Anuncios;
using Webmotors.Infrastructure.Context;
using Anuncio = Webmotors.Infrastructure.Entities.Anuncio;

namespace Webmotors.Infrastructure.Repositories
{
    public sealed class AnuncioRepository : IAnuncioRepository
    {
        private readonly WebmotorsContext _context;

        public AnuncioRepository(WebmotorsContext context)
        {
            _context = context;
        }

        public async Task<IAnuncio> Get(int id)
        {
            return await _context.Anuncios.FindAsync(id);
        }

        public async Task Add(IAnuncio anuncio)
        {
            await _context.Anuncios.AddAsync((Anuncio)anuncio);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task Update(IAnuncio anuncio)
        {
            _context.Anuncios.Update((Anuncio)anuncio);
            await _context.SaveChangesAsync();
        }

        //public async Task Delete(IAnuncio anuncio)
        //{
        //    string deleteSQL = @"DELETE FROM tb_anunciowebmotors WHERE id = @Id;";
        //    var id = new SqlParameter("@Id", anuncio.ID);
        //    int affectedRows = await _context.Database.ExecuteSqlCommandAsync(deleteSQL, id);
        //}

        // Alterado para EFCore para poder realizar teste unitario com banco em memoria
        public async Task Delete(IAnuncio anuncio)
        {
            _context.Anuncios.Remove((Anuncio)anuncio);
            await _context.SaveChangesAsync();
        }
    }
}