using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeCrudOperations
{
    public partial class Form2 : Form
    {
        private readonly Form1 _parent;
      public  string id, name, reg, @Class, Section;
        public Form2(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        public void updateInfo()
        {
            lblText.Text = "update Student";
            btnSave.Text= "Update";
            txtName.Text = name;
            txtReg.Text = reg;
            txtClass.Text = @Class;
            txtSection.Text = @Section;
        }
        public void saveInfo()
        {
            lblText.Text = "Add Student";
            btnSave.Text = "Save";
        }

        public void clear()
        {
            txtName.Text=txtReg.Text=txtClass.Text=txtSection.Text=string.Empty;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student Name is empty(>3).");
                return;
            }
            if (txtReg.Text.Trim().Length < 1)
            {
                MessageBox.Show("Student Reg is empty(>1).");
                return;
            }
            if (txtClass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student Class is empty(>1).");
                return;
            }
            if (txtSection.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student Section is empty(>1).");
                return;
            }
            if (btnSave.Text=="Save")
            {
                Student std=new Student(txtName.Text.Trim(),txtReg.Text.Trim(),txtClass.Text.Trim(),txtSection.Text.Trim());
               dbStudent.AddStudent(std);
                clear();
            }
            if (btnSave.Text=="Update")
            {
                Student std = new Student(txtName.Text.Trim(), txtReg.Text.Trim(), txtClass.Text.Trim(), txtSection.Text.Trim());
                dbStudent.updateStudent(std,id);
            }
            _parent.display();

        }
    }
}
