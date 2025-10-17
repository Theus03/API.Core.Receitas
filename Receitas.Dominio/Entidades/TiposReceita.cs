using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Receitas.Dominio.Entidades
{
    [Table("TabTiposReceita")]
    public class TiposReceita : BaseModel
    {
        [PrimaryKey("IdTipoReceita")]
        public int? IdTipoReceita { get; set; }

        [Column("DataCriacao")]
        public DateTime? DataCriacao { get; set; }

        [Column("TipoReceita")]
        public string? TipoReceita { get; set; }
    }
}
