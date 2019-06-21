using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace CityInfo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // bu alan serialize için  add library => using Newtonsoft.Json.Serialization;
            // services.AddMvc();
            //.AddJsonOptions(o => {
            //    if(o.SerializerSettings.ContractResolver != null)
            //    {
            //        var castResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
            //        castResolver.NamingStrategy = null;
            //    }
            //});

            #region xml formatında göndermek için add library using Microsoft.AspNetCore.Mvc.Formatters;
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()
                    ));
            #endregion


            #region Sql alanı için eklendi Db context ekledik   18-06-2019

            // ilk versiyon çalışıyor
            var connectionString = @"Server=DESKTOP-INVSUP5\SQLEXPRESS; Database=CityInfoDB; Trusted_Connection=True;";

            

            services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(connectionString));

            #endregion

        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            // status codelar için ekleme yapıyoruz
            app.UseStatusCodePages();

            // mvc için
            app.UseMvc();

            #region add throw exception 
            //app.Run((context) =>
            //{
            //    throw new Exception("Example exception");
            //});
            #endregion

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
