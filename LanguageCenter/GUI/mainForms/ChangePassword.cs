using LanguageCenter.BLL;
using LanguageCenter.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageCenter.GUI.mainForms
{
    public partial class ChangePassword : Form
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ChangePassword()
        {
            InitializeComponent();
        }   
        public void changePassword(string username, string password)
        {
            AccountDAO account = new AccountDAO();
            int result = 1;
            try
            {
                account.changePassword(username, password);
            }
            catch
            {
                MessageBox.Show("Password không đủ điều kiện!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = 0;
            }
            if(result == 1 )
            {
                MessageBox.Show("Đổi mật khẩu thành công!","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void XuliChangePw()
        {
            string username = Username;
            string password = txtPassword1.Text;
            string password2 = txtPassword2.Text;
            if (password == "" || password2 == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (password == password2)
                {
                    changePassword(username, password);
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void changePasswordBtn_Click(object sender, EventArgs e)
        {
            XuliChangePw();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Username;
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Return))
            {
                XuliChangePw();
            }
        }
    }
}
