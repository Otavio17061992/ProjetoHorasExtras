using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartHorasExtras_DB.Metodos;
using SmartHorasExtras_DB.Dominios;
using SmartHorasExtras.Controllers.FormMessageBox;

namespace SmartHorasExtras.Views
{
    public partial class TelaCadastroUsuario : Form
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

        public TelaCadastroUsuario()
        {
            InitializeComponent();
            PreencheCamposUsuario();
        }

        public void PreencheCamposUsuario()
        {
            TelaPrincipal tela = Application.OpenForms.OfType<TelaPrincipal>().FirstOrDefault();
            ColaboradoresDominios colab = new ColaboradoresDominios();

            // verifica se e diferente de superAdmin
            if (tela.NomeUsuario != "Desenv")
            {
                ColaboradoresMetodos.GetUsuarioPeloNome(tela.NomeUsuario);

                textBoxDepartamento.Text = ColaboradoresMetodos.GetUsuarioPeloNomeRetornaDepartamento(tela.NomeUsuario);

                textBoxNomeColab.Text = tela.NomeUsuario;

                colab = ColaboradoresMetodos.GetColaboradorPeloNome(tela.NomeUsuario);

                textBoxSenha.Text = colab.Senha;

                // recebe o id do usuario 
                int tipoUsuario = ColaboradoresMetodos.GetColaboradorTipo(tela.NomeUsuario);

                // verifica o tipo de usuario
                switch (tipoUsuario)
                {
                    case 1:
                        textBoxTipoUsuario.Text = "Admin";
                        break;
                    case 2:
                        textBoxTipoUsuario.Text = "Colaborador";
                        break;
                }
            }
            else
            {
                textBoxTipoUsuario.Text = "Super Admin";
                textBoxNomeColab.Text = "Desenv";
                textBoxDepartamento.Text = "Desenvolvimento";
            }

        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            // verifica se o conteudo do textBoxSenha esta vazio
            if (!string.IsNullOrEmpty(textBoxSenha.Text))
            {
                ColaboradoresDominios usuarioTrocaSenha;

                usuarioTrocaSenha = ColaboradoresMetodos.GetColaboradorPeloNome(textBoxNomeColab.Text,true);

                ColaboradoresMetodos.UpdateSenhaColaborador(usuarioTrocaSenha, textBoxSenha.Text);

                FormMessage msgCadastrada = new FormMessage("Atenção", "Senha Alterada com sucesso", SmartHorasExtras.Properties.Resources.sucesso1, MessageBoxButtons.OK);

                msgCadastrada.ShowDialog();

                textBoxSenha.Text = string.Empty;
            }
        }

    }
}
