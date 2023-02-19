using SmartHorasExtras.Controllers.ControlUcColaborador;
using SmartHorasExtras.Controllers.FormMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using SmartHorasExtras.Controllers;
using SmartHorasExtras_DB.Metodos;
using SmartHorasExtras_DB.Dominios;

namespace SmartHorasExtras.Views
{
    public partial class TelaColaboradores : Form
    {
        private DispatcherTimer timer { get; set; }
        private int contadorTempo = 0;
        public int IDColab = 0;
        
        TelaPrincipal tela_principal = Application.OpenForms.OfType<TelaPrincipal>().FirstOrDefault();
        ColaboradorUC NovoColaborador = new ColaboradorUC();
        ColaboradoresDominios ColaboradorDB = new ColaboradoresDominios();
        List<ColaboradorUC> ListaColaborador = new List<ColaboradorUC>();
        public HorasExtrasDominios HorasExtras = new HorasExtrasDominios();
        public string nomeColab;

        Button ColaboradorAux = new Button();

        // construtor tela de colaboradores Form
        public TelaColaboradores()
        {
            InitializeComponent();

            try
            {
                // addicona os colaboradores a flowpanel Colaboradores
                AdicionarUserControlsAoFlowPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }

        }


        private void AdicionarUserControlsAoFlowPanel()
        {
            var colaboradores = ColaboradoresMetodos.GetColaboradores();
            AddUserControlsToFlowPanel(colaboradores);
        }


        private void AddUserControlsToFlowPanel(DataTable dataTable)
        {
                        
            foreach (DataRow row in dataTable.Rows)
            {
                // Cria um novo user control para cada linha da tabela
                ColaboradorUC novoColab = new ColaboradorUC();

                // armazena o nome do colaborador na tag 
                novoColab.Tag = row["ID"].ToString();

                // Define os valores dos campos do user control com os valores da linha atual da tabela
                novoColab.NomeColaborador = row["Nome"].ToString();

                string TipoColab = row["TipoColaborador"].ToString();

                int tpColab = int.Parse(TipoColab);

                if (tpColab != TipoUsuario.ADMIN)
                {
                    CriaColaborador(novoColab);
                }
            }

        }

        // Gera colaborador com metodos 
        private void CriaColaborador(ColaboradorUC colaborador)
        {
            // Oculta o botão de exclusão
            colaborador.BotaoExcluir.Visible = false;

            // Adiciona os eventos ao colaborador
            colaborador.botaoColaborador.MouseDown += Control_MouseDown;
            colaborador.BotaoExcluir.MouseClick += ExcluirColaborador;
            colaborador.botaoColaborador.MouseUp += Control_MouseUp;
            colaborador.LabelNomeColab.MouseDown += Control_MouseDown;
            colaborador.LabelNomeColab.MouseClick += AbrirTelaListaHorasExtras;
            colaborador.LabelNomeColab.MouseUp += Control_MouseUp;
            colaborador.botaoColaborador.MouseClick += AbrirTelaListaHorasExtras;

            // Altera a foto e as cores do colaborador
            colaborador.FotoColaborador = SmartHorasExtras.Properties.Resources.usuario_64px_g;
            colaborador.botaoColaborador.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            colaborador.botaoColaborador.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            colaborador.LabelNomeColab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            colaborador.LabelNomeColab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;

            // Inicializa o timer para ocultar o botão de exclusão
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 400);
            timer.Tick += Tempo_Relogio;

            // Adiciona o colaborador ao painel e ajusta sua posição
            flowPainelColaboradores.Controls.Add(colaborador);
            flowPainelColaboradores.Controls.SetChildIndex(AdicionarColaborador, colaborador.Location.X);

            // verifica posicao vertical dos botoes
            if (AdicionarColaborador.Location.Y < colaborador.Location.Y)
            {
                // inverte posicao vertical do colaborador com addColaborador
                flowPainelColaboradores.Controls.SetChildIndex(AdicionarColaborador, colaborador.Location.Y);
            }

