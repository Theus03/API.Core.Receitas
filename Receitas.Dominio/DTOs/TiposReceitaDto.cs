using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Dominio.DTOs
{
    public class TiposReceitaDto
    {
        public int? IdTipoReceita { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string? TipoReceita { get; set; }
        public int? QuantidadeReceitas { get; set; }
    }
}
