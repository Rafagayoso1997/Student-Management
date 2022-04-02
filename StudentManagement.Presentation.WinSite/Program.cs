using Microsoft.Extensions.DependencyInjection;
using Serilog;
using StudentManagement.Application.Factories.Implementations;
using StudentManagement.Application.Services.Implementations;
using StudentManagement.Crosscutting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app = System.Windows.Forms.Application;

namespace StudentManagement.Presentation.WinSite
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = Initializer.GetLogger();
            Log.Logger.Information("Open Program");
            DefaultInitRuns();

            RunWinForms();     
        }

        private static void RunWinForms()
        {
            using (var host = Initializer.CreateDefaultBuilder().Build())
            {
                using (IServiceScope serviceScope = host.Services.CreateScope())
                {

                    IServiceProvider provider = serviceScope.ServiceProvider;
                    var formInstance = provider.GetRequiredService<frmStudent>();
                    app.Run(formInstance);
                }
            }
        }

        private static void DefaultInitRuns()
        {
            app.EnableVisualStyles();
            app.SetCompatibleTextRenderingDefault(false);
        }
    }
}
