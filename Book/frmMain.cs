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
using MetroFramework.Forms;
using BusinessLogicLayer;
using MetroFramework;

namespace Book
{
    public partial class frmMain : MetroForm
    {
        DataSet ds;
        AccountBLL db;

        private string username;
        private string password;
        //string err = null;
        public frmMain(string username, string password, ref string err)
        {
            Thread t = new Thread(new ThreadStart(loading));
            t.Start();
            InitializeComponent();
            this.username = username;
            this.password = password;
            ds = new DataSet();
            db = new AccountBLL(username,password,ref err);
            for (int i = 0; i < 100; i++)
                Thread.Sleep(20);
            t.Abort();
        }
        void loading()
        {
            frmWaitForm frm = new frmWaitForm();
            Application.Run(frm);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DataBind();
        }
        private void DataBind()
        {
            string err = null;
            ds = db.getAccounts(ref err);
            if (err != null)
                MetroMessageBox.Show(this, err, "Thông Báo", MessageBoxButtons.OK,
                MessageBoxIcon.Error, 120);
            else
                dgvAcc.DataSource = ds.Tables[0];
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string err = null;
            if(!db.changePassword(ref err,username,txtNew.Text,txtOle.Text))
                MetroMessageBox.Show(this, err, "Thông Báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error, 120);
            else MetroMessageBox.Show(this, "Đổi mật khẩu thành công", "Thông Báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information, 120);
        }
    }
}
