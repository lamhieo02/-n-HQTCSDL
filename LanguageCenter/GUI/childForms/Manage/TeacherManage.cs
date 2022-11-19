using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageCenter.GUI.childForms
{
    public partial class TeacherManage : Form
    {
        public TeacherManage()
        {
            InitializeComponent();
        }

        private void DisplayTeacherList()
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("select * from Teacher_Info", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            teacherGridview.DataSource = dt;
        }

        private void ClassManage_Load(object sender, EventArgs e)
        {
            teacherGridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            teacherGridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            teacherGridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayTeacherList();
        }

        private void GetTeacherByTeacherName(string teachername)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetTeacherByTeacherName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = teachername;
            DataTable dt = new DataTable();
            da.Fill(dt);
            teacherGridview.DataSource = dt;
        }

        private void GetTeacherByCourseName(string coursename)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetTeacherByCourseName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = coursename;
            DataTable dt = new DataTable();
            da.Fill(dt);
            teacherGridview.DataSource = dt;
        }

        private void GetTeacherByClassName(string classname)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetTeacherByClassName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = classname;
            DataTable dt = new DataTable();
            da.Fill(dt);
            teacherGridview.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) //teacher name
            {
                GetTeacherByTeacherName(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 1) //class name
            {
                GetTeacherByClassName(textBox1.Text);
            }
            if (comboBox1.SelectedIndex == 2) //course name
            {
                GetTeacherByCourseName(textBox1.Text);
            }
        }


        private void teacherGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.teacherGridview.Rows[e.RowIndex];
                textBox2.Text = row.Cells[0].Value.ToString();
                textBox3.Text = row.Cells[1].Value.ToString();
                dateTimePicker1.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox9.Text = row.Cells[4].Value.ToString();
                textBox7.Text = row.Cells[5].Value.ToString();
                textBox5.Text = row.Cells[6].Value.ToString();
            }
        }

        private void AddTeacher(string username, string name, string dateofbirth, string address, string email, string phone)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("AddTeacher", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = username;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            da.SelectCommand.Parameters.Add("@dateofbirth", SqlDbType.Date).Value = dateofbirth;
            da.SelectCommand.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = address;
            da.SelectCommand.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
            da.SelectCommand.Parameters.Add("@phone", SqlDbType.VarChar, 11).Value = phone;
            DataTable dt = new DataTable();
            da.Fill(dt);
            teacherGridview.DataSource = dt;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) ||
String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox7.Text))
                MessageBox.Show("Chưa nhập đầy đủ dữ liệu! ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    AddTeacher(textBox2.Text, textBox3.Text, dateTimePicker1.Text, textBox4.Text, textBox9.Text, textBox7.Text);
                    MessageBox.Show("Thêm dữ liệu thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayTeacherList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm không thành công! Vui lòng kiểm tra lại dữ liệu Thêm! ",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            }
        }

        private void UpdateTeacher(string username, string name, string dateofbirth, string address, string email, string phone)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("UpdateTeacher", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = username;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            da.SelectCommand.Parameters.Add("@dateofbirth", SqlDbType.Date).Value = dateofbirth;
            da.SelectCommand.Parameters.Add("@address", SqlDbType.NVarChar, 100).Value = address;
            da.SelectCommand.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
            da.SelectCommand.Parameters.Add("@phone", SqlDbType.VarChar, 11).Value = phone;
            DataTable dt = new DataTable();
            da.Fill(dt);
            teacherGridview.DataSource = dt;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrWhiteSpace(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) ||
        String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(textBox7.Text))
                MessageBox.Show("Chưa nhập đầy đủ dữ liệu! ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    UpdateTeacher(textBox2.Text, textBox3.Text, dateTimePicker1.Text, textBox4.Text, textBox9.Text, textBox7.Text);
                    MessageBox.Show("Cập nhật dữ liệu thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayTeacherList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cập nhật không thành công! Vui lòng kiểm tra lại dữ liệu cập nhật! ",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            }
        }

        private void DeleteTeacher(string username)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("DeleteTeacher", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = username;
            DataTable dt = new DataTable();
            da.Fill(dt);
            teacherGridview.DataSource = dt;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
                MessageBox.Show("Chưa nhập đầy đủ dữ liệu! ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    DeleteTeacher(textBox2.Text);
                    MessageBox.Show("Xóa dữ liệu thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayTeacherList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa không thành công! Vui lòng kiểm tra lại dữ liệu xóa! ",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            }
        }

    }
}
