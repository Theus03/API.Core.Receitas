using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Dominio.Requests
{
    public class InserirReceitaRequest
    {
        public int IdTipoReceita { get; set; }
        public string? TipoReceita { get; set; }
        public string Nome { get; set; }
        public IFormFile? Imagem { get; set; }
    }
}
