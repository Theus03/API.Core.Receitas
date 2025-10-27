using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Dominio.Entidades
{
    [Table("TabPreparo")]
    public class ModoPreparo : BaseModel
    {
        [PrimaryKey("IdPreparo")]
        public int? IdPreparo { get; set; }

        [Column("DataCriacao")]
        public DateTime? DataCriacao { get; set; }

        [Column("IdReceita")]
        public int? IdReceita { get; set; }

        [Column("QtdeEtapas")]
        public int? QtdeEtapas { get; set; }

        [Column("ModoPreparo")]
        public List<ModoPreparoItem> InstrucoesPreparo { get; set; }

        [Column("Ingredientes")]
        public List<IngredienteItem> Ingredientes { get; set; }

        [Column("Tempo")]
        public TimeSpan? Tempo { get; set; }
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
