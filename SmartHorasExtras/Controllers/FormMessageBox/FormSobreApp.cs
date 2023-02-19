using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHorasExtras.Controllers.FormMessageBox
{
    public partial class FormSobreApp : Form
    {
        // sombreamento do form
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public FormSobreApp()
        {
            InitializeComponent();
        }

        private void btnSair_MouseEnter(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.Red;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void btnSair_MouseDown(object sender, MouseEventArgs e)
        {
            btnSair.BackColor = Color.Red;
        }

        private void btnSair_MouseUp(object sender, MouseEventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
