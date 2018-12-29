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

namespace Book
{
    public partial class frmMain : MetroForm
    {
        public frmMain()
        {
            Thread t = new Thread(new ThreadStart(loading));
            t.Start();
            InitializeComponent();
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
            
        }
    }
}
