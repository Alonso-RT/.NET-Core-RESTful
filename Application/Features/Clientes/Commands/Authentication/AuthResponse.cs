﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.Authentication
{
    public class AuthResponse
    {
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
