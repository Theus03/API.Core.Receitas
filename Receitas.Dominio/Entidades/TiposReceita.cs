using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Receitas.Dominio.Entidades
{
    [Supabase.Postgrest.Attributes.Table("TabTiposReceita")]
    public class TiposReceita : BaseModel
    {
        [PrimaryKey("IdTipoReceita")]
        public int? IdTipoReceita { get; set; }

        [Supabase.Postgrest.Attributes.Column("DataCriacao")]
        public DateTime? DataCriacao { get; set; }

        [Supabase.Postgrest.Attributes.Column("TipoReceita")]
        public string? TipoReceita { get; set; }
    }
}
