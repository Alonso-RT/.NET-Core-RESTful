using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tiendas.Commands.UpdateStore
{
    internal class UpdateStoreCommandValidator : AbstractValidator<UpdateStoreCommand>
    {
        public UpdateStoreCommandValidator()
        {
            RuleFor(x => x.TiendaID).NotEmpty();
            RuleFor(x => x.Sucursal).NotEmpty();
            RuleFor(x => x.Direccion).NotEmpty();

        }
    }
}
