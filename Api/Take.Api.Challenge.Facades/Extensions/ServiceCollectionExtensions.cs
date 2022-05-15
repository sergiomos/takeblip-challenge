using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Take.Api.Challenge.Facades.Strategies.ExceptionHandlingStrategies;
using Take.Api.Challenge.Models;
using Take.Api.Challenge.Models.UI;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using RestEase;

using Serilog;
using Serilog.Exceptions;
using Take.Api.Challenge.Facades.Interfaces;
using Take.Api.Challenge.Services;
using Take.Api.Challenge.Services.Interfaces;

namespace Take.Api.Challenge.Facades.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        private const string APPLICATION_KEY = "Application";
        private const string SETTINGS_SECTION = "Settings";

        /// <summary>
        /// Registers project's specific services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSingletons(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection(SETTINGS_SECTION).Get<ApiSettings>();
            var authenticaionSettings = configuration.GetSection(SETTINGS_SECTION).Get<Models.Settings.AuthenticationSettings>();

            // Dependency injection
            services.AddSingleton(settings)
                    .AddSingleton(settings.BlipBotSettings)
                    .AddSingleton(authenticaionSettings)
                    .AddSingleton(RestClient.For<IGitHubClient>("https://api.github.com/"));
            // Define a url base para a interface do cliente

            services.AddSingleton(provider =>
            {
                var logger = provider.GetService<ILogger>();
                return new Dictionary<Type, ExceptionHandlingStrategy>
                {
                    { typeof(ApiException), new ApiExceptionHandlingStrategy(logger) },
                    { typeof(NotImplementedException), new NotImplementedExceptionHandlingStrategy(logger) }
                };
            });

            // SERILOG settings
            services.AddSingleton<ILogger>(new LoggerConfiguration()
                     .ReadFrom.Configuration(configuration)
                     .Enrich.WithMachineName()
                     .Enrich.WithProperty(APPLICATION_KEY, Constants.PROJECT_NAME)
                     .Enrich.WithExceptionDetails()
                     .CreateLogger());

            services
                .AddScoped<IRepositoryFacade, RepositoryFacade>()
                .AddScoped<ITokenFacade, TokenFacade>();

        }
    }
}
