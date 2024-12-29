using System;
using System.Windows.Forms;

namespace EmployeeCrudOperations
{
    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2(this);
        }
        public void display()
        {
            dbStudent.displayAndSearch("SELECT ID,Name,Reg,Class,Section FROM student1", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            form2.clear();
            form2.saveInfo();
            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            display();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dbStudent.displayAndSearch("SELECT ID,Name,Reg,Class,Section FROM student1 WHERE Name LIKE'%" + txtSearch.Text + "%'", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Edit
            if (e.ColumnIndex == 0)
            {
                form2.clear();
                form2.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form2.name = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form2.reg = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form2.@Class = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form2.Section = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form2.updateInfo();
                form2.ShowDialog();
                return;
            }
            //delete
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are You Want to Delete Student Records?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dbStudent.deleteStudent(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    display();
                }
                return;
            }
        }
    }
}
