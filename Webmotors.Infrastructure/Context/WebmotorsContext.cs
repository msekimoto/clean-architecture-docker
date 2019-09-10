using Microsoft.EntityFrameworkCore;
using Webmotors.Infrastructure.Configuration;
using Webmotors.Infrastructure.Entities;

namespace Webmotors.Infrastructure.Context
{
    public sealed class WebmotorsContext : DbContext
    {
        public WebmotorsContext(DbContextOptions options) : base(options) { }

        public DbSet<Anuncio> Anuncios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnuncioEntityConfiguration());
        }
    }
}