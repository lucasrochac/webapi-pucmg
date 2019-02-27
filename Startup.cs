using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace web_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer( option => 
                        {
                            option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true, 
                                ValidateIssuerSigningKey = true,
                                

                                ValidIssuer = "br.com.PucApp",
                                ValidAudience = "br.com.PucApp",
                                IssuerSigningKey = Providers.JwtSecurityKey.Create("SecurityKey-12345678")
                            };
                            option.Events = new JwtBearerEvents
                            {
                                OnAuthenticationFailed = context =>
                                {
                                    Console.WriteLine("Falha de Auth: " + context.Exception.Message);
                                    return Task.CompletedTask;
                                },
                                OnTokenValidated = context =>
                                {
                                    Console.WriteLine("Auth valida: " + context.SecurityToken);
                                    return Task.CompletedTask;
                                }
                            };
                        });
            services.AddAuthorization(options => 
            {
                options.AddPolicy("Aluno",policy => policy.RequireClaim("MatriculaAluno"));
            });
            
            services.AddDbContext<WebApiContext>(
                options => options.UseSqlServer(
                Configuration.GetSection("EFCoreConnStrings:WebApiConnectionString").Value));
            
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseHttpsRedirection();

            app.UseCors("MyPolicy");
            app.UseMvc();
        }
    }
}
