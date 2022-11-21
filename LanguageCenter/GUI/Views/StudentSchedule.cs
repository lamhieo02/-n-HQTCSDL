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
    public partial class StudentSchedule : Form
    {
        string usernameStudent;
        public StudentSchedule(string Username)
        {
            usernameStudent = Username;
            InitializeComponent();
        }
        private void DisplayScheduleList()
        {
            var conn = DAL.DataAccess.getConnection();
            //var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("getScheduleStudent", conn);
            da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = usernameStudent;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);
            schedule_Gridview.DataSource = dt;

            int col = schedule_Gridview.Columns.Count;
            schedule_Gridview.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < col; i++)
            {
                schedule_Gridview.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void ClassManage_Load(object sender, EventArgs e)
        {
            schedule_Gridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DisplayScheduleList();
        }

        private void schedule_Gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
