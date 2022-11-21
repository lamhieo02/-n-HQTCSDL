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
    public partial class LichSuGiaoDich : Form
    {
        string paymentUsername = "";
        public LichSuGiaoDich(string paymentUsername)
        {
            InitializeComponent();
            this.paymentUsername = paymentUsername;
        }
        private void DisplayTransactionHistory()
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("GetTransactionHistory", conn);
            da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = paymentUsername;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);
            TransactionHistory.DataSource = dt;

            int col = TransactionHistory.Columns.Count;
            TransactionHistory.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < col; i++)
            {
                TransactionHistory.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void ClassManage_Load(object sender, EventArgs e)
        {
            TransactionHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DisplayTransactionHistory();
        }

        private void studentGridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
