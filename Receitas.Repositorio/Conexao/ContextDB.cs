using Microsoft.Extensions.Configuration;
using Supabase;
using Supabase.Postgrest.Responses;
using Supabase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repositorio.Conexao
{
    public class ContextDB : IContextDB
    {

        public IConfiguration _configuration;

        public ContextDB(IConfiguration configuration) => _configuration = configuration;

        public async Task<Supabase.Client> ObterConexao()
        {
            var supabaseUrl = _configuration["supabaseUrl"];
            var supabaseKey = _configuration["supabaseKey"];

            var client = new Supabase.Client(supabaseUrl!, supabaseKey);

            await client.InitializeAsync();

            return client;
        }
    }
}
