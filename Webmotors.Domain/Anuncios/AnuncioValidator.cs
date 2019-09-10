using System;
using FluentValidation;

namespace Webmotors.Domain.Anuncios
{
    public class AnuncioValidator : AbstractValidator<Anuncio>
    {
        public AnuncioValidator()
        {
            RuleFor(x => x.ID)
                .NotNull();

            RuleFor(x => x.Marca)
                .NotNull()
                .NotEmpty()
                .Length(0, 45);

            RuleFor(x => x.Modelo)
                .NotNull()
                .NotEmpty()
                .Length(0, 45);

            RuleFor(x => x.Versao)
                .NotNull()
                .NotEmpty()
                .Length(0, 45);

            RuleFor(x => x.Ano)
                .NotNull()
                .InclusiveBetween(1900, DateTime.Now.Year);

            RuleFor(x => x.Quilometragem)
                .NotNull()
                .InclusiveBetween(0, 999999);

            RuleFor(x => x.Observacao)
                .NotNull()
                .NotEmpty();
        }
    }
}