            // adiciona o colaborador a lista de colaboradores
            ListaColaborador.Add(colaborador);
        }


        // Botao Adicionar colaborador
        private void AdicionarColaborador_Load(object sender, EventArgs e)
        {
            // cria foto addColaborador
            AdicionarColaborador.FotoColaborador = SmartHorasExtras.Properties.Resources.sinal_de_mais;

            // oculta botao excluir colaborador
            AdicionarColaborador.BotaoExcluir.Visible = false;

            // oculta nome colaborador
            AdicionarColaborador.LabelNomeColab.Visible = false;

            // cria evento click do botao colaborador
            AdicionarColaborador.botaoColaborador.MouseClick += botaoColaborador_MouseClick;
        }

        // Metodo Click do Botao AddcionarColaborador
        private void botaoColaborador_MouseClick(object sender, MouseEventArgs e)
        {
            exibirFormularioAdicionarColaborador();
        }

        // abre o formulario de cadastro colaborador
        private void exibirFormularioAdicionarColaborador()
        {
            FormColaboradorAdd formularioAdicionarColaborador = new FormColaboradorAdd(MessageBoxButtons.YesNo);
            DialogResult resultado = formularioAdicionarColaborador.ShowDialog();

            // botao sim clicado adiciona o colaborador
            if (resultado == DialogResult.Yes)
            {

                // verifica qual tipo de usuario 
                if (formularioAdicionarColaborador.RecebeTipoUsuario() != "Admin")
                {
                    // instancia novo colaborador UC
                    ColaboradorUC novoColaboradorCriado = adicionarNovoColaboradorAoPainel();

                    // preenche nome colaborador com texto recebido do formulario
                    preencherNomeColaborador(novoColaboradorCriado, formularioAdicionarColaborador.RecebetextoNome());

                    // salva colaborador no banco de dados Colaboradores
                    salvarNovoColaboradorBancoDeDadosColaboradores(formularioAdicionarColaborador);

                }
                else
                {
                    // armazena administrado no banco de dados
                    salvaTipoColaboradorBancoDadosColaboradorAdmin(formularioAdicionarColaborador);
                }

            }
        }

        private void preencherNomeColaborador(ColaboradorUC novoColaboradorCriado, string nome)
        {
            novoColaboradorCriado.LabelNomeColab.Text = nome;
        }

        // adiciona colaborador ao banco de dados
        private void salvarNovoColaboradorBancoDeDadosColaboradores(FormColaboradorAdd formularioAdicionarColaborador)
        {
            int idColaborador;
            ColaboradoresDominios novoColaborador = new ColaboradoresDominios();
            novoColaborador.Nome = formularioAdicionarColaborador.RecebetextoNome();
            novoColaborador.Departamento = formularioAdicionarColaborador.RecebetextoDepartamento();
            HorasExtras = new HorasExtrasDominios();
            novoColaborador.Senha = "gestal";
            string tipoUsuario = formularioAdicionarColaborador.RecebeTipoUsuario();

            // verifica qual tipo de usuario
            switch (tipoUsuario)
            {
                case "Colaborador":
                    novoColaborador.TipoUsuario = TipoUsuario.COLABORADOR;
                    break;

                case "Admin":
                    novoColaborador.TipoUsuario = TipoUsuario.ADMIN;
                    break;
            }
            idColaborador = ColaboradoresMetodos.GetUsuarioPeloNome(novoColaborador.Nome);
            idColaborador = ColaboradoresMetodos.AddColaborador(novoColaborador);
            HorasExtras.id = ColaboradoresMetodos.GetUsuarioPeloNome(novoColaborador.Nome);
            NovoColaborador.Tag = idColaborador;
            NovoColaborador.Tag = ColaboradoresMetodos.GetUsuarioPeloNome(novoColaborador.Nome);
            HorasExtras.colaborador_id = idColaborador;
            ArmazenaIdColaborador(HorasExtras.id);
            ArmazenaIdColaborador(idColaborador);
        }


