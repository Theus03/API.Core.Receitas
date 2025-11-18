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
        public DateTime? DataCriacao { get; private set; }

        [Column("Nome")]
        public string? Nome { get; private set; }

        [Column("Imagem")]
        public string? Imagem { get; set; }

        // ❗ necessário para o Supabase (ORM)
        public Receita() { }

        public Receita(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome da receita não pode ser vazio.", nameof(nome));
            }

            Nome = nome;
            DataCriacao = DateTime.UtcNow;
        }

    }
}
