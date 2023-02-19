using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHorasExtras.Controllers.FormMessageBox
{
    public partial class FormMessage : Form
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

        // construtor que contem um botao OK
        public FormMessage(string titulo, string mensagem, Image imagem, MessageBoxButtons button1)
        {
            InitializeComponent();
            Inicializabotoes();
            this.ImagemLogo.Image = imagem;
            this.panelbuttons.Visible = true;
            this.labelTitulo.Text = titulo;
            this.labelMensagem.Text = mensagem;
            
            // modifica o messageBox para um botao 
            AlteraBotao(button1);
        }

        // construtor que contem 2 botoes Sim e Nao
        public FormMessage(string titulo, string mensagem, Image imagem, MessageBoxButtons _button1, MessageBoxButtons button2)
        {
            InitializeComponent();
            Inicializabotoes();
            this.ImagemLogo.Image = imagem;
            this.labelTitulo.Text = titulo;
            this.labelMensagem.Text = mensagem;

            // modifica o messageBox para dois botoes
            AlteraBotao(_button1);
        }

        public FormMessage(string titulo, Exception ex, Image imagem, MessageBoxButtons messageBoxButtons)
        {
            InitializeComponent();
            Inicializabotoes();
            this.ImagemLogo.Image = imagem;
            this.labelMensagem.Text = (string)ex.ToString();
            this.labelTitulo.Text = titulo;
        }

        // reseta o form para ser inicializado
        private void Inicializabotoes()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.buttonSim.DialogResult = DialogResult.Yes;
            this.buttonNão.DialogResult = DialogResult.No;
            this.buttonSim.Visible = false;
            this.buttonNão.Visible = false;
        }

        // seleciona os tipos de botoes do form
        private void AlteraBotao(MessageBoxButtons button)
        {
            // seta tamanho do painel onde estam os botoes SIM OK e NAO
            int xCenter = (this.panelbuttons.Width - buttonSim.Width) / 2;
            int yCenter = (this.panelbuttons.Height - buttonSim.Height) / 2;

            // verifica qual tipo de construtor de um ou dois botoes
            switch (button)
            {
                // caso for um botao seta o MessageBox para um botao OK
                case MessageBoxButtons.OK:
                    this.buttonSim.Visible = true;
                    this.buttonNão.Visible = false;
                    buttonSim.Location = new Point(xCenter, yCenter);
                    buttonSim.Text = "OK";
                    buttonSim.DialogResult = DialogResult.Yes;
                    break;
                
                // caso dois botoes seta o MessageBox para botao SIM e botao NAO 
                case MessageBoxButtons.YesNo:
                    // botao sim
                    this.buttonSim.Visible = true;
                    buttonSim.Text = "SIM";
                    buttonSim.DialogResult = DialogResult.Yes;

                    // botao nao
                    this.buttonNão.Visible = true;
                    buttonNão.Text = "NÃO";
                    buttonNão.DialogResult = DialogResult.No;
                    break;
            }
        }

        #region -> Drag Form
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
