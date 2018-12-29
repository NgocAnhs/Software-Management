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

namespace Book
{
    public partial class frmLogin : MetroForm
    {
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
            if (true)
            {
                if (chkRemember.Checked)
                {
                    Properties.Settings.Default.UserName = txtUserName.Text;
                    Properties.Settings.Default.Password = txtPassword.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.UserName = string.Empty;
                    Properties.Settings.Default.Password = string.Empty;
                    Properties.Settings.Default.Save();
                }
                MetroMessageBox.Show(this,"Đăng nhập thành công!","Thông Báo",
                    MessageBoxButtons.OK,MessageBoxIcon.Information,120);              
                
                this.Hide();
                frmMain fmain = new frmMain();
                fmain.ShowDialog();
                this.Show();

            }
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
