using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHorasExtras.Controllers.ControlUcColaborador
{
    public partial class ColaboradorUC : UserControl
    {

        public ColaboradorUC()
        {
            InitializeComponent();
        }

        [Category("Custom Props")]
        public string NomeColaborador
        {
            get { return this.labelNomeColaborador.Text; }
            set { this.labelNomeColaborador.Text = value; }
        }

        [Category("Custom Props")]
        public Image FotoColaborador
        {
            get { return this.btnFotoColaborador.Image; }
            set { this.btnFotoColaborador.Image = value; }
        }

        [Category("ActionClick")]
        public Button BotaoExcluir
        {
            get { return this.btnExcluiColaborador; }
            set { this.btnExcluiColaborador.Visible = true; }
        }

        [Category("Custom Props")]
        public Button LabelNomeColab
        {
            get { return this.labelNomeColaborador; }
            set { this.labelNomeColaborador.Visible = true; }
        }


        [Category("Custom Props")]
        public Button botaoColaborador
        {
            get { return this.btnFotoColaborador; }
            set { this.btnFotoColaborador = value; }
        }

    }
}
