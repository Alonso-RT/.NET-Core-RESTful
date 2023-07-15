using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.UpdateClient
{
    internal class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(x => x.ClienteID).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Apellidos).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Direccion).NotEmpty().MaximumLength(200);
        }   
    }
}
