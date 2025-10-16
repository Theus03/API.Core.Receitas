using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Receitas.Dominio.Entidades

{
    [Table("TabReceitas")]
    public class Receita : BaseModel
    {
        [PrimaryKey("IdReceita")]
        public int? IdReceita { get; set; }

        [Column("IdTipoReceita")]
        public int? IdTipoReceita { get; set; }

        [Column("DataCriacao")]
        public DateTime? DataCriacao { get; set; }

        [Column("Nome")]
        public string? Nome { get; set; }

    }
}
