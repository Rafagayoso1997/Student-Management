using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Crosscutting.Models
{
    public static class Utils
    {
        
        public static string GetFilePath(string extension)
        {
            string _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            return Path.Combine(_desktopPath, ConfigurationManager.AppSettings[extension]);
        }

        public static void DeleteIfExist(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}
