using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using PBWebApi.DataAccess;
using PBWebApi.DataAccess.Repositories;

namespace PBWebApi.Api._21
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
            services.AddScoped<EnderecoContext>();
            services.AddScoped<PessoasRepository>();
         
            services.AddDbContext<EnderecoContext>(opt =>
                opt.UseInMemoryDatabase("EnderecoInventory"));
            services.AddDbContext<PessoaContext>(opt =>
                opt.UseInMemoryDatabase("PessoaInventory"));

            #region snippet_SetCompatibilityVersion
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "PBWebApi ASP.NET Core 2.1 - By Miquéias Rafael",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Author: Miquéias Rafael",
                        Email = "rafaelh3r@yahoo.com.br",
                        Url = "http://planobom.com"
                    },
                    /* TermsOfService = "Não aplicável",
                     * License = new License
                    {
                        Name = "CC BY",
                        Url = "http://planobom.com"
                    }*/
                });
            });

            #region snippet_ConfigureApiBehaviorOptions
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressConsumesConstraintForFormFileParameters = true;
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
            });
            #endregion
        }

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

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                c.RoutePrefix = string.Empty; //docs                   
            });

            app.UseMvc();
        }
    }
}
