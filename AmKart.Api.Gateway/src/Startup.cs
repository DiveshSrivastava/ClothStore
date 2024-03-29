using AmKart.Common.Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AmKart.Common.RestEase;
using AmKart.Api.Services;
using System.Reflection;
using Autofac;
using AmKart.Common.RabbitMq;
using AmKart.Common.Dispatchers;
using AmKart.Common.Mvc;
using AmKart.Common;
using Consul;
using Microsoft.Extensions.Hosting;
using AmKart.Common.Authentication;

namespace AmKart.Api.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                        cors.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
            });
            services.AddJwt();
            services.AddOpenTracing();
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));

            services.AddConsul();
            services.AddControllers();
            services.RegisterServiceForwarder<IProductsService>("products-service");
            services.RegisterServiceForwarder<IIdentityService>("identity-service");
            services.RegisterServiceForwarder<IOrdersService>("orders-service");
        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                    .AsImplementedInterfaces();
            builder.AddRabbitMq();
            builder.AddDispatchers();
        }

        public void Configure(IApplicationBuilder app, IStartupInitializer startupInitializer,
            IConsulClient client, IHostApplicationLifetime applicationLifetime)
        {
            app.UseHttpsRedirection();
            app.UseRabbitMq();
            app.UseAllForwardedHeaders();
            app.UseServiceId();
            app.UseAuthentication();

            var consulServiceId = app.UseConsul();
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                client.Agent.ServiceDeregister(consulServiceId);
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(routes =>
            {
                routes.MapControllers();
            });

            startupInitializer.InitializeAsync();
        }
    }
}
