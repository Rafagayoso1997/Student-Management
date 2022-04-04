
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using StudentManagement.Application.Factories.Contracts;
using StudentManagement.Application.Services.Contracts;
using StudentManagement.Application.Services.Implementations;
using StudentManagement.Crosscutting.Models;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Presentation.WinSite
{
    public static class Initializer
    {

        public static Logger GetLogger() => new LoggerConfiguration()
             .MinimumLevel.Information()
             .WriteTo.Console()
             .WriteTo.File(@"logs\log.txt", rollingInterval: RollingInterval.Day)
             .CreateLogger();

        public static IHostBuilder CreateDefaultBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IAbstractRepositoryFactory, FileRepositoryFactory>();
                    services.AddSingleton<IStudentService, StudentService>();
                    services.AddScoped<IFileSystem, FileSystem>();
                    services.AddScoped<frmStudent>();
                })
                .UseSerilog();
        }
    }
}
