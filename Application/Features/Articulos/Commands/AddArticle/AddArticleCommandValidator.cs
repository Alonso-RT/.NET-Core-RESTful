using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Articulos.Commands.AddArticle
{
    internal class AddArticleCommandValidator : AbstractValidator<AddArticleCommand>
    {
        public AddArticleCommandValidator()
        {
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Descripcion).NotEmpty();
            RuleFor(x => x.Imagen).NotEmpty();
        }
    }
}
