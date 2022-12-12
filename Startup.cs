using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using bcquant.Models;
using bcquant.Domain.Interfaces;
using bcquant.Controllers;
using bcquant.Domain.Concrete;

namespace bcquant
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

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });

            services.AddScoped<IUnidadeConstrutivaRepository, UnidadeConstrutivaRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IAmbienteBasicoRepository, AmbienteBasicoRepository>();
            services.AddScoped<IConstrutorRepository, ConstrutorRepository>();
            services.AddScoped<ICorRepository, CorRepository>();
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IMateriaPrimaRepository, MateriaPrimaRepository>();
            services.AddScoped<IPavimentoRepository, PavimentoRepository>();
            services.AddScoped<IPosicaoRepository, PosicaoRepository>();
            services.AddScoped<ITipologiaRepository, TipologiaRepository>();
            services.AddScoped<ITipoLevantamentoRepository, TipoLevantamentoRepository>();
            services.AddScoped<IUnidadeDeMedidaRepository, UnidadeDeMedidaRepository>();
            services.AddScoped<IGrupoDeInsumoRepository, GrupoDeInsumoRepository>();
            services.AddScoped<IGrupoDeServicoRepository, GrupoDeServicoRepository>();
            services.AddScoped<IItensDeLevantamentoRepository, ItensDeLevantamentoRepository>();
            services.AddScoped<IServicoBcRepositoryRepository, ServicoBcRepository>();
            services.AddScoped<IInsumoRepository, InsumoRepository>();
            services.AddScoped<IObraRepository, ObraRepository>();
            services.AddScoped<IUnidadeConstrutivaObraRepository, UnidadeConstrutivaObraRepository>();
            services.AddScoped<IPavimentoObraRepository, PavimentoObraRepository>();
            services.AddScoped<ILevantamentoRepository, LevantamentoRepository>();
            services.AddScoped<IStatusLevantamentoRepository, StatusLevantamentoRepository>();
            services.AddScoped<IAmbienteRepository, AmbienteRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connection = Configuration["ConexaoMySql:MySqlConnectionString"];
            services.AddDbContext<bcquant_localContext>(options =>
                options.UseMySql(connection)
            );
            // Add framework services.
             services.AddMvc();

            //services.AddMvc().AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
