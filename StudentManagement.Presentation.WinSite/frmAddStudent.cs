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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.Presentation.WinSite
{
    public partial class frmAddStudent : Form
    {
        private IStudentService _service;
        private readonly ILogger<frmStudent> _logger;
        private string _path;
        private DataGridView _grid;
        public frmAddStudent(IStudentService service, string path, ILogger<frmStudent> logger, DataGridView grid)
        {
            _service = service;
            _path = path;
            _logger = logger;
            _grid = grid;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Student studdent = new Student(int.Parse(idTextBox.Text), nameTextBox.Text, surnameTextBox.Text,
                calendar.Value);

                _service.SaveStudent(studdent, _path);
                _grid.DataSource = _service.GetAllStudents(_path);
                Button btn = (Button)sender;
                this.Close();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }

        private void idTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar.Equals('.')))
            {
                e.Handled = true;
            }
        }
    }
}
