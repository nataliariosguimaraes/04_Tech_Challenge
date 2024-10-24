using LocalFriendzApi.Application.IServices;
using LocalFriendzApi.Application.Services;
using LocalFriendzApi.Core.Configuration;
using LocalFriendzApi.Core.IRepositories;
using LocalFriendzApi.Core.Logging;
using LocalFriendzApi.Infrastructure.Data;
using LocalFriendzApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LocalFriendzApi.Commom.Api
{
    public static class BuildExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            // Alterando a string de conexão para PostgreSQL
            ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection") ?? string.Empty;
        }

        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddDbContext<AppDbContext>(
                    x =>
                    {
                        // Alterando para usar PostgreSQL
                        x.UseNpgsql(ApiConfiguration.ConnectionString);
                    });

        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddTransient<IContactServices, ContactServices>();

            builder
                .Services
                .AddTransient<IContactRepository, ContactRepository>();
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n => n.FullName);
            });
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            // inserir implementação do cross
        }

        public static void AddLogging(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
            {
                LogLevel = LogLevel.Information
            }));
        }
    }
}