using Microsoft.Extensions.Logging;
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
        private readonly IStudentService _service;
        private readonly ILogger<frmStudent> _logger;

        private string path;

        public frmStudent(IStudentService service, ILogger<frmStudent> logger)
        {
            _logger = logger;
            _service = service;
            InitializeComponent();
        }

        private void indexChange(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
           
            Factory factory = (Factory)combo.SelectedItem;
            var sd = factory.ToString();

            _service.SetIRepositoryFactory(factory);
            path = Utils.GetFilePath(sd);
            dataGridView1.DataSource = _service.GetAllStudents(path);
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(Factory)))
            {
                comboFile.Items.Add(item);
            }

            comboFile.SelectedItem = comboFile.Items[0];

            
            path = Utils.GetFilePath(Factory.JSON.ToString());
            dataGridView1.DataSource = _service.GetAllStudents(path);
            dataGridView1.Columns["Guid"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;


        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Factory factory = (Factory)comboFile.SelectedItem;
            var sd = factory.ToString();
            path = Utils.GetFilePath(sd);
            new frmAddStudent(_service, path).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student student = (Student)dataGridView1.CurrentRow.DataBoundItem;
            _service.DeleteStudent(student, path);
            dataGridView1.DataSource = _service.GetAllStudents(path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student student = (Student)dataGridView1.CurrentRow.DataBoundItem;
            _service.UpdateStudent(student, path);
            dataGridView1.DataSource = _service.GetAllStudents(path);
        }
    }
}
