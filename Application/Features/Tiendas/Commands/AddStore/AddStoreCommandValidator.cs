using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Tiendas.Commands.AddStore
{
    internal class AddStoreCommandValidator : AbstractValidator<AddStoreCommand>
    {
        public AddStoreCommandValidator()
        {
            RuleFor(x => x.Sucursal).NotEmpty();
            RuleFor(x => x.Direccion).NotEmpty();   
        }
    }
}
