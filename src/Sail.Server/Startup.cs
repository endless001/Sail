using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sail.Configuration.DependencyInjection;
using Sail.Configuration;
using Microsoft.AspNetCore.Authorization;
using Sail.Authorization.Secret;
using Microsoft.AspNetCore.Authentication.Cookies;
using Sail.Authentication.Secret;
using Sail.RateLimit.Middleware;


namespace Sail.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetValue<string>("RedisConfig:ConnectionString");
            services.AddReverseProxy().LoadFromStore(options => { });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Secret", builder => builder.RequireAuthenticatedUser());
                options.AddPolicy("Bearer", builder => builder.RequireAuthenticatedUser());
                options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();


            });

      
            services.AddAuthentication(SecretDefaults.AuthenticationScheme)
                   .AddSecret();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
              .AddIdentityServerAuthentication(options =>
              {
              });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy();
            });

        }
    }
}
