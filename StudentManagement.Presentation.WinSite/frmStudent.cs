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
    public partial class frmStudent : Form
    {
        private IStudentService _service;

        public frmStudent(IStudentService service)
        {
            _service = service;
            InitializeComponent();
        }

        private void indexChange(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            MessageBox.Show($"{Factory.TXT == (Factory)combo.SelectedItem }");
           ;
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(Factory)))
            {
                comboFile.Items.Add(item);
            }

            Factory factory = (Factory)comboFile.Items[0];
            var sd = factory.ToString();
            var path = Utils.GetFilePath(sd);
            dataGridView1.DataSource = _service.GetAllStudents(path);
            dataGridView1.Columns["Guid"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;
        }
    }
}
