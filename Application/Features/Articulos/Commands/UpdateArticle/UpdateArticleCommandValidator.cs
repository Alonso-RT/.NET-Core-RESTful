using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Commands.UpdateArticle
{
    internal class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
            RuleFor(x => x.ArticuloID).NotEmpty();
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Descripcion).NotEmpty();
            RuleFor(x => x.Imagen).NotEmpty();
        }
    }
}
