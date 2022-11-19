
namespace LanguageCenter.GUI
{
    partial class Student_HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.changePwBtn = new System.Windows.Forms.Button();
            this.LichsugiaodichBtn = new System.Windows.Forms.Button();
            this.scheduleBtn = new System.Windows.Forms.Button();
            this.profileBtn = new System.Windows.Forms.Button();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1223, 86);
            this.panel1.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Image = global::LanguageCenter.Properties.Resources.reading_book;
            this.txtName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Location = new System.Drawing.Point(981, 0);
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(0, 30, 10, 25);
            this.txtName.Size = new System.Drawing.Size(242, 77);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "        Pham Quynh Huong";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::LanguageCenter.Properties.Resources.education;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 30, 0, 25);
            this.label1.Size = new System.Drawing.Size(255, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "                Language Center";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.logoutBtn);
            this.panel2.Controls.Add(this.changePwBtn);
            this.panel2.Controls.Add(this.LichsugiaodichBtn);
            this.panel2.Controls.Add(this.scheduleBtn);
            this.panel2.Controls.Add(this.profileBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 539);
            this.panel2.TabIndex = 2;
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.logoutBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoutBtn.FlatAppearance.BorderSize = 0;
            this.logoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.logoutBtn.ForeColor = System.Drawing.Color.White;
            this.logoutBtn.Image = global::LanguageCenter.Properties.Resources.logout;
            this.logoutBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutBtn.Location = new System.Drawing.Point(0, 384);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.logoutBtn.Size = new System.Drawing.Size(273, 96);
            this.logoutBtn.TabIndex = 7;
            this.logoutBtn.Text = "         Đăng xuất";
            this.logoutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // changePwBtn
            // 
            this.changePwBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.changePwBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.changePwBtn.FlatAppearance.BorderSize = 0;
            this.changePwBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePwBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.changePwBtn.ForeColor = System.Drawing.Color.White;
            this.changePwBtn.Image = global::LanguageCenter.Properties.Resources.settings;
            this.changePwBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changePwBtn.Location = new System.Drawing.Point(0, 288);
            this.changePwBtn.Name = "changePwBtn";
            this.changePwBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.changePwBtn.Size = new System.Drawing.Size(273, 96);
            this.changePwBtn.TabIndex = 6;
            this.changePwBtn.Text = "         Đổi mật khẩu";
            this.changePwBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changePwBtn.UseVisualStyleBackColor = false;
            this.changePwBtn.Click += new System.EventHandler(this.changePwBtn_Click);
            // 
            // LichsugiaodichBtn
            // 
            this.LichsugiaodichBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.LichsugiaodichBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.LichsugiaodichBtn.FlatAppearance.BorderSize = 0;
            this.LichsugiaodichBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LichsugiaodichBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.LichsugiaodichBtn.ForeColor = System.Drawing.Color.White;
            this.LichsugiaodichBtn.Image = global::LanguageCenter.Properties.Resources.credit_card;
            this.LichsugiaodichBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LichsugiaodichBtn.Location = new System.Drawing.Point(0, 192);
            this.LichsugiaodichBtn.Name = "LichsugiaodichBtn";
            this.LichsugiaodichBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.LichsugiaodichBtn.Size = new System.Drawing.Size(273, 96);
            this.LichsugiaodichBtn.TabIndex = 4;
            this.LichsugiaodichBtn.Text = "         Lịch sử giao dịch";
            this.LichsugiaodichBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LichsugiaodichBtn.UseVisualStyleBackColor = false;
            this.LichsugiaodichBtn.Click += new System.EventHandler(this.LichsugiaodichBtn_Click);
            // 
            // scheduleBtn
            // 
            this.scheduleBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.scheduleBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.scheduleBtn.FlatAppearance.BorderSize = 0;
            this.scheduleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scheduleBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.scheduleBtn.ForeColor = System.Drawing.Color.White;
            this.scheduleBtn.Image = global::LanguageCenter.Properties.Resources.schedule;
            this.scheduleBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scheduleBtn.Location = new System.Drawing.Point(0, 96);
            this.scheduleBtn.Name = "scheduleBtn";
            this.scheduleBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.scheduleBtn.Size = new System.Drawing.Size(273, 96);
            this.scheduleBtn.TabIndex = 1;
            this.scheduleBtn.Text = "         Thời khóa biểu";
            this.scheduleBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scheduleBtn.UseVisualStyleBackColor = false;
            this.scheduleBtn.Click += new System.EventHandler(this.scheduleBtn_Click);
            // 
            // profileBtn
            // 
            this.profileBtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.profileBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.profileBtn.FlatAppearance.BorderSize = 0;
            this.profileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profileBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.profileBtn.ForeColor = System.Drawing.Color.White;
            this.profileBtn.Image = global::LanguageCenter.Properties.Resources.user;
            this.profileBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profileBtn.Location = new System.Drawing.Point(0, 0);
            this.profileBtn.Name = "profileBtn";
            this.profileBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.profileBtn.Size = new System.Drawing.Size(273, 96);
            this.profileBtn.TabIndex = 0;
            this.profileBtn.Text = "         Hồ sơ";
            this.profileBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profileBtn.UseVisualStyleBackColor = false;
            this.profileBtn.Click += new System.EventHandler(this.profileBtn_Click);
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Controls.Add(this.button1);
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(273, 86);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(950, 539);
            this.panelDesktopPane.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Image = global::LanguageCenter.Properties.Resources._5514;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(950, 539);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Student_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 625);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Student_HomePage";
            this.Text = "Student_HomePage";
            this.Load += new System.EventHandler(this.Student_HomePage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelDesktopPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Button profileBtn;
        private System.Windows.Forms.Button LichsugiaodichBtn;
        private System.Windows.Forms.Button scheduleBtn;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button changePwBtn;
    }
}