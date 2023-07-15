using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.AddClient
{
    internal class AddClientCommandValidator : AbstractValidator<AddClientCommand>
    {
        public AddClientCommandValidator()
        {
            RuleFor(x => x.NombreUsuario).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Contrasena).NotEmpty().MaximumLength(200).MinimumLength(10);
            RuleFor(x => x.Nombre).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Apellidos).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Direccion).NotEmpty().MaximumLength(200);
        }
    }
}