        // armazena o id do colaborador clicado
        public void ArmazenaIdColaborador(int ID)
        {
            IDColab = 0;
            IDColab = ID;
            HorasExtras.id = ID;
        }


        private void salvaTipoColaboradorBancoDadosColaboradorAdmin(FormColaboradorAdd formularioAdicionarColaborador)
        {
            // instancia um novo usuario
            ColaboradoresDominios novoColaborador = new ColaboradoresDominios();

            novoColaborador.Nome = formularioAdicionarColaborador.RecebetextoNome();
            novoColaborador.Senha = "gestal";
            novoColaborador.Departamento = formularioAdicionarColaborador.RecebetextoDepartamento();
            // armazena retorno do tipo de usuario
            string tipoUsuario = formularioAdicionarColaborador.RecebeTipoUsuario();

            // verifica qual tipo de usuario
            switch (tipoUsuario)
            {
                case "Colaborador":
                    novoColaborador.TipoUsuario = TipoUsuario.COLABORADOR;
                    break;

                case "Admin":
                    novoColaborador.TipoUsuario = TipoUsuario.ADMIN;
                    break;
            }
            ColaboradoresMetodos.AddColaborador(novoColaborador);
        }

        // adiciona o colaborador no flowPanelColaboradores
        private ColaboradorUC adicionarNovoColaboradorAoPainel()
        {
            ColaboradorUC novoColaboradorCriado = new ColaboradorUC();
            CriaColaborador(novoColaboradorCriado);
            return novoColaboradorCriado;
        }


        private void AbrirTelaListaHorasExtras(object sender, MouseEventArgs e)
        {

            ColaboradorUC aux = (sender is ContextMenuStrip) ? (ColaboradorUC)((Button)sender).Parent : (ColaboradorUC)ColaboradorAux.Parent;

            HorasExtras.colaborador_id = ColaboradoresMetodos.GetUsuarioPeloNome(aux.NomeColaborador);

            ColaboradoresMetodos.GetColaborador(HorasExtras.colaborador_id);

            nomeColab = aux.NomeColaborador;

            ArmazenaIdColaborador(HorasExtras.colaborador_id);

            AbrirTela<TelaListaHorasExtras>();
        }


        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;

            // executa apenas se o botao esquerdo foi clicado
            if (e.Button != MouseButtons.Left)
            {
                // termina a contagem
                timer.Stop();

                // verifica quanto tempo botao ficou pressionado
                if (contadorTempo >= 3)
                {
                    control.ContextMenuStrip.Hide();
                    contadorTempo = 0;
                }
                else
                {
                    control.ContextMenuStrip.Show();
                }
            }

            // verifica se o botao esquerdo mouse foi clicado
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DesabilitaBotoesExcluir();

