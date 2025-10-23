namespace API.Core.Receitas.Extensoes
{
    public static class CorsExtensions
    {
        public static void AddConfigCorsExtensions(this WebApplicationBuilder builder)
        {
            var config = builder.Configuration;
            string[]? enderecosPermitidos = config.GetValue<string>("AllowedHosts")?.Split(";");

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy
                        .WithOrigins(enderecosPermitidos ?? ["*"])
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
    }
}
