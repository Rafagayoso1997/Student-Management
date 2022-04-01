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
            app.EnableVisualStyles();
            app.SetCompatibleTextRenderingDefault(false);
            app.Run(new frmStudent());
        }
    }
}
