using Supabase;
using Supabase.Postgrest.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repositorio.Conexao
{
    public interface IContextDB
    {
        public Task<Supabase.Client> ObterConexao();
    }
}
