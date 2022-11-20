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
    public partial class TeacherClass : Form
    {
        public TeacherClass()
        {
            InitializeComponent();
        }
        public string Name { get; set; }

        private void TeacherClass_Load(object sender, EventArgs e)
        {
            teacherClass_Gridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            teacherClass_Gridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            teacherClass_Gridview.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DisplayteacherClassList(Name);
        }
        public void DisplayteacherClassList(string name)
        {

            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetClassByTeacherName", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar, 30).Value = name;
            DataTable dt = new DataTable();
            da.Fill(dt);
            teacherClass_Gridview.DataSource = dt;
        }
    }
}
