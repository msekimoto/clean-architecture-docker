using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webmotors.Infrastructure.Entities;

namespace Webmotors.Infrastructure.Configuration
{
    public class AnuncioEntityConfiguration : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> modelBuilder)
        {
            modelBuilder.ToTable("tb_AnuncioWebmotors");

            modelBuilder.HasKey(a => a.ID);

            modelBuilder.Property(a => a.Marca)
                .HasColumnName($"marca")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Property(a => a.Modelo)
                .HasColumnName($"modelo")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Property(a => a.Versao)
                .HasColumnName($"versao")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Property(a => a.Ano)
                .HasColumnName($"ano")
                .IsRequired();

            modelBuilder.Property(a => a.Quilometragem)
                .HasColumnName($"quilometragem")
                .IsRequired();

            modelBuilder.Property(a => a.Observacao)
                .HasColumnName($"observacao")
                .IsRequired();
        }
    }
}
