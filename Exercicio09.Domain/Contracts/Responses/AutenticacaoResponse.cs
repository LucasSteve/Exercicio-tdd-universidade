﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Contracts.Responses
{
    public class AutenticacaoResponse
    {
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; }

    }
}
