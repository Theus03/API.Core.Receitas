using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Dominio.Filtros
{
    public class FiltroListarReceitas
    {
        public string? Nome  { get; set; }
        public string? TipoReceita { get; set; }
        public string? Tempo { get; set; }
    }
}