                timer.Stop();
            }
        }


        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;

            // cria um contextMenu no botao Clicado
            CriaContextMenu(sender);

            // executa apenas se o botao esquerdo foi clicado
            if (e.Button != MouseButtons.Left)
            {
                // oculta todos botoes de excluir
                DesabilitaBotoesExcluir();

                ColaboradorAux = (Button)sender;

                // inicia a contagem 
                timer.Start();
            }
            // verifica se o botao esquerdo mouse foi clicado
            if (e.Button == MouseButtons.Left)
            {
                DesabilitaBotoesExcluir();
            }
        }


        /// <summary>
        /// Faz uma contagem de tempo enquanto o botao Colaborador esta pressionado
        /// </summary>
        private void Tempo_Relogio(object sender, EventArgs e)
        {
            // armazena o pai do botao clicado
            ColaboradorUC ColaboradorUC = (ColaboradorUC)ColaboradorAux.Parent;

            contadorTempo += 1;

            if (contadorTempo >= 3)
            {
                // verifica se ColaboradorAux e um botao
                if (ColaboradorAux is Button)
                {
                    // torna visivel o botao excluir do botao UserControl clicado
                    ColaboradorUC.BotaoExcluir.Visible = true;
                }
            }
        }

        private void ExcluirColaborador(object sender, EventArgs e)
        {
            ColaboradorUC aux = (sender is ContextMenuStrip) ? (ColaboradorUC)((Button)sender).Parent : (ColaboradorUC)ColaboradorAux.Parent;
            
            HorasExtras.colaborador_id = ColaboradoresMetodos.GetUsuarioPeloNome(aux.NomeColaborador);

            int idColaborador = Convert.ToInt32(aux.Tag);

            if (idColaborador == 0)
            {
                idColaborador = HorasExtras.colaborador_id;
            }
            ColaboradoresMetodos.GetColaborador(HorasExtras.colaborador_id);
            
            ColaboradoresMetodos.GetColaborador(idColaborador);

            ArmazenaIdColaborador(HorasExtras.colaborador_id);
            // abre messagem de pergunta
            FormMessage message_box = new FormMessage("ATENÇÃO", "Deseja Realmente Excluir Colaborador " + aux.LabelNomeColab.Text + "?", SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.YesNo, MessageBoxButtons.YesNo);
            message_box.ShowDialog();

            // verifica se foi selecionado botao SIM
            if (message_box.DialogResult == DialogResult.Yes)
            {
                // remove colaborador do painel
                flowPainelColaboradores.Controls.Remove(aux);

                // remove colaborador da lista
                ListaColaborador.Remove(aux);

                ColaboradoresMetodos.ExcluirColaborador(HorasExtras.colaborador_id);
                ColaboradoresMetodos.ExcluirColaborador(idColaborador);
            }
        }


        /// <summary>
        /// desabilita botoes de excluir colaborador
        /// </summary>
        private void DesabilitaBotoesExcluir()
        {
            // percorre a lista de colaboradores
            foreach (ColaboradorUC controle in flowPainelColaboradores.Controls)
            {
                if (controle is ColaboradorUC)
                {
                    ColaboradorUC aux = (ColaboradorUC)controle;

                    if (aux.BotaoExcluir.Visible == true)
                        aux.BotaoExcluir.Visible = false;
                }
            }
        }

        private void CriaContextMenu(object sender)
        {
            ColaboradorAux = (Button)sender;
            ColaboradorAux.ContextMenuStrip = new ContextMenuStrip();

            ToolStripItem abrirItem = ColaboradorAux.ContextMenuStrip.Items.Add("Abrir");
            abrirItem.Click += menuItemAbrir_Click;

            ToolStripItem editarItem = ColaboradorAux.ContextMenuStrip.Items.Add("Editar");
            editarItem.Click += menuItemEditar_Click;

            ToolStripItem excluirItem = ColaboradorAux.ContextMenuStrip.Items.Add("Excluir");
            excluirItem.Click += ExcluirColaborador;
        }


        // abrir colaborador
        private void menuItemAbrir_Click(object sender, EventArgs e)
        {
            AbrirTela<TelaListaHorasExtras>();
        }

        // editar Colaborador
        private void menuItemEditar_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Abri um novo form sobrepondo o form pai sem o fechar
        /// </summary>
        private void AbrirTela<Forms>() where Forms : Form, new()
        {
            Form tela;
            tela = painelPrincipalColaboradores.Controls.OfType<Forms>().FirstOrDefault();


            // se tela eh nulo
            if (tela == null)
            {
                tela = new Forms();
                tela.TopLevel = false;
                tela.Dock = DockStyle.Fill;


                painelPrincipalColaboradores.Controls.Add(tela);
                painelPrincipalColaboradores.Tag = tela;

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

        // fecha uma determinada tela
        private void FecharTela<Forms>() where Forms : Form, new()
        {
            Form tela;
            tela = flowPainelColaboradores.Controls.OfType<Forms>().FirstOrDefault();

            // se tela diferente de nulo
            if (tela != null)
            {
                // fecha tela
                tela.Close();

                // remove a tela dos controles
                flowPainelColaboradores.Controls.Remove(tela);
                flowPainelColaboradores.Tag = null;
            }
        }
    }
}
