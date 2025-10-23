using Receitas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Dominio.DTOs
{
    public class ModoPreparoDto
    {
        public int? IdPreparo { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int? IdReceita { get; set; }
        public int? QtdeEtapas { get; set; }
        public List<ModoPreparoItem> InstrucoesPreparo { get; set; }
        public List<IngredienteItem> Ingredientes { get; set; }
    }
    public class ModoPreparoItem
    {
        public int Etapa { get; set; }
        public string Descricao { get; set; }
    }

    public class IngredienteItem
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
