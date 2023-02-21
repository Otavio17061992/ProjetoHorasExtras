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
using SmartHorasExtras_DB.Metodos;

using System.Threading;
using SmartHorasExtras.Views;
using SmartHorasExtras.Controllers.FormMessageBox;
using SmartHorasExtras_DB.Dominios;
using SmartHorasExtras.Controllers;
using System.IO;
using SmartHorasExtras.Controllers.IniFiles;
using System.Drawing.Printing;

namespace SmartHorasExtras
{
    public partial class TelaPrincipal : Form
    {
        // borda da tela principal
        private int borderSize = 1;
        public Button mudaBotao { get; set; }
        public Button nomeAltera { get; set; }
        public bool menuHumburguerClicked = false;
        public bool Botaoclicado = false;
        public bool botaoLogarClicado = false;
        public bool loginConcluido = false;
        public string NomeUsuario;
        public int IDColaborador = 0;
        public string caminhoDB;
        public string caminhoDiretorioIni;
        public HorasExtrasDominios HorasExtras = new HorasExtrasDominios();
        public event EventHandler btnimprimirClicado;
        


        // construtor padrao
        public TelaPrincipal()
        {
            // duracao que leva para abrir o aplicacao principal
            Thread tempoEsperar = new Thread(new ThreadStart(StartForm));
            tempoEsperar.Start();
            Thread.Sleep(5960);
            InitializeComponent();
            tempoEsperar.Abort();
            MinimizarMenu();

            // tamanho da borda
            this.Padding = new Padding(borderSize);

            // cor da borda
            this.BackColor = Color.FromArgb(64, 64, 64);

            // deixa a area cliente no formato de retangulo
            Rectangle rect = Screen.FromHandle(this.Handle).WorkingArea;

            // seta o width da area do cliente
            rect.Width = rect.Width - borderSize;

            // seta o height da area do cliente
            rect.Height = rect.Height - borderSize;

            this.BringToFront();



            try
            {
                // le o caminho ini 
                LeCaminhoIniBancoDados();

                // Cria o banco de dados
                CriarBancoSQLite();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }

            try
            {
                // cria tabela HorasExtras
                HorasExtrasMetodos.CriarTabelaHorasExtras();

                // cria tabela Colaborador
                ColaboradoresMetodos.CriarTabelaColaboradores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar tabela: " + ex.Message);
            }

            // abre tela de login do Usuario
            AbrirTela<TelaLoginUsuario>();

        }

        // metodo para criar banco de dados
        private void CriarBancoSQLite()
        {
            BancoDadosMetodos.CriaBancoSQLite(caminhoDB);
        }

        /// <summary>
        /// Cria arquivo .ini alimenta arquivo com as informacoes 
        /// do caminho de banco de dados
        /// </summary>
        private void LeCaminhoIniBancoDados()
        {
            caminhoDiretorioIni = GetCaminhoDiretorio();

            string retorn = INiFilesPadrao.IniReadValue(caminhoDiretorioIni + "\\Caminho.ini", "BancoDados", "Caminho");

            BancoDadosMetodos.conexao = retorn;

            // armazena caminho do banco de dados
            caminhoDB = retorn;
        }

        private string GetCaminhoDiretorio()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }

        // Mantém o tamanho do formulário quando minimizado e restaurado. Já que o formulário é 
        // redimensionado porque leva em consideração o tamanho da barra de título e das bordas.
        private Size formSize;

        // carrega o painel principal
        private void PainelPrincipal_Load(object sender, EventArgs e)
        {
            formSize = this.ClientSize;

            // inicializa o painel de menu aberto
            pictureBoxLogoGEstal.Visible = true;
            pictureBox2LogoGestal.Visible = false;
            panelMenu.Width = 230;
            MenuHamburguer.Dock = DockStyle.None;
            foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
            {
                menuButton.Text = "   " + menuButton.Tag.ToString();
                menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                menuButton.Padding = new Padding(5, 0, 0, 0);
            }

            // reseta as configurecoes do botao btnLogin aberto
            btnLogin.ForeColor = Color.FromArgb(64, 64, 64);
            btnLogin.BackColor = Color.FromArgb(240, 240, 240);
            btnLogin.Image = SmartHorasExtras.Properties.Resources.chave_32px_g;


            // reseta as configuracoes do botao 'configuracoes'
            btnConfiguracoes.ForeColor = Color.FromArgb(240, 240, 240);
            btnConfiguracoes.BackColor = Color.FromArgb(64, 64, 64);
            btnConfiguracoes.Image = SmartHorasExtras.Properties.Resources.configuracao_32px_w;

            // reseta as configuracoes do bota 'Usuarios'
            btnUsuarios.ForeColor = Color.FromArgb(240, 240, 240);
            btnUsuarios.BackColor = Color.FromArgb(64, 64, 64);
            btnUsuarios.Image = SmartHorasExtras.Properties.Resources.usuario_32px_w;
        }

