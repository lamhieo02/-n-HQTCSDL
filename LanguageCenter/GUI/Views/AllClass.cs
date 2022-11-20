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
    public partial class AllClass : Form
    {
        public AllClass()
        {
            InitializeComponent();
        }
        private void AllClass_Load(object sender, EventArgs e)
        {
            AllClass_Gridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AllClass_Gridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AllClass_Gridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayAllClassesList();
        }
        public void DisplayAllClassesList()
        {

            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("getAllClasses", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
        }

        private void searchCbb_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (searchCbb.SelectedIndex == 0) //class name
            {
                GetClassByClasssName(txtSearch.Text);
            }
            if (searchCbb.SelectedIndex == 1) //teacher name
            {
                GetClassByTeacherName(txtSearch.Text);
            }
            if (searchCbb.SelectedIndex == 2) //course name
            {
                GetClassByCourseName(txtSearch.Text);
            }
        }
        public void GetClassByTeacherName(string name)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassByTeacherName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 30).Value = name;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
        }
        public void GetClassByClasssID(int id)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassByClassID", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
        }
        public void GetClassByClasssName(string name)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassByClassName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
        }
        public void GetClassByCourseName(string name)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassByCourseName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("getAllClasses", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            AllClass_Gridview.DataSource = dt;
            ;
            dt.DefaultView.RowFilter = string.Format("convert(ID, 'System.String') LIKE '%{0}%' OR" +
                                                     "[Class Name] LIKE '%{0}%' OR " +
                                                     "[Teacher Name] LIKE '%{0}%' OR" +
                                                     "[Course Name] LIKE '%{0}%' OR" +
                                                     "[ClassRoom] LIKE '%{0}%' OR" +
                                                     "[WeekDays] LIKE '%{0}%' OR" +
                                                     " convert(No_Students, 'System.String') LIKE '%{0}%'", txtSearch.Text);
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            DisplayAllClassesList();
        }
    }
}
