using Application.Common;
using Application.Contracts;
using Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

#nullable disable warnings
namespace Application.Features.Clientes.Commands.Authentication
{
    internal class AuthenticateClientCommandHandler : IRequestHandler<AuthenticateClientCommand, AuthResponse>
    {
        private readonly IClientesRepository clientesRepository;
        private readonly IConfiguration configuration;

        public AuthenticateClientCommandHandler(IClientesRepository clientesRepository, IConfiguration configuration)
        {
            this.clientesRepository = clientesRepository;
            this.configuration = configuration;
        }

        public async Task<AuthResponse> Handle(AuthenticateClientCommand request, CancellationToken cancellationToken)
        {
            var cliente = await clientesRepository.AuthenticateUser(request.UserName, Security.SHA256(request.Password));
            if (cliente == null) { throw new NotAuthorizedException("El usuario no tiene acceso a este servicio"); }

            var expiration = DateTime.UtcNow.AddHours(1);

            var key = configuration.GetSection("JwtSettings:Key").Value;
            var issuer = configuration.GetSection("JwtSettings:Issuer").Value;
            var audience = configuration.GetSection("JwtSettings:Audience").Value;

            return new AuthResponse
            {
                UserName = cliente.NombreUsuario,
                Token = Token.GenerateToken(cliente, expiration, key, issuer, audience),
                Expiration = expiration
            };
        }
    }
}
