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
        private string path;

        public frmStudent(IStudentService service)
        {
            _service = service;
            InitializeComponent();
        }

        private void indexChange(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
           
            Factory factory = (Factory)combo.SelectedItem;
            var sd = factory.ToString();

            _service.SetIRepositoryFactory(factory);
            var path = Utils.GetFilePath(sd);
            dataGridView1.DataSource = _service.GetAllStudents(path);
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(Factory)))
            {
                comboFile.Items.Add(item);
            }

            Factory factory = (Factory)comboFile.Items[2];
            var sd = factory.ToString();
            var path = Utils.GetFilePath(sd);
            dataGridView1.DataSource = _service.GetAllStudents(path);
            dataGridView1.Columns["Guid"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //Factory factory = (Factory)comboFile.Items[0];
            //var sd = factory.ToString();
            //var path = Utils.GetFilePath(sd);
            //new Form1(_service, path).ShowDialog();
        }
    }
}
