using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using BusinessLogicLayer;

namespace Book
{
    public partial class frmLogin : MetroForm
    {
        AccountBLL db;
        string username;
        string password;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void linkForgotPass_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this,"Liên hệ quản trị viên để lấy lại!", "Thông Báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Information, 120);
        }
        void CheckLogin()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(20);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string err = null;
            username = txtUserName.Text;
            password = txtPassword.Text;
            if (chkRemember.Checked)
            {
                Properties.Settings.Default.UserName = username;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = string.Empty;
                Properties.Settings.Default.Password = string.Empty;
                Properties.Settings.Default.Save();
            }
            frmMain fmain = new frmMain(username, password,ref err);
            if (err == null)
            {
                MetroMessageBox.Show(this, "Đăng nhập thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, 120);

                this.Hide();
                fmain.ShowDialog();
                this.Show();
            }
            else MetroMessageBox.Show(this, err, "Thông Báo", MessageBoxButtons.OK,
                MessageBoxIcon.Error,120);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                chkRemember.Checked = true;
                txtUserName.Text = Properties.Settings.Default.UserName;
                txtPassword.Text = Properties.Settings.Default.Password;
            }
        }
    }
}
