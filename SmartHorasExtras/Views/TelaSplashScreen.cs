using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHorasExtras.Views
{
    public partial class TelaSplashScreen : Form
    {

        public TelaSplashScreen()
        {
            InitializeComponent();

            // deixa o cory com o ano atual
            labelCopy.Text = DateTime.Now.ToString("© yyyy");
        }

        // metodo para fazer a barra animada do splash Screen
        private void timer1_Tick(object sender, EventArgs e)
        {
            panelSlide.Width += 2;

            // verifica o width de tela principal
            if (panelSlide.Width > 810)
            {
                panelSlide.Width = 0;
            }

        }


    }
}
