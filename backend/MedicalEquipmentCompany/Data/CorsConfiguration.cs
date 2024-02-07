using Microsoft.Net.Http.Headers;

namespace MedicalEquipmentCompany.Data
{
    public static class CorsConfiguration
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services, string corsPolicy)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsPolicy,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200") // Allow requests from this origin
                             .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "access_token")
                             .WithMethods("GET", "PUT", "POST", "PATCH", "DELETE", "OPTIONS")
                             .AllowCredentials();
                    });
            });
            return services;
        }

        private static string[] ParseCorsOrigins()
        {
            var corsOrigins = new[] { "http://localhost:4200" };
            var corsOriginsPath = Environment.GetEnvironmentVariable("EXPLORER_CORS_ORIGINS");
            if (File.Exists(corsOriginsPath))
            {
                corsOrigins = File.ReadAllLines(corsOriginsPath);
            }

            return corsOrigins;
        }
    }
}
