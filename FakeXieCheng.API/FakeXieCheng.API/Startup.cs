using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FakeXieCheng.API.Database;
using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess;
using Microsoft.Extensions.Configuration;

namespace FakeXieCheng.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //设定在访问xml可以执行
            services.AddControllers(setupAction => { setupAction.ReturnHttpNotAcceptable = true; }).AddXmlDataContractSerializerFormatters();
            services.AddTransient<ITouristRouteRepository,TouristRouteRepository>();
            services.AddDbContext<AppDbContext>(option =>
            {
                //Configuration["DbContext:ConnectionString"]
                //option.UseOracle("(DESCRIPTION =     (ADDRESS_LIST =       (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.1.159)(PORT = 1521))     )     (CONNECT_DATA =       (SERVICE_NAME = orcl)     )   );User ID=BK2;Password=BK2;Persist Security Info=True;");
                //option.UseOracle(Configuration.GetConnectionString("default"));
                option.UseOracle(Configuration["DbContext:default"],b=>b.UseOracleSQLCompatibility("11"));
            });

            //设定map映射配置。通过这个可以用于 model映射dto
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //对Url进行映射。中间件的问题。  通过强大的中间件进行相应。
            //            app.Map("/test",
            //                build => { build.Run(async context => { await context.Response.WriteAsync("hello world test"); }); });
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();
            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllers();
                
//                endPoints.MapAreaControllerRoute(
//                    name: "areas", "areas",
//                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
//            app.UseHttpsRedirection();
//            app.UseStaticFiles();
//
//            app.UseRouting();
//
//            app.UseAuthorization();
//
//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller=Home}/{action=Index}/{id?}");
//            });
        }
    }
}
