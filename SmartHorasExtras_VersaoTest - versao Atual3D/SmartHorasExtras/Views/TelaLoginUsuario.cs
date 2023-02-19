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
using System.Drawing.Drawing2D;


namespace SmartHorasExtras.Views
{
    public partial class TelaLoginUsuario : Form
    {
        public TelaLoginUsuario()
        {
            InitializeComponent();

            PreencheComboBoxUsuario();
        }

        private void buttonLogar_Click(object sender, EventArgs e)
        {
            // 
            ColaboradoresDominios colaborador = ColaboradoresMetodos.ValidaColaborador(comboBoxUsuario.Text, textBoxSenha.Text);
            HorasExtrasDominios novahora = new HorasExtrasDominios();
            TelaPrincipal tela_principal = Application.OpenForms.OfType<TelaPrincipal>().FirstOrDefault();

            // verifica que tipo de usuario e se senha bate com banco de dados
            if (colaborador.EhValido)
            {
               colaborador.TipoUsuario = ColaboradoresMetodos.GetColaboradorTipo(comboBoxUsuario.Text);
                // verifica se e admin
                if (colaborador.TipoUsuario == TipoUsuario.ADMIN)
                {
                    // altera botoes tela inicial para Admin
                    AlteraPadraoTelaInicial("superadmin");

                    // verifica se e a primeira vez logado
                    if (textBoxSenha.Text == "gestal")
                    {
                        tela_principal.loginConcluido = true;

                        tela_principal.VerificaLoginAlteraColabAdmin(true);
                    }
                    else
                    {
                        tela_principal.loginConcluido = true;

                        tela_principal.VerificaLoginAlteraColabAdmin(true);
                    }

                }
                // verifica se e colaborador
                else if (colaborador.TipoUsuario == TipoUsuario.COLABORADOR)
                {
                    novahora = new HorasExtrasDominios();

                    // altera botoes tela inicial para colaborador
                    AlteraPadraoTelaInicial("colaborador");

                    // verifica se e a primeira vez logado
                    if (textBoxSenha.Text == "gestal")
                    {
                        VerificaPrimeiraVezLogado(novahora);
                    }
                    else
                    {
                        VerificaPrimeiraVezLogado(novahora);
                    }

                }
            }
            else
            {
                // verifica se e super adimin
                if (comboBoxUsuario.Text == "Desenv" && textBoxSenha.Text == "desenv")
                {
                    // altera botoes tela inicial para SuperAdmin
                    AlteraPadraoTelaInicial("superadmin");

                    // fecha a tela
                    this.Dispose();

                    // valida login
                    tela_principal.loginConcluido = true;

                    tela_principal.VerificaLoginAlteraColabAdmin(true);
                }
                else
                {
                    if (comboBoxUsuario.Text == "Digite ou Selecione um Colaborador")
                    {
                        FormMessage messageErro = new FormMessage("Erro", "Digite ou selecione um colaborador para logar", SmartHorasExtras.Properties.Resources.erro1, MessageBoxButtons.OK);
                        messageErro.ShowDialog();
                    }
                    else
                    {
                        FormMessage messageErro = new FormMessage("Erro", "Login ou senha inválidos", SmartHorasExtras.Properties.Resources.erro1, MessageBoxButtons.OK);
                        messageErro.ShowDialog();
                    }

                }
            }

        }

        // verifica se e o primeiro login do usuario
        private void VerificaPrimeiraVezLogado(HorasExtrasDominios novahora)
        {
            TelaPrincipal tela_principal = Application.OpenForms.OfType<TelaPrincipal>().FirstOrDefault();
            tela_principal.loginConcluido = true;
            novahora.colaborador_id = ColaboradoresMetodos.GetUsuarioPeloNome(comboBoxUsuario.Text);
            HorasExtrasMetodos.BuscarTodosHorasExtras(novahora.colaborador_id);
            tela_principal.VerificaLoginAlteraColabAdmin(false);
            this.Dispose();
        }

        private void AlteraPadraoTelaInicial(string tipoUsuario)
        {
            TelaPrincipal tela_principal = Application.OpenForms.OfType<TelaPrincipal>().FirstOrDefault();

            tela_principal.MudaVisibilidadeBtnUsuario(true);

            // verifica se e superAdmin ou Admin
            if (tipoUsuario == "superadmin")
            {
                // mostra botao Colaboradores
                tela_principal.MudaVisibilidadeBotaoColaboradores(true);

                // nao mostra botao horasExtras
                tela_principal.MudaVisibilidadeBtnHorasExtras(false);
            }
            else if (tipoUsuario == "colaborador")
            {
                // nao mostra botao colaboradores
                tela_principal.MudaVisibilidadeBotaoColaboradores(false);

                // mostra botao horas Extras
                tela_principal.MudaVisibilidadeBtnHorasExtras(true);
            }

            // seta o nome do botao Usuario
            tela_principal.MudaNomeDoUsuario(comboBoxUsuario.Text);

            // oculta botao de login
            tela_principal.MudaVisibilidadeBtnLogin(false);
        }


        // fecha uma determinada tela
        private void FecharTela<Forms>() where Forms : Form, new()
        {
            Form tela;
            tela = panelPrincipal.Controls.OfType<Forms>().FirstOrDefault();

            // se tela diferente de nulo
            if (tela != null)
            {
                // fecha tela
                tela.Dispose();

                // remove a tela dos controles
                panelPrincipal.Controls.Remove(tela);
                panelPrincipal.Tag = null;
            }
        }

        private void comboBoxUsuario_TextUpdate(object sender, EventArgs e)
        {
            int index = comboBoxUsuario.FindStringExact(comboBoxUsuario.Text);
            if (index != -1)
            {
                comboBoxUsuario.SelectedIndex = index;
            }
        }


        private void PreencheComboBoxUsuario()
        {
            AddColaboradoresComboBoxUser(ColaboradoresMetodos.GetColaboradores());
        }

        private void AddColaboradoresComboBoxUser(DataTable table)
        {
            comboBoxUsuario.Items.Add("Digite ou Selecione um Colaborador");
            comboBoxUsuario.SelectedItem = "Digite ou Selecione um Colaborador";

            // Iterar sobre as linhas da tabela
            foreach (DataRow row in table.Rows)
            {
                comboBoxUsuario.Items.Add(row["Nome"].ToString());
            }
        }


        // abre uma determinada tela
        // <typeparam name="Forms"></typeparam>
        private void AbrirTela<Forms>() where Forms : Form, new()
        {
            Form tela;
            tela = panelPrincipal.Controls.OfType<Forms>().FirstOrDefault();


            // se tela eh nulo
            if (tela == null)
            {
                tela = new Forms();
                tela.TopLevel = false;
                tela.Dock = DockStyle.Fill;

                panelPrincipal.Controls.Add(tela);
                panelPrincipal.Tag = tela;

                //apresenta tela
                tela.Show();
            }
            else
            {
                // verifica se esta minimizada
                if (tela.WindowState == FormWindowState.Minimized)
                {
                    // restaura tela
                    tela.WindowState = FormWindowState.Normal;
                }
            }

            // tela para frente
            tela.BringToFront();
        }
    }
}
