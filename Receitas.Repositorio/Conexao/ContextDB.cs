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
            string supabaseUrl = _configuration["supabaseUrl"]!.ToString();
            string supabaseKey = _configuration["supabaseKey"]!.ToString();

            Supabase.Client client = new(supabaseUrl!, supabaseKey);

            await client.InitializeAsync();

            return client;
        }
    }
}
