using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using StudentManagement.Application.Factories.Contracts;
using StudentManagement.Application.Factories.Implementations;
using StudentManagement.Application.Services.Contracts;
using StudentManagement.Application.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Presentation.WinSite
{
    public class Initializer
    {


        public static Logger GetLogger() => new LoggerConfiguration()
             .MinimumLevel.Information()
             .WriteTo.Console()
             .WriteTo.File(@"logs\log.txt", rollingInterval: RollingInterval.Day)
             .CreateLogger();

        public static IHostBuilder CreateDefaultBuilder()
        {
            return Host.CreateDefaultBuilder()
                //.ConfigureAppConfiguration(app =>
                //{
                //    app.AddJsonFile(@"appsetting.json", false, true);
                //})
                .ConfigureServices((context, services) =>
                {
                    var config = context.Configuration;

                    //services.Configure<JSON>(config.GetSection("JSON"));
                    //services.Configure<TXT>(config.GetSection("TXT"));
                    //services.Configure<XML>(config.GetSection("XML"));

                    services.AddSingleton<IRepositoryFactory, JsonRepositoryFactory>();
                    services.AddSingleton<IStudentService, StudentService>();
                    services.AddScoped<frmStudent>();
                })
                .UseSerilog();
        }


        public class JSON
        {
            public string PathFile { get; set; }
        }

        public class TXT
        {
            public string PathFile { get; set; }
        }

        public class XML
        {
            public string PathFile { get; set; }
        }
    }
}
