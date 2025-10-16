using Supabase.Postgrest.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Dominio.DTOs
{
    public class ReceitaDto
    {
        public int? IdReceita { get; set; }
        public int? IdTipoReceita { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string? Nome { get; set; }
    }
}