        private void PrintPanel(Panel panel)
        {
            // Criar um novo objeto PrintDocument
            PrintDocument printDocument = new PrintDocument();

            // Adicione o evento PrintPage ao objeto PrintDocument
            printDocument.PrintPage += delegate (object sender, PrintPageEventArgs e)
            {
                // Obter a largura e a altura da página de impressão
                float pageWidth = e.PageSettings.PrintableArea.Width;
                float pageHeight = e.PageSettings.PrintableArea.Height;

                // Desenhar o painel no objeto Graphics da página de impressão
                e.Graphics.TranslateTransform(0, 0);
                panel.DrawToBitmap(new Bitmap((int)pageWidth, (int)pageHeight),
                    new Rectangle(0, 0, panel.Width, panel.Height));

                // Especificar que esta é a única página a ser impressa
                e.HasMorePages = false;
            };

            // Mostrar a caixa de diálogo de impressão
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Iniciar a impressão
                printDocument.Print();
            }
        }


        // armazena nome do usuario
        public void ArmazenaNomeUsuario(string nome)
        {
            NomeUsuario = nome;
        }

        // altera visibilidade botoes colaboradores
        public void MudaVisibilidadeBotaoColaboradores(bool visibility)
        {
            btnColaboradores.Visible = visibility;
        }

        // altera visibilidade botao horas Extras
        public void MudaVisibilidadeBtnHorasExtras(bool visibility)
        {
            BtnHorasExtras.Visible = visibility;
        }

        // altera visibilidade botao usuario
        public void MudaVisibilidadeBtnUsuario(bool visibility)
        {
            btnUsuarios.Visible = visibility;
        }

        // altera visibilidade botao login
        public void MudaVisibilidadeBtnLogin(bool visibility)
        {
            btnLogin.Visible = visibility;
        }

        // altera nome do usuario
        public void MudaNomeDoUsuario(string nome)
        {
            btnUsuarios.Text = nome;
        }

        // verifica se o login esta ok e se e colaborador ou Admin
        public void VerificaLoginAlteraColabAdmin(bool isAdmin)
        {
            // verifica se esta ok 
            if (loginConcluido == true)
            {
                // Verifica se e admin
                if (isAdmin)
                {
                    AbrirTela<TelaColaboradores>();
                    btnColaboradores.ForeColor = Color.FromArgb(64, 64, 64);
                    btnColaboradores.BackColor = Color.FromArgb(240, 240, 240);
                    btnColaboradores.Image = SmartHorasExtras.Properties.Resources.usuarios_32px_g;
                }
                else // verifica se e colaborador
                {
                    // retorna um novo colaborador
                    HorasExtras.id = ColaboradoresMetodos.GetUsuarioPeloNome(btnUsuarios.Text);
                    RecebeIdColaborador(HorasExtras.id);

                    AbrirTela<TelaListaHorasExtras>();
                    BtnHorasExtras.ForeColor = Color.FromArgb(64, 64, 64);
                    BtnHorasExtras.BackColor = Color.FromArgb(240, 240, 240);
                    BtnHorasExtras.Image = SmartHorasExtras.Properties.Resources.hora_extra_32px_g;

                }
                ArmazenaNomeUsuario(btnUsuarios.Text);
            }
        }

        public void RecebeIdColaborador(int ID)
        {
            HorasExtras.id = ID;
            IDColaborador = ID;

        }

        // verifica se o botao colaborador foi precionado
        public bool VerificaBotaoColaboradores()
        {
            if (Botaoclicado == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        // inicializa primeiro a tela splashScreen
        private void StartForm()
        {
            Application.Run(new TelaSplashScreen());
        }

        // abre uma determinada tela
        // <typeparam name="Forms"></typeparam>
        private void AbrirTela<Forms>() where Forms : Form, new()
        {
            Form tela;
            tela = panelDesktop.Controls.OfType<Forms>().FirstOrDefault();


            // se tela eh nulo
            if (tela == null)
            {
                tela = new Forms();
                tela.TopLevel = false;
                tela.Dock = DockStyle.Fill;

                panelDesktop.Controls.Add(tela);
                panelDesktop.Tag = tela;
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
            tela = panelDesktop.Controls.OfType<Forms>().FirstOrDefault();

            // se tela diferente de nulo
            if (tela != null)
            {
                // fecha tela
                tela.Close();

                // remove a tela dos controles
                panelDesktop.Controls.Remove(tela);
                panelDesktop.Tag = null;
            }
        }

        // metodo que permite movimentar a janela cliente
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // remove bordas windows form
        protected override void WndProc(ref Message m)
        {
            //Barra de Título Padrão - Janela de Windows
            const int WM_NCCALCSIZE = 0x0083;

            const int WM_SYSCOMMAND = 0x0112;
            //Minimizar formulário (Antes)
            const int SC_MINIMIZE = 0xF020;

            //Restaurar formulário (Antes)
            const int SC_RESTORE = 0xF120;

            //Notificação de entrada do mouse: Determina qual parte da janela corresponde a um ponto, permite redimensionar o formulário.
            const int WM_NCHITTEST = 0x0084;

            const int resizeAreaSize = 10;

            #region Form Resize
            // Redimensionar/valores WM_NCHITTEST

            //Representa a área do cliente da janela
            const int HTCLIENT = 1;

            const int HTLEFT = 10;

            const int HTRIGHT = 11;

            const int HTTOP = 12;

            const int HTTOPLEFT = 13;

            const int HTTOPRIGHT = 14;

            const int HTBOTTOM = 15;

            const int HTBOTTOMLEFT = 16;

            const int HTBOTTOMRIGHT = 17;

            //Se a janela m for WM_NCHITTEST
            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);

                //Redimensiona o formulário se estiver no estado normal
                if (this.WindowState == FormWindowState.Normal)
                {
                    //Se o resultado do m (ponteiro do mouse) estiver na área do cliente da janela
                    if ((int)m.Result == HTCLIENT)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());

                        Point clientPoint = this.PointToClient(screenPoint);

                        //Se o ponteiro estiver no topo do formulário (dentro da área de redimensionamento - coordenada X)
                        if (clientPoint.Y <= resizeAreaSize)
                        {
                            //Se o ponteiro estiver na coordenada X=0 ou menor que a área de redimensionamento(X=10)
                            if (clientPoint.X <= resizeAreaSize)
                            {
                                m.Result = (IntPtr)HTTOPLEFT;
                            }
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Se o ponteiro estiver na coordenada X=11 ou menor que a largura do formulário(X=Form.Width-resizeArea)
                            {
                                m.Result = (IntPtr)HTTOP;
                            }
                            else
                            {
                                m.Result = (IntPtr)HTTOPRIGHT;
                            }
                        }
                        //Se o ponteiro estiver dentro do formulário na coordenada Y (descontando o tamanho da área de redimensionamento)
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize))
                        {
                            if (clientPoint.X <= resizeAreaSize)
                            {
                                m.Result = (IntPtr)HTLEFT;
                            }
                            //Redimensiona horizontalmente para a direita    
                            else if (clientPoint.X > (this.Width - resizeAreaSize))
                            {
                                m.Result = (IntPtr)HTRIGHT;
                            }
                        }
                        else
                        {
                            //Redimensiona diagonalmente para a esquerda
                            if (clientPoint.X <= resizeAreaSize)
                                m.Result = (IntPtr)HTBOTTOMLEFT;

                            //Redimensiona verticalmente para baixo
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))
                                m.Result = (IntPtr)HTBOTTOM;

                            //Redimensiona diagonalmente para a direita
                            else
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion

            //Remove a borda e mantém a janela de encaixe
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            //Mantém o tamanho do formulário quando ele é minimizado e restaurado.
            if (m.Msg == WM_SYSCOMMAND)
            {
                int wParam = (m.WParam.ToInt32() & 0xFFF0);

                // antes
                if (wParam == SC_MINIMIZE)
                {
                    formSize = this.ClientSize;
                }

                //Formulário restaurado(Antes)
                if (wParam == SC_RESTORE)
                {
                    this.Size = formSize;
                }
            }
            base.WndProc(ref m);
        }

        // evento do metodo ajustaForm
        private void PainelPrincipal_Resize(object sender, EventArgs e)
        {
            AjustaForm();
        }

        // metodo para minimizar aplicacao
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // metodo para botao maximizador de tela 
        private void btnRestaurar2_Click(object sender, EventArgs e)
        {
            // metodo para maximizar aplicacao
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
            }
        }

        // metodo fechar a aplicacao
        private void btnSair_Click(object sender, EventArgs e)
        {
            FormMessage message_box = new FormMessage("ATENÇÃO", "Deseja Realmente sair do aplicativo Horas Extras ?", SmartHorasExtras.Properties.Resources.pergunta1, MessageBoxButtons.YesNo, MessageBoxButtons.YesNo);
            message_box.ShowDialog();

            if (message_box.DialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // minimiza o menu lateral
        private void MenuHamburguer_Click(object sender, EventArgs e)
        {
            MinimizarMenu();

            menuHumburguerClicked = true;
        }

        //metodo ajusta as bordas da aplicao
        private void AjustaForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(8, 8, 8, 8);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        // metodo reduz o menu em 50 width
        // verificando sempre se o menu tem o width maior que 200
        private void MinimizarMenu()
        {
            // Verifica se o painel de menu tem largura maior que 200
            if (this.panelMenu.Width > 200)
            {
                // Minimiza o painel de menu
                panelMenu.Width = 50;

                // Esconde o logo GEstal
                pictureBoxLogoGEstal.Visible = false;

                // Define o estilo de acoplamento do painel de menu para a esquerda
                panelMenu.Dock = DockStyle.Left;

                // Mostra o logo Gestal
                pictureBox2LogoGestal.Visible = true;

                // Define o estilo de acoplamento do MenuHamburguer para ocupar todo o espaço disponível
                MenuHamburguer.Dock = DockStyle.Fill;

                // Define o espaçamento interno do MenuHamburguer
                MenuHamburguer.Padding = new Padding(10, 0, 13, 0);

                // Percorre todos os botões no painel de menu
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    // Remove o texto dos botões
                    menuButton.Text = "";

                    // Centraliza a imagem dos botões
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;

                    // Remove o espaçamento interno dos botões
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            {
                // Amplia o painel de menu
                panelMenu.Width = 230;

                // Mostra o logo GEstal
                pictureBoxLogoGEstal.Visible = true;

                // Esconde o logo Gestal
                pictureBox2LogoGestal.Visible = false;

                // Remove o estilo de acoplamento do MenuHamburguer
                MenuHamburguer.Dock = DockStyle.None;

                // Percorre todos os botões no painel de menu
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    // Adiciona o texto dos botões a partir da propriedade Tag
                    menuButton.Text = "   " + menuButton.Tag.ToString();

                    // Alinha a imagem dos botões à esquerda
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;

                    // Adiciona o espaçamento interno dos botões
                    menuButton.Padding = new Padding(5, 0, 0, 0);
                }
            }
        }


        private void btnSair_MouseEnter(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(255, 0, 0);
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            btnSair.BackColor = Color.FromArgb(64, 64, 64);
        }


        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            btnUsuarios.ForeColor = Color.FromArgb(64, 64, 64);
            btnUsuarios.BackColor = Color.FromArgb(240, 240, 240);
            btnUsuarios.Image = SmartHorasExtras.Properties.Resources.usuario_32px_g;

            // reseta as configuracoes do botao 'Colaboradores'
            btnColaboradores.ForeColor = Color.FromArgb(240, 240, 240);
            btnColaboradores.BackColor = Color.FromArgb(64, 64, 64);
            btnColaboradores.Image = SmartHorasExtras.Properties.Resources.usuarios_32px_w;

            // reseta as configuracoes do botao 'configuracoes'
            btnConfiguracoes.ForeColor = Color.FromArgb(240, 240, 240);
            btnConfiguracoes.BackColor = Color.FromArgb(64, 64, 64);
            btnConfiguracoes.Image = SmartHorasExtras.Properties.Resources.configuracao_32px_w;

            btnLogin.ForeColor = Color.FromArgb(240, 240, 240);
            btnLogin.BackColor = Color.FromArgb(64, 64, 64);
            btnLogin.Image = SmartHorasExtras.Properties.Resources.chave_32px_w;

            BtnHorasExtras.ForeColor = Color.FromArgb(240, 240, 240);
            BtnHorasExtras.BackColor = Color.FromArgb(64, 64, 64);
            BtnHorasExtras.Image = SmartHorasExtras.Properties.Resources.hora_extra_32px_w;

            botaoLogarClicado = true;
            botaoLogarClicado = true;

            AbrirTela<TelaCadastroUsuario>();

        }


        // evento dos botoes do menu
        // botao Colaboradores
        private void btnColaboradores_Click(object sender, EventArgs e)
        {
            AbrirTela<TelaColaboradores>();

            botaoLogarClicado = true;
            btnColaboradores.ForeColor = Color.FromArgb(64, 64, 64);
            btnColaboradores.BackColor = Color.FromArgb(240, 240, 240);
            btnColaboradores.Image = SmartHorasExtras.Properties.Resources.usuarios_32px_g;

            // reseta as configuracoes do botao 'configuracoes'
            btnConfiguracoes.ForeColor = Color.FromArgb(240, 240, 240);
            btnConfiguracoes.BackColor = Color.FromArgb(64, 64, 64);
            btnConfiguracoes.Image = SmartHorasExtras.Properties.Resources.configuracao_32px_w;

            // reseta as configuracoes do bota 'Fechar'
            btnUsuarios.ForeColor = Color.FromArgb(240, 240, 240);
            btnUsuarios.BackColor = Color.FromArgb(64, 64, 64);
            btnUsuarios.Image = SmartHorasExtras.Properties.Resources.usuario_32px_w;

            // reseta botao login
            btnLogin.ForeColor = Color.FromArgb(240, 240, 240);
            btnLogin.BackColor = Color.FromArgb(64, 64, 64);
            btnLogin.Image = SmartHorasExtras.Properties.Resources.chave_32px_w;

            Botaoclicado = true;

        }



        // botao horasExtras Config
        private void btnColaborador_Click(object sender, EventArgs e)
        {
            botaoLogarClicado = true;
            BtnHorasExtras.ForeColor = Color.FromArgb(64, 64, 64);
            BtnHorasExtras.BackColor = Color.FromArgb(240, 240, 240);
            BtnHorasExtras.Image = SmartHorasExtras.Properties.Resources.hora_extra_32px_g;

            // reseta botao usuarios
            btnUsuarios.ForeColor = Color.FromArgb(240, 240, 240);
            btnUsuarios.BackColor = Color.FromArgb(64, 64, 64);
            btnUsuarios.Image = SmartHorasExtras.Properties.Resources.usuario_32px_w;

            // reseta as configuracoes do botao 'Colaboradores'
            btnColaboradores.ForeColor = Color.FromArgb(240, 240, 240);
            btnColaboradores.BackColor = Color.FromArgb(64, 64, 64);
            btnColaboradores.Image = SmartHorasExtras.Properties.Resources.usuarios_32px_w;

            // reseta as configuracoes do botao 'configuracoes'
            btnConfiguracoes.ForeColor = Color.FromArgb(240, 240, 240);
            btnConfiguracoes.BackColor = Color.FromArgb(64, 64, 64);
            btnConfiguracoes.Image = SmartHorasExtras.Properties.Resources.configuracao_32px_w;

            // reseta botao login
            btnLogin.ForeColor = Color.FromArgb(240, 240, 240);
            btnLogin.BackColor = Color.FromArgb(64, 64, 64);
            btnLogin.Image = SmartHorasExtras.Properties.Resources.chave_32px_w;

            Botaoclicado = true;

            AbrirTela<TelaListaHorasExtras>();
        }

        // botao login config
        private void btnLogin_Click(object sender, EventArgs e)
        {
            botaoLogarClicado = true;
            btnLogin.ForeColor = Color.FromArgb(64, 64, 64);
            btnLogin.BackColor = Color.FromArgb(240, 240, 240);
            btnLogin.Image = SmartHorasExtras.Properties.Resources.chave_32px_g;

            // reseta botao Colaboradores
            btnColaboradores.ForeColor = Color.FromArgb(240, 240, 240);
            btnColaboradores.BackColor = Color.FromArgb(64, 64, 64);
            btnColaboradores.Image = SmartHorasExtras.Properties.Resources.usuarios_32px_w;

            // reseta as configuracoes do botao 'configuracoes'
            btnConfiguracoes.ForeColor = Color.FromArgb(240, 240, 240);
            btnConfiguracoes.BackColor = Color.FromArgb(64, 64, 64);
            btnConfiguracoes.Image = SmartHorasExtras.Properties.Resources.configuracao_32px_w;


            // reseta as configuracoes do bota 'Usuarios'
            btnUsuarios.ForeColor = Color.FromArgb(240, 240, 240);
            btnUsuarios.BackColor = Color.FromArgb(64, 64, 64);
            btnUsuarios.Image = SmartHorasExtras.Properties.Resources.usuario_32px_w;

            // reseta botao horasExtras
            BtnHorasExtras.ForeColor = Color.FromArgb(240, 240, 240);
            BtnHorasExtras.BackColor = Color.FromArgb(64, 64, 64);
            BtnHorasExtras.Image = SmartHorasExtras.Properties.Resources.hora_extra_32px_w;


            AbrirTela<TelaLoginUsuario>();
        }


        // botao Configuracoes
        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            botaoLogarClicado = true;
            btnConfiguracoes.ForeColor = Color.FromArgb(64, 64, 64);
            btnConfiguracoes.BackColor = Color.FromArgb(240, 240, 240);
            btnConfiguracoes.Image = SmartHorasExtras.Properties.Resources.configuracao_32px_g;

            // reseta as configuracoes do botao 'Colaboradores'
            btnColaboradores.ForeColor = Color.FromArgb(240, 240, 240);
            btnColaboradores.BackColor = Color.FromArgb(64, 64, 64);
            btnColaboradores.Image = SmartHorasExtras.Properties.Resources.usuarios_32px_w;

            // reseta as configuracoes do bota 'Fechar'
            btnUsuarios.ForeColor = Color.FromArgb(240, 240, 240);
            btnUsuarios.BackColor = Color.FromArgb(64, 64, 64);
            btnUsuarios.Image = SmartHorasExtras.Properties.Resources.usuario_32px_w;

            // reseta botao Login
            btnLogin.ForeColor = Color.FromArgb(240, 240, 240);
            btnLogin.BackColor = Color.FromArgb(64, 64, 64);
            btnLogin.Image = SmartHorasExtras.Properties.Resources.chave_32px_w;

            // reseta botao HorasExtras
            BtnHorasExtras.ForeColor = Color.FromArgb(240, 240, 240);
            BtnHorasExtras.BackColor = Color.FromArgb(64, 64, 64);
            BtnHorasExtras.Image = SmartHorasExtras.Properties.Resources.hora_extra_32px_w;


            // abre a tela de Configuracao
            AbrirTela<TelaConfiguracoes>();

            // remove Telas 
            FecharTela<TelaCadastroUsuario>();
        }

        // botao Sobre
        private void btnSobre_Click(object sender, EventArgs e)
        {
            FormSobreApp messageSobre = new FormSobreApp();

            // mostra informacoes da aplicaçao
            messageSobre.ShowDialog();
        }


        public void TaskBar(bool taskBar)
        {
            this.ShowInTaskbar = taskBar;
        }

        // metodo para criação de arquivo ini se necessario
        private void CriaArquivoIni()
        {
            // metodos para cria um novo caminho Ini caso precisar
            INiFilesPadrao iniFiles = new INiFilesPadrao(caminhoDiretorioIni);

            // verficia se ja tem arquivo .ini
            if (!iniFiles.KeyExists("Caminho", "BancoDados"))
            {
                // preenche arquivo .ini
                iniFiles.Write("Caminho", "@C:\\ControleHorasExtras\\", "BancoDados");
            }
            iniFiles = new INiFilesPadrao(caminhoDiretorioIni, true);
        }


        // DLL de importacao 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int Iparam);
    }
}