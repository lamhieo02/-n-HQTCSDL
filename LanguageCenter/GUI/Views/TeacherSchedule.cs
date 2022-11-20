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
    public partial class TeacherSchedule : Form
    {
        public TeacherSchedule()
        {
            InitializeComponent();
        }

        private void DisplayScheduleList()
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("getScheduleTeacher", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            TeacherSchedule_GridView.DataSource = dt;

            int col = TeacherSchedule_GridView.Columns.Count;
            TeacherSchedule_GridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < col; i++)
            {
                TeacherSchedule_GridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }
        private void ClassManage_Load(object sender, EventArgs e)
        {
            TeacherSchedule_GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DisplayScheduleList();
        }

        private void TeacherSchedule_GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
