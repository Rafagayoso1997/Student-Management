using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
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

            return Path.Combine(_desktopPath, System.Configuration.ConfigurationManager.AppSettings[extension]);
        }

        public static void DeleteIfExist(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }

        public static void CreateIfDoesntExist(string path)
        {
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                file.Create();
                
            }
        }

        public static Student mapStudentFromTextToList(string student)
        {
            string [] spllitedData = student.Split(',');
            Student studentsMapped = new Student(int.Parse(spllitedData[1]), spllitedData[2], spllitedData[3], 
                DateTime.Parse(spllitedData[4]));
            studentsMapped.Guid = Guid.Parse(spllitedData[0]);

            return studentsMapped;
        }

       

    }
}
