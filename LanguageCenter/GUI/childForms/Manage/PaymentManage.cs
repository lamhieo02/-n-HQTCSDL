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
    public partial class PaymentManage : Form
    {
        public PaymentManage()
        {
            InitializeComponent();
        }


        private void DisplayPaymentsList()
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("getPayments", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;

            int col = paymentGridview.Columns.Count;
            paymentGridview.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < col; i++)
            {
                paymentGridview.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void ClassManage_Load(object sender, EventArgs e)
        {
            paymentGridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // paymentGridview.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DisplayPaymentsList();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtDate.Text == "" || txtAmount.Text == "" || methodCbb.Text == "")
            {
                MessageBox.Show("Nhập thiếu dữ liệu! ", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string username = txtUsername.Text;
            string date = txtDate.Text;
            int amount = Convert.ToInt32(txtAmount.Text);
            int method = Convert.ToInt32(methodCbb.SelectedIndex) + 1;
            //int status = Convert.ToInt32(statusCbb.SelectedIndex);

            try
            {
                InsertPayment(date, amount, method, 0, username); // default status = 0
            }
            catch (Exception e1)
            {
                MessageBox.Show("Thêm không thành công! Vui lòng kiểm tra lại dữ liệu Thêm! ", "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                MessageBox.Show(e1.ToString());
            }
        }
        public void InsertPayment(string payment_date, int amount, int method_id,int status,string username)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("InsertPayment", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@payment_date", SqlDbType.Date).Value = payment_date;
            da.SelectCommand.Parameters.Add("@amount", SqlDbType.Int).Value = amount;
            da.SelectCommand.Parameters.Add("@method_id", SqlDbType.Int).Value = method_id;
            da.SelectCommand.Parameters.Add("@status", SqlDbType.Int).Value = 0;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;

            DisplayPaymentsList();
            MessageBox.Show("Thêm thành công!", "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtDate.Text == "" || txtAmount.Text == "" || methodCbb.Text == "")
            {
                MessageBox.Show("Nhập thiếu dữ liệu! ", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(txtID.Text);
            string username = txtUsername.Text;
            string payment_date = txtDate.Text;
            int amount = Convert.ToInt32(txtAmount.Text);
            int method_id = Convert.ToInt32(methodCbb.SelectedIndex) + 1;
            // status = Convert.ToInt32(statusCbb.SelectedIndex);


            try
            {
                UpdatePayment(id, payment_date, amount, method_id, username);
            }
            catch
            {
                MessageBox.Show("Update không thành công! Vui lòng kiểm tra lại dữ liệu update! ", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
        public void UpdatePayment(int id,string payment_date, int amount, int method_id,string username)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("updatePayment", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            da.SelectCommand.Parameters.Add("@payment_date", SqlDbType.Date).Value = payment_date;
            da.SelectCommand.Parameters.Add("@amount", SqlDbType.Int).Value = amount;
            da.SelectCommand.Parameters.Add("@method_id", SqlDbType.Int).Value = method_id;
            //da.SelectCommand.Parameters.Add("@status", SqlDbType.Int).Value = status;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;

            DisplayPaymentsList();
            MessageBox.Show("Update thành công!", "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtUsername.Text == "" || txtDate.Text == "" || txtAmount.Text == "" || methodCbb.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xóa!", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(txtID.Text);
            try
            {
                deletePayment(id);
            }
            catch
            {
                MessageBox.Show("Xoá không thành công! Vui lòng kiểm tra lại dữ liệu cần xóa! ", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void deletePayment(int id)
        {
            var conn = DAL.DataAccess.getConnection();
            var command = conn.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("deletePayment", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            DataTable dt = new DataTable();
            da.Fill(dt);
            paymentGridview.DataSource = dt;

            DisplayPaymentsList();
            MessageBox.Show("Xoá thành công!", "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        private void paymentGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.paymentGridview.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtUsername.Text = row.Cells[1].Value.ToString();
                txtDate.Text = row.Cells[5].Value.ToString();
                txtAmount.Text = row.Cells[6].Value.ToString();
                methodCbb.Text = row.Cells[7].Value.ToString();
                //int status;
                string statusStr = row.Cells[8].Value.ToString();
                /*if (statusStr == "Đã thanh toán") status = 1;
                else status = 0;
                statusCbb.Text = Convert.ToString(statusStr);*/
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtDate.Text = "";
            txtAmount.Text = "";
            methodCbb.Text = "";
            //statusCbb.Text = "";
            DisplayPaymentsList();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
