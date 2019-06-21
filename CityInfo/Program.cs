using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CityInfo
{
    public class Program
    {
        //  ekle => Microsoft.EntityFrameworkCore.SqlServer  # sql için 18-06-2019


        public static void Main(string[] args)
        {
            //var host = WebHost.CreateDefaultBuilder(args)
            //    .UseStartup<Startup>()
            //    .Build();
            //host.Run();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
