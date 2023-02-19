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
    public partial class FormColaboradorAdd : Form
    {
        TelaPrincipal tela_principal = Application.OpenForms.OfType<TelaPrincipal>().FirstOrDefault();
        private bool btnCancelarClicado = false;

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

        // construtor
        public FormColaboradorAdd(MessageBoxButtons button1)
        {
            InitializeComponent();
            Inicializabotoes();

            // seta tipo de botoes
            AlteraBotao(button1);

            // seta texto padrao do comboTipoUser
            if (tela_principal.NomeUsuario == "Desenv")
            {
                comboBoxTipoUser.Text = "Admin";
            }
            else
            {
                comboBoxTipoUser.Text = "Colaborador";
            }
        }

        // reseta os botoes form para ser inicializado
        private void Inicializabotoes()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.buttonSalvar.DialogResult = DialogResult.Yes;
            this.buttonCancelar.DialogResult = DialogResult.No;
            this.buttonSalvar.Visible = false;
            this.buttonCancelar.Visible = false;
        }


        // metodos para acessar texto digitado pelo usuario
        public string RecebetextoNome()
        {
            return this.textBoxNomeColabador.Text;
        }

        public string RecebetextoDepartamento()
        {
            return this.textBoxDepartamento.Text;
        }

        public string RecebeTipoUsuario()
        {
            return this.comboBoxTipoUser.Text;
        }

        // seleciona os tipos de botoes do form
        private void AlteraBotao(MessageBoxButtons button)
        {
            // seta tamanho do painel onde estam os botoes SIM OK e NAO
            int xCenter = (this.panelButtonColab.Width - buttonSalvar.Width) / 2;
            int yCenter = (this.panelButtonColab.Height - buttonSalvar.Height) / 2;

            // verifica qual tipo de construtor de um ou dois botoes
            switch (button)
            {
                // caso dois botoes seta o MessageBox para botao SIM e botao NAO 
                case MessageBoxButtons.YesNo:
                    // botao Salvar
                    this.buttonSalvar.Visible = true;
                    buttonSalvar.Text = "Salvar";
                    buttonSalvar.DialogResult = DialogResult.Yes;

                    // botao Cancelar
                    this.buttonCancelar.Visible = true;
                    buttonCancelar.Text = "Cancelar";
                    buttonCancelar.DialogResult = DialogResult.No;
                    break;
            }
        }

        // verifica se os campos foram preechidos corretamente
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string ErroName = "Nome", ErroDepartamento = "Departamento", ErroTipoUsuario = "Tipo Usuario";

            if (string.IsNullOrEmpty(textBoxNomeColabador.Text) || string.IsNullOrEmpty(textBoxDepartamento.Text) || string.IsNullOrEmpty(comboBoxTipoUser.Text))
            {
                if (string.IsNullOrEmpty(textBoxNomeColabador.Text))
                {
                    this.Hide();
                    FormMessage erro = new FormMessage("Erro", "O campo " + ErroName + " está vazio.\nPor favor, entre com o Nome do Colaborador", SmartHorasExtras.Properties.Resources.erro1, MessageBoxButtons.OK);

                    erro.ShowDialog();

                    textBoxNomeColabador.Focus();

                    DialogResult = DialogResult.No;
                    // mostra form adicionar infomacoes colaborador
                    this.Show();
                }
                else if (string.IsNullOrEmpty(textBoxDepartamento.Text))
                {
                    this.Hide();
                    FormMessage erro = new FormMessage("Erro", "O campo " + ErroDepartamento + " está vazio.\nPor favor, entre com o Nome do Departamento", SmartHorasExtras.Properties.Resources.erro1, MessageBoxButtons.OK);

                    erro.ShowDialog();

                    textBoxDepartamento.Focus();

                    DialogResult = DialogResult.No;
                    // mostra form adicionar infomacoes colaborador
                    this.Show();
                }
                else if (string.IsNullOrEmpty(comboBoxTipoUser.Text))
                {
                    this.Hide();
                    FormMessage erro = new FormMessage("Erro", "O campo " + ErroTipoUsuario + " está vazio.\nPor favor, Selecione o tipo de usuário", SmartHorasExtras.Properties.Resources.erro1, MessageBoxButtons.OK);

                    erro.ShowDialog();

                    DialogResult = DialogResult.No;
                    // mostra form adicionar infomacoes colaborador
                    this.Show();
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            // verifica se botao cancelar foi valido
            if (btnCancelarClicado == true)
            {
                // mosta messagem de para sair da tela
                MessagemSairDiaglo();
            }

        }


        private void buttonCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelarClicado = true;
        }

        // metodo pergunta para sair da tela de adicionar colaborador
        private void MessagemSairDiaglo()
        {

            FormMessage msgAtencao = new FormMessage("Atenção", "Deseja Sair ?", SmartHorasExtras.Properties.Resources.pergunta1, MessageBoxButtons.YesNo);

            // oculta form adicionar informacoes colaborador
            this.Hide();


            msgAtencao.ShowDialog();

            // verifica resposta do usuario
            if (msgAtencao.DialogResult != DialogResult.No)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                // fecha mensagem de atencao
                msgAtencao.Close();

                btnCancelarClicado = false;

                // foco no botao nome Colaborador
                textBoxNomeColabador.Focus();

                // mostra form adicionar informacoes colaborador
                this.Show();
                return;

            }
        }

        private void buttonCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelarClicado = false;
        }
    }
}
