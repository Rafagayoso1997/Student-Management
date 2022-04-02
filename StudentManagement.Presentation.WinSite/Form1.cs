using StudentManagement.Application.Services.Contracts;
using StudentManagement.Crosscutting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Presentation.WinSite
{
    public partial class Form1 : Form
    {
        private IStudentService _service;
        private string _path;
        public Form1(IStudentService service, string path)
        {
            _service = service;
            _path = path;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student studdent = new Student(int.Parse(idTextBox.Text),nameTextBox.Text, surnameTextBox.Text, 
                DateTime.Parse(calendar.SelectionRange.Start.ToString()));

            _service.SaveStudent(studdent, _path);
            
        }
    }
}
