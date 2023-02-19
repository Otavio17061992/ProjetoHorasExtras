using SmartHorasExtras.Controllers.FormMessageBox;
using SmartHorasExtras_DB.Dominios;
using SmartHorasExtras_DB.Metodos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHorasExtras.Views
{
    public partial class TelaListaHorasExtras : Form
    {
        string ano;
        int mes;
        int year;
        DateTime data;
        string NomeMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
        CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");
        public static int parentX, parentY;
        int item_selecionado = -1;
        public HorasExtrasDominios horas_extras = new HorasExtrasDominios();
        public bool editar = false, addicionar = false, clickDuplo = false, clickDuploAlterar = false;
        string DataTabela;
        TelaColaboradores tela_colaborador = Application.OpenForms.OfType<TelaColaboradores>().FirstOrDefault();
        string DataParaExcluir;
        TelaPrincipal tela_principal = Application.OpenForms.OfType<TelaPrincipal>().FirstOrDefault();
        int IdUsuario = 0;
        private PrintDocument printDocument;

        // Lista de feriados Nacionais (Brazil)
        private static List<DateTime> FeriadosNacionais = new List<DateTime>()
        {
        new DateTime(2023, 1, 1), // Ano novo
        new DateTime(2023, 4, 21), // Tiradentes
        new DateTime(2023, 5, 1), // Dia do trabalhador
        new DateTime(2023, 9, 7), // Dia da Independencia
        new DateTime(2023, 10, 12), // Nossa Senhora Aparecida
        new DateTime(2023, 11, 2), // Dia dos finados
        new DateTime(2023, 11, 15), // Proclamacao da republica
        new DateTime(2023, 12, 25) // Natal
        };

        private static List<string> FeriadosNacionaisText = new List<string>()
        {
            "01-01",
            "04-21",
            "05-01",
            "09-07",
            "10-12",
            "11-02",
            "11-15",
            "12-25",
        };

        public TelaListaHorasExtras()
        {
            InitializeComponent();

            comboBoxMes.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);

            comboBoxAno.Text = DateTime.Now.Year.ToString();

            // Verifica se a tela_colaborador é nula e atribui valores aos elementos de texto e exibição
            if (tela_colaborador != null)
            {
                textBoxNomeColab.Text = tela_colaborador.nomeColab;
                botaoVoltar.Visible = true;
                IdUsuario = tela_colaborador.HorasExtras.id;
            }
            else
            {
                textBoxNomeColab.Visible = false;
                labelNomeColab.Visible = false;
                botaoVoltar.Visible = false;
                IdUsuario = tela_principal.HorasExtras.id;
            }

            // Altera a cor dos dias de domingo e feriados
            AlteraCorDomingosFeriados();

            // Copia os dados da tabela de horas extras para o listview
            CopiaDataTableParaListView(CriaTabelaHorasExtra(), listvewHorasExtras);

            // Desabilita botoes do listview inicialmente
            btnAddHoras.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

            // Soma a quantidade de horas extras no listview
            SomaQuantidadeHorasExtras(listvewHorasExtras);

            tela_principal.MudaVisibilidadeBtnImprimir(true);
            tela_principal.btnimprimirClicado += new EventHandler(PrintButton);
            // Cria um novo documento de impressão
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void PrintButton(object sender, EventArgs e)
        {
            // Captura a tela
            Bitmap printScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printScreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printScreen.Size);

            // Adiciona a imagem capturada ao documento de impressão
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.DefaultPageSettings.PrinterSettings.DefaultPageSettings.Landscape = true;
            printDocument.PrintController = new StandardPrintController();
            printDocument.Print();

            // Abre outra tela com a lista de impressoras disponíveis
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowDialog();
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Captura a imagem do formulário
            Bitmap formImage = new Bitmap( listvewHorasExtras.Width, listvewHorasExtras.Height);
            this.DrawToBitmap(formImage, new Rectangle(0, 0, formImage.Width, formImage.Height));

            // Desenha a imagem do formulário na página de impressão
            e.Graphics.DrawImage(formImage, 0, 0);

            
        }

        private void TelaAddHorasExtras_Load(object sender, EventArgs e)
        {
            // Cria a tabela de horas extras
            CriaTabelaHorasExtra();

            // Carrega os intervalos de horas extras
            CarregaIntervalosHorasExtras();

            // Soma a quantidade de horas extras no listview
            SomaQuantidadeHorasExtras(listvewHorasExtras);

            // Altera a cor dos dias de domingo e feriados
            AlteraCorDomingosFeriados();
        }

        private List<HorasExtrasDominios> AddHorasExtraTabela(DataTable table)
        {
            // Lista de horas extras a ser retornada
            var listaHorasExtras = new List<HorasExtrasDominios>();

            // Iterar sobre as linhas da tabela
            foreach (DataRow row in table.Rows)
            {
                // Cria um novo objeto HorasExtrasDominios
                HorasExtrasDominios horasExtra = new HorasExtrasDominios();
                horasExtra.data = DateTime.Parse(row["DataRegistro"].ToString());
                horasExtra.cliente = row["Cliente"].ToString();
                horasExtra.p1_entrada = row["Entrada_1"].ToString();
                horasExtra.p1_saida = row["Saida_1"].ToString();
                horasExtra.p2_entrada = row["Entrada_2"].ToString();
                horasExtra.p2_saida = row["Saida_2"].ToString();

                // Adiciona o objeto horasExtra à lista
                listaHorasExtras.Add(horasExtra);
            }

            // Retorna a lista de horas extras
            return listaHorasExtras;
        }


        // volta para tela de colaboradores
        private void botaoVoltar_Click(object sender, EventArgs e)
        {
            //AlteraTamanhoTelaPrincipal();
            this.Close();
        }

        // mes selecionado
        private void comboBoxMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Copia o conteudo da tabela para o listView
            CopiaDataTableParaListView(CriaTabelaHorasExtra(), listvewHorasExtras);

            // Altera a cor dos dias de domingo e feriado
            AlteraCorDomingosFeriados();

            // Carrega os intervalos de horas extras
            CarregaIntervalosHorasExtras();

            SomaQuantidadeHorasExtras(listvewHorasExtras);
        }

        // ano selecionado
        private void comboBoxAno_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Copia o conteudo da tabela para o listView
            CopiaDataTableParaListView(CriaTabelaHorasExtra(), listvewHorasExtras);

            // Altera a cor dos dias de domingo e feriado
            AlteraCorDomingosFeriados();

            // Carrega os intervalos de horas extras
            CarregaIntervalosHorasExtras();

            SomaQuantidadeHorasExtras(listvewHorasExtras);
        }


        /// <summary>
        /// Converte o mes recebido como string escrito por extenso
        /// em um int equivalente ao mesmo
        /// </summary>
        private void SelecionaMesesdoAno()
        {
            // cria um dicionário para mapear nomes de meses para seus valores int correspondentes
            var meses = new Dictionary<string, int>()
            {
                {"janeiro", 1},
                {"fevereiro", 2},
                {"março", 3},
                {"abril", 4},
                {"maio", 5},
                {"junho", 6},
                {"julho", 7},
                {"agosto", 8},
                {"setembro", 9},
                {"outubro", 10},
                {"novembro", 11},
                {"dezembro", 12}
            };
            // usa o dicionário para obter o valor int para o mês selecionado
            mes = meses[comboBoxMes.SelectedItem.ToString()];
        }

        // gera dataTable 
        private DataTable CriaTabelaHorasExtra()
        {
            DataTable dt = new DataTable();

            // Chama método que contem dicionario de meses
            SelecionaMesesdoAno();

            // Adiciona colunas à tabela
            dt.Columns.Add("01");
            dt.Columns.Add("02");
            dt.Columns.Add("03");
            dt.Columns.Add("04");
            dt.Columns.Add("05");
            dt.Columns.Add("06");
            dt.Columns.Add("07");
            dt.Columns.Add("08");
            dt.Columns.Add("09");
            dt.Columns.Add("10");
            dt.Columns.Add("11");
            dt.Columns.Add("12");
            dt.Columns.Add("13");
            dt.Columns.Add("14");
            dt.Columns.Add("15");

            // armazena campo ano
            ano = comboBoxAno.GetItemText(comboBoxAno.Text);

            // converte ano de texto para inteiro
            year = int.Parse(ano);

            data = new DateTime(year, mes, 1);

            // armazena o id do Usuario
            horas_extras.colaborador_id = IdUsuario;

            // armazena o mes 
            DataTabela = data.ToString("MM-");

            // percorre todos os dias do mes
            do
            {
                bool ExisteDiaDb = false;
                bool mesIgual = false;

                // Armazena a lista de horas extras retornada pelo método AddHorasExtraTabela
                var dbInfo = AddHorasExtraTabela(HorasExtrasMetodos.GetHorasExtras(horas_extras));


                // Altera a cultura para pt-BR
                var dia = culture.DateTimeFormat.GetDayName(data.DayOfWeek);

                // Loop que percorre a lista de horas extras
                foreach (HorasExtrasDominios item in dbInfo)
                {
                    // Verifica se a data na tabela é igual à data no banco de dados
                    if (data == item.data)
                    {
                        preencheCamposDatabela(item);

                        // Preenche a linha da tabela com os dados do banco de dados 
                        dt.Rows.Add(dia, data.ToString("dd"), item.cliente, DateTime.Parse(item.p1_entrada).ToString("HH:mm"), DateTime.Parse(item.p1_saida).ToString("HH:mm"), "", "", "", "", DateTime.Parse(item.p2_entrada).ToString("HH:mm"), DateTime.Parse(item.p2_saida).ToString("HH:mm"));
                        ExisteDiaDb = true;
                        mesIgual = true;
                    }
                }

                // verifica se nao tem o dia no banco de dados
                if (ExisteDiaDb != true && mesIgual != true)
                {
                    // adiciona a linha padrao da tabela 
                    dt.Rows.Add(dia, data.ToString("dd"));
                }

                data = data.AddDays(1);

            } while (data.Month == mes);

            return dt;
        }

        // Converte DataTable em um listView
        public void CopiaDataTableParaListView(DataTable dataT, ListView lisview)
        {
            lisview.BeginUpdate();

            // se a contagem de colunas for diferente (normalmente ainda não preenchida)
            if (lisview.Columns.Count != dataT.Columns.Count)
            {
                lisview.Columns.Clear();

                // preparar colunas
                foreach (DataColumn column in dataT.Columns)
                {
                    lisview.Columns.Add(column.ColumnName);
                }
            }

            // Limpa linhas
            lisview.Items.Clear();

            // Carrega Linhas
            foreach (DataRow row in dataT.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());

                // percorre as colunas da tabela
                for (int i = 1; i < dataT.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                lisview.Items.Add(item);
            }

            lisview.EndUpdate();
        }

        /// <summary>
        /// Metodo que percorre o listView a partir da segunda posicao
        /// verificam se contem algum subItem preenchido, desabilita botoes adcionar
        /// se estiver preenchido, habilita botoes excluir e editar.
        /// </summary>
        private void CheckListViewSelectedItem(ListView listView, Control controlToEnableOrDisable)
        {
            bool allEmpty = true;

            // verifica qual indice do listView
            if (listView.SelectedIndices.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];

                // percorre o listView 
                for (int i = 2; i < selectedItem.SubItems.Count; i++)
                {
                    // verifica subItem esta preenchido
                    if (!string.IsNullOrEmpty(selectedItem.SubItems[i].Text))
                    {
                        allEmpty = false;
                        break;
                    }
                }
            }

            // desabilita controle Addicionar
            controlToEnableOrDisable.Enabled = allEmpty;

            //  verifica se a linha selecionada esta vazia 
            if (allEmpty == true)
            {
                // desabilita botao editar e excluir
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            else // se a linha estiver preenchida habilita editar e excluir
            {
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        // adiciona tela para cadastrar horas extras
        private void btnAddHoras_Click(object sender, EventArgs e)
        {
            addicionar = true;

            // metodo atualiza os dados da listview 
            AtualizaListViewDados();
        }

        // evento click botao editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            editar = true;

            // metodo atualiza os dados da listview 
            AtualizaListViewDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            bool colunaClienteVazia = true;

            // percorre as colunas do listview
            foreach (ListViewItem item in listvewHorasExtras.Items)
            {
                // verifica se a coluna cliente selecionada esta preenchida
                if (!string.IsNullOrEmpty(item.SubItems[2].Text))
                {
                    colunaClienteVazia = false;
                }
            }

            if (colunaClienteVazia == false)
            {
                FormMessage msgAtencao = new FormMessage("Atenção", "Deseja realmente excluir horas extras?", SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.YesNo, MessageBoxButtons.YesNo);
                msgAtencao.ShowDialog();

                if (msgAtencao.DialogResult == DialogResult.Yes)
                {
                    // verifica linha selecionada esta vazia 
                    if (listvewHorasExtras.SelectedItems.Count > 0)
                    {
                        // exclui do banco de dados
                        HorasExtrasMetodos.ExcluirHorasExtras(horas_extras);

                        // chama o método para limpar os subitens
                        LimparSubitens(listvewHorasExtras.Items[item_selecionado]);

                        // limpa subitens
                        listvewHorasExtras.SelectedItems.Clear();

                        // atualiza textBox Total horas
                        SomaQuantidadeHorasExtras(listvewHorasExtras);
                    }
                    else
                    {
                        FormMessage msgErro = new FormMessage("Atenção", "Nenhum item selecionado.\n Por favor, Selecione um item", SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.OK);
                        msgErro.ShowDialog();
                        return;
                    }
                }
            }
        }

        private void LimparSubitens(ListViewItem item)
        {
            // lista com os índices dos subitens a serem limpados
            int[] indices = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            // percorre a lista e limpa os subitens
            foreach (int indice in indices)
            {
                item.SubItems[indice].Text = string.Empty;
            }
        }

        // verifica linha selecionada no listview
        private void listvewHorasExtras_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // armazena index selecionado
            item_selecionado = e.ItemIndex;

            horas_extras = new HorasExtrasDominios();

            horas_extras.mes = string.Format("{0}", comboBoxMes.SelectedIndex + 1);
            horas_extras.ano = string.Format("{0}", comboBoxAno.SelectedIndex + 2022);

            // chama o método para atribuir os valores dos subitens aos atributos da classe
            AtribuirValoresSubitens(horas_extras, listvewHorasExtras.Items[item_selecionado]);

        }

        // atribui valores ao Subitens do listview Horas Extras
        private void AtribuirValoresSubitens(HorasExtrasDominios horas_extras, ListViewItem item)
        {
            // Atribui o valor do subitem na posição 0 (semana) ao campo semana de horas_extras
            horas_extras.semana = item.SubItems[0].Text;

            // Atribui o valor do subitem na posição 1 (dia) ao campo dia de horas_extras
            horas_extras.dia = item.SubItems[1].Text;

            // Atribui o valor do subitem na posição 2 (cliente) ao campo cliente de horas_extras
            horas_extras.cliente = item.SubItems[2].Text;

            // Atribui o valor do subitem na posição 3 (p1_entrada) ao campo p1_entrada de horas_extras
            horas_extras.p1_entrada = item.SubItems[3].Text;

            // Atribui o valor do subitem na posição 4 (p1_saida) ao campo p1_saida de horas_extras
            horas_extras.p1_saida = item.SubItems[4].Text;

            // Atribui o valor do subitem na posição 5 (p1_60) ao campo p1_60 de horas_extras
            horas_extras.p1_60 = item.SubItems[5].Text;

            // Atribui o valor do subitem na posição 6 (p1_20_1) ao campo p1_20_1 de horas_extras
            horas_extras.p1_20_1 = item.SubItems[6].Text;

            // Atribui o valor do subitem na posição 7 (p1_100) ao campo p1_100 de horas_extras
            horas_extras.p1_100 = item.SubItems[7].Text;

            // Atribui o valor do subitem na posição 8 (p1_20_2) ao campo p1_20_2 de horas_extras
            horas_extras.p1_20_2 = item.SubItems[8].Text;

            // Atribui o valor do subitem na posição 9 (p2_entrada) ao campo p2_entrada de horas_extras
            horas_extras.p2_entrada = item.SubItems[9].Text;

            // Atribui o valor do subitem na posição 10 (p2_saida) ao campo p2_saida de horas_extras
            horas_extras.p2_saida = item.SubItems[10].Text;

            // Atribui o valor do subitem na posição 11 (p2_60) ao campo p2_60 de horas_extras
            horas_extras.p2_60 = item.SubItems[11].Text;

            // Atribui o valor do subitem na posição 12 (p2_20_1) ao campo p2_20_1 de horas_extras
            horas_extras.p2_20_1 = item.SubItems[12].Text;

            // Atribui o valor do subitem na posição 13 (p_100) ao campo p2_100 de horas_extras
            horas_extras.p2_100 = item.SubItems[13].Text;

            // Atribui o valor do subitem na posição 14 (p2_20_2) ao campo p2_20_2 de horas_extras
            horas_extras.p2_20_2 = item.SubItems[14].Text;


            // Formatar a data para o padrão dd/MM/yyyy HH:mm:ss
            DataParaExcluir = string.Format("{2}/{1}/{0} 00:00:00", item.SubItems[1].Text,
            // Adicionar 1 ao índice do comboboxMes, pois o índice começa a partir de 0
            string.Format("{0}", comboBoxMes.SelectedIndex + 1),
            // Adicionar 2022 ao índice do comboboxAno, pois o ano mínimo é 2022
            string.Format("{0}", comboBoxAno.SelectedIndex + 2022));

            // Converter a data para o tipo DateTime e atribuir ao campo "data" de horas_extras
            horas_extras.data = DateTime.Parse(DataParaExcluir);
        }

        //Abre uma nova tela para cadastrar as horas extras do funcionário
        private void AbriTelaCadastrarHorasExtras()
        {
            // Utiliza o bloco using para criar uma instância da tela de cadastro de horas extras
            using (Form modalTelaCadastrar = new TelaCadastrarHorasExtras())
            {
                // Armazena as coordenadas da janela principal
                parentX = this.Location.X;
                parentY = this.Location.Y;
                // Não exibe a tela no taskbar
                modalTelaCadastrar.ShowInTaskbar = false;
                // Mostra a tela como diálogo (bloqueia a interação com a janela principal até que a tela de cadastro seja fechada)
                modalTelaCadastrar.ShowDialog();
            }

            // Verifica se o subitem "Cliente" está preenchido na linha selecionada da lista de horas extras
            if (listvewHorasExtras.Items[item_selecionado].SubItems[2].Text != null)
            {
                // Define a variável como verdadeira indicando que o registro foi alterado
                clickDuploAlterar = true;
            }
        }



        // método responsável por abrir a tela de cadastro de horas extras com duplo clique na lista
        private void listvewHorasExtras_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // verifica se o campo "cliente" está preenchido
            if (string.IsNullOrEmpty(horas_extras.cliente))
            {
                clickDuploAlterar = false;
                clickDuplo = true;
            }
            else
            {
                clickDuploAlterar = true;
                clickDuplo = false;
            }

            // verifica se há um item selecionado na lista
            if (listvewHorasExtras.SelectedIndices.Count > 0)
            {
                // obtém o item selecionado na lista
                ListViewItem selectedItem = listvewHorasExtras.SelectedItems[0];

                // percorre os subitens da coluna selecionada
                for (int i = 1; i < selectedItem.SubItems.Count; i++)
                {
                    // verifica se a coluna selecionada está preenchida
                    if (!string.IsNullOrEmpty(selectedItem.SubItems[i].Text))
                    {
                        // mostra o painel de fundo transparente
                        panelTrasnparente.BackColor = Color.FromArgb(125, Color.Black);
                        panelTrasnparente.Visible = true;
                        panelTrasnparente.BringToFront();

                        // atualiza a lista com os dados da tela de cadastro
                        AtualizaListViewDados();

                        // esconde o painel de fundo transparente
                        panelTrasnparente.Visible = false;

                        break;
                    }
                }
            }
            else
            {
                // exibe uma mensagem de erro caso não haja item selecionado na lista
                FormMessage msgErro = new FormMessage("Atenção", "Nenhum item selecionado.\n Por favor, Selecione um item", SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.OK);
                msgErro.ShowDialog();
                return;
            }
        }


        private void listvewHorasExtras_Click(object sender, EventArgs e)
        {
            // Obtem a referência ao controle ListView 
            ListView listView = listvewHorasExtras;

            // Obtem a referência ao controle a ser desabilitado
            Control controlToDisable = btnAddHoras;

            // chama o metodo para verificar o listview
            CheckListViewSelectedItem(listView, controlToDisable);
        }

        /// <summary>
        /// Atualiza a ListView com dados recebidos da class horas extras
        /// </summary>
        private void AtualizaListViewDados()
        {
            if (listvewHorasExtras.SelectedItems.Count > 0)
            {
                panelTrasnparente.BackColor = Color.FromArgb(125, Color.Black);
                panelTrasnparente.Visible = true;
                panelTrasnparente.BringToFront();

                AbriTelaCadastrarHorasExtras();
                panelTrasnparente.Visible = false;

                // armazena as horas extras no primeiro e segundo periodo
                listvewHorasExtras.Items[item_selecionado].SubItems[0].Text = horas_extras.semana;
                listvewHorasExtras.Items[item_selecionado].SubItems[2].Text = horas_extras.cliente;
                listvewHorasExtras.Items[item_selecionado].SubItems[3].Text = horas_extras.p1_entrada;
                listvewHorasExtras.Items[item_selecionado].SubItems[4].Text = horas_extras.p1_saida;
                listvewHorasExtras.Items[item_selecionado].SubItems[9].Text = horas_extras.p2_entrada;
                listvewHorasExtras.Items[item_selecionado].SubItems[10].Text = horas_extras.p2_saida;

                // verifica se cliente esta vazio
                if (!string.IsNullOrWhiteSpace(horas_extras.cliente))
                {
                    if (string.IsNullOrWhiteSpace(listvewHorasExtras.Items[item_selecionado].SubItems[3].Text)
                         && string.IsNullOrWhiteSpace(listvewHorasExtras.Items[item_selecionado].SubItems[4].Text))
                    {
                        listvewHorasExtras.Items[item_selecionado].SubItems[3].Text = "00:00";
                        listvewHorasExtras.Items[item_selecionado].SubItems[4].Text = "00:00";
                    }
                    else if (string.IsNullOrWhiteSpace(listvewHorasExtras.Items[item_selecionado].SubItems[9].Text)
                       && string.IsNullOrWhiteSpace(listvewHorasExtras.Items[item_selecionado].SubItems[10].Text))
                    {
                        listvewHorasExtras.Items[item_selecionado].SubItems[9].Text = "00:00";
                        listvewHorasExtras.Items[item_selecionado].SubItems[10].Text = "00:00";
                    }
                }


                // calcula quantas horas tem em cada acrescimo de 60 20 ou 100%
                CalculateWorkingHours(horas_extras.p1_entrada, horas_extras.p1_saida, horas_extras.p2_entrada, horas_extras.p2_saida, horas_extras.semana);
            }
            else
            {
                FormMessage msgErro = new FormMessage("Atenção", "Nenhum item selecionado.\n Por favor, Selecione um item", SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.OK);
                msgErro.ShowDialog();
                return;
            }
        }

        // calcula o intervalo de horas extras
        private void CalculateWorkingHours(string startTime1, string endTime1, string startTime2, string endTime2, string dayOfWeek)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo format = (DateTimeFormatInfo)culture.GetFormat(typeof(DateTimeFormatInfo));
            string mesPorExtenso = data.ToString("MMMM", format);

            string primerDay = dayOfWeek;
            bool isHoliday = false;
            // Crie um dicionário para armazenar a porcentagem de horas de trabalho
            Dictionary<string, double> workingHours = new Dictionary<string, double>();
            workingHours.Add("p1_20_2", 0);
            workingHours.Add("p1_60", 0);
            workingHours.Add("p1_100", 0);
            workingHours.Add("p2_20_2", 0);
            workingHours.Add("p2_60", 0);
            workingHours.Add("p2_100", 0);

            // Verifique se o dia é feriado nacional
            isHoliday = EFeriadoNacional(data);

            if (isHoliday)
            {
                dayOfWeek = "domingo";

                if (mesPorExtenso == "maio")
                {
                    dayOfWeek = primerDay;
                }
            }
            // Calcule as horas de trabalho para o primeiro período
            if (!string.IsNullOrEmpty(startTime1) && !string.IsNullOrEmpty(endTime1))
            {
                TimeSpan interval = TimeSpan.Parse(endTime1) - TimeSpan.Parse(startTime1);

                // verifica se o dia corresponde a domingo 
                if (dayOfWeek == "domingo" && TimeSpan.Parse(endTime1) > TimeSpan.Parse("05:00"))
                {
                    // calcula intervalo da entrada com o limite de 05:00 
                    TimeSpan intervalBefore5AM = TimeSpan.Parse("05:00") - TimeSpan.Parse(startTime1);

                    // caso seja negativo 
                    if (intervalBefore5AM.TotalHours < 0)
                    {
                        // adiciona o zero 
                        workingHours["p1_20_2"] = 0;
                    }
                    else
                    {
                        workingHours["p1_20_2"] = intervalBefore5AM.TotalHours;
                    }
                }
                else
                {
                    // calcula intervalo da entrada com o limite de 05:00 
                    TimeSpan intervalBefore5AM = TimeSpan.Parse("05:00") - TimeSpan.Parse(startTime1);

                    // adiciona o zero 
                    if (intervalBefore5AM.TotalHours < 0)
                    {
                        workingHours["p1_20_2"] = 0;
                    }
                    else
                    {
                        workingHours["p1_20_2"] = intervalBefore5AM.TotalHours;
                    }


                    interval = TimeSpan.Parse(endTime1) - TimeSpan.Parse(startTime1);
                    workingHours["p1_60"] = interval.TotalHours;
                }
                workingHours["p1_100"] = interval.TotalHours;
            }

            // Calcule as horas de trabalho para o segundo período
            if (!string.IsNullOrEmpty(startTime2) && !string.IsNullOrEmpty(endTime2))
            {
                TimeSpan interval = TimeSpan.Parse(endTime2) - TimeSpan.Parse(startTime2);
                if (dayOfWeek == "domingo" && TimeSpan.Parse(endTime2) > TimeSpan.Parse("22:00"))
                {
                    TimeSpan intervalBefore10PM = TimeSpan.Parse(endTime2) - TimeSpan.Parse("22:00");

                    // verifica se intervalo de tempo é negativo
                    if (intervalBefore10PM.TotalHours < 0)
                    {
                        workingHours["p2_20_2"] = 0;
                    }
                    else
                    {
                        // armazena o intervalo de horas p2_20_2
                        workingHours["p2_20_2"] = intervalBefore10PM.TotalHours;
                    }
                }
                else
                {
                    // calcula o horario de saida com o limite de 22:00 
                    TimeSpan intervalBefore10PM = TimeSpan.Parse(endTime2) - TimeSpan.Parse("22:00");

                    // verifica se intervalo de tempo é negativo
                    if (intervalBefore10PM.TotalHours < 0)
                    {
                        workingHours["p2_20_2"] = 0;
                    }
                    else
                    {
                        // armazena o intervalo de horas p2_20_2
                        workingHours["p2_20_2"] = intervalBefore10PM.TotalHours;
                    }

                    // calcula o intervalo de horas entra saida e entrada
                    interval = TimeSpan.Parse(endTime2) - TimeSpan.Parse(startTime2);

                    workingHours["p2_60"] = interval.TotalHours;
                }
                workingHours["p2_100"] = interval.TotalHours;
            }
            AddWorkingHoursToListView(workingHours, dayOfWeek);
        }


        // metodo para preencher os intervalos nos subItems correspondentes no listViewHoras Extras
        private void AddWorkingHoursToListView(Dictionary<string, double> workingHours, string DaysOfWeek)
        {
            if (!string.IsNullOrEmpty(listvewHorasExtras.Items[item_selecionado].SubItems[2].Text))
            {
                // Verifica se o dia da semana e domingo
                if (DaysOfWeek == "domingo")
                {
                    // armazena os intervalos no listview primeiro periodo
                    listvewHorasExtras.Items[item_selecionado].SubItems[8].Text = workingHours["p1_20_2"].ToString("0.###");
                    listvewHorasExtras.Items[item_selecionado].SubItems[7].Text = workingHours["p1_100"].ToString("0.###");
                    listvewHorasExtras.Items[item_selecionado].SubItems[14].Text = workingHours["p2_20_2"].ToString("0.###");
                    listvewHorasExtras.Items[item_selecionado].SubItems[13].Text = workingHours["p2_100"].ToString("0.###");
                }
                else
                {
                    // armazena os intervalos no listview segundo periodo
                    listvewHorasExtras.Items[item_selecionado].SubItems[6].Text = workingHours["p1_20_2"].ToString("0.###");
                    listvewHorasExtras.Items[item_selecionado].SubItems[5].Text = workingHours["p1_60"].ToString("0.###");
                    listvewHorasExtras.Items[item_selecionado].SubItems[12].Text = workingHours["p2_20_2"].ToString("0.###");
                    listvewHorasExtras.Items[item_selecionado].SubItems[11].Text = workingHours["p2_60"].ToString("0.###");
                }
            }

            // atualiza os dados do textBox total Horas
            SomaQuantidadeHorasExtras(listvewHorasExtras);

        }

        /// <summary>
        /// Verifica se o dateTime atual e feria consultando 
        /// uma lista DateTime caso o dia selecionado seja 
        /// feriado nacional retorna true caso contrario false
        /// </summary>
        public bool EFeriadoNacional(DateTime date)
        {
            return FeriadosNacionais.Contains(date.Date);
        }

        // percorre o listView alterando a cor dos domingos 
        private void AlteraCorDomingosFeriados()
        {
            // percorre o listview
            foreach (ListViewItem item in listvewHorasExtras.Items)
            {
                if (item.Text == "domingo")
                {
                    // percorre as linhas horizontais do listview
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        // pinta de vermelho todos os textos das linhas horizontais
                        subItem.ForeColor = Color.Red;
                    }
                }

                // Percorre o listview
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    string dataS = DataTabela + subItem.Text;

                    bool temDia = false;

                    // verifica se o dia e o mes contem na lista de feriados
                    if (FeriadosNacionaisText.Contains(dataS) == true)
                    {
                        temDia = true;
                    }

                    // verifica se o dia e feriado
                    if (temDia == true)
                    {
                        // percorre os subItens 
                        foreach (ListViewItem.ListViewSubItem subItem2 in item.SubItems)
                        {
                            // pinta de vermelho todos os textos das linhas horizontais
                            subItem2.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        // verifica se nao contem nenhum valor nulo ou vazio na class
        private void preencheCamposDatabela(HorasExtrasDominios horasExtras)
        {
            // Verifique se o horário de entrada ou saída do primeiro período está vazio
            if (string.IsNullOrEmpty(horasExtras.p1_entrada) || string.IsNullOrEmpty(horasExtras.p1_saida))
            {
                // Se for, defina o horário de entrada e saída para 00:00
                horasExtras.p1_entrada = "00:00";
                horasExtras.p1_saida = "00:00";
            }
            // Verifique se o tempo de entrada ou saída do segundo período está vazio
            else if (string.IsNullOrEmpty(horasExtras.p2_entrada) || string.IsNullOrEmpty(horasExtras.p2_saida))
            {
                // Se for, defina o horário de entrada e saída para 00:00
                horasExtras.p2_entrada = "00:00";
                horasExtras.p2_saida = "00:00";
            }
        }

        // Metodo que carrega o intervalo de do banco de dados
        private void CarregaIntervalosHorasExtras()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo format = (DateTimeFormatInfo)culture.GetFormat(typeof(DateTimeFormatInfo));
            string mesPorExtenso = data.ToString("MMMM", format);
            string dayOfWeek;


            bool Ehfriado = false;
            for (int i = 0; i < listvewHorasExtras.Items.Count; i++)
            {
                // Calculo primeiro periodo
                DateTime p1_entrada;
                DateTime p1_saida;
                dayOfWeek = listvewHorasExtras.Items[i].SubItems[0].Text;

                string primerDay = dayOfWeek;

                // Verifica se contem valores vazios
                if (!string.IsNullOrEmpty(listvewHorasExtras.Items[i].SubItems[2].Text))
                {
                    if (DateTime.TryParse(listvewHorasExtras.Items[i].SubItems[3].Text, out p1_entrada) &&
                        DateTime.TryParse(listvewHorasExtras.Items[i].SubItems[4].Text, out p1_saida))
                    {
                        // Verifique se o dia é feriado nacional
                        Ehfriado = EFeriadoNacional(data);
                        if (Ehfriado)
                        {
                            dayOfWeek = "domingo";
                            if (mesPorExtenso == "maio")
                            {
                                dayOfWeek = primerDay;
                            }
                        }
                        // Calcula as horas de trabalho para o primeiro período
                        if (!string.IsNullOrEmpty(listvewHorasExtras.Items[i].SubItems[3].Text) && !string.IsNullOrEmpty(listvewHorasExtras.Items[i].SubItems[4].Text))
                        {
                            TimeSpan interval = TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[4].Text) - TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[3].Text);
                            if (dayOfWeek == "domingo" && TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[4].Text) > TimeSpan.Parse("05:00") ||
                                dayOfWeek == "domingo" && TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[4].Text) >= TimeSpan.Parse("00:00"))
                            {
                                // calcula o intervalo das 00:00 as 05:00
                                TimeSpan intervalBefore5AM = TimeSpan.Parse("05:00") - TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[3].Text);

                                // caso horas negativas 
                                if (intervalBefore5AM.TotalHours < 0)
                                {
                                    // adiciona zero ao listView
                                    listvewHorasExtras.Items[i].SubItems[8].Text = "0";
                                }
                                else
                                {
                                    if (listvewHorasExtras.Items[i].SubItems[4].Text != "00:00")
                                    {
                                        // adiciona o intervalo ao listview
                                        listvewHorasExtras.Items[i].SubItems[8].Text = intervalBefore5AM.TotalHours.ToString("0.###");
                                    }
                                    else
                                    {
                                        listvewHorasExtras.Items[i].SubItems[8].Text = "0";
                                    }
                                }

                                // adiciona o total de intervalo ao listview
                                listvewHorasExtras.Items[i].SubItems[7].Text = interval.TotalHours.ToString("0.###");
                            }
                            else
                            {
                                // armazena intervalo de horas entre as 5 da manha ao horario de entrada
                                TimeSpan intervalBefore5AM = TimeSpan.Parse("05:00") - TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[3].Text);

                                // verifica se o resutado e negativo
                                if (intervalBefore5AM.TotalHours < 0)
                                {
                                    // armazena zero
                                    listvewHorasExtras.Items[i].SubItems[6].Text = "0";
                                }
                                else
                                {
                                    // verifica se contem a data hora 00:00
                                    if (listvewHorasExtras.Items[i].SubItems[4].Text != "00:00")
                                    {
                                        // armazena no intervalo de horas 0
                                        listvewHorasExtras.Items[i].SubItems[6].Text = intervalBefore5AM.TotalHours.ToString("0.###");
                                    }
                                    else
                                    {
                                        listvewHorasExtras.Items[i].SubItems[6].Text = "0";
                                    }
                                }

                                interval = TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[4].Text) - TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[3].Text);
                                listvewHorasExtras.Items[i].SubItems[5].Text = interval.TotalHours.ToString("0.###");
                            }
                        }

                        // Calculo segundo periodo 
                        DateTime p2_entrada;
                        DateTime p2_saida;
                        if (DateTime.TryParse(listvewHorasExtras.Items[i].SubItems[9].Text, out p2_entrada) &&
                            DateTime.TryParse(listvewHorasExtras.Items[i].SubItems[10].Text, out p2_saida))
                        {
                            // Calcula as horas de trabalho para o segundo período
                            if (!string.IsNullOrEmpty(listvewHorasExtras.Items[i].SubItems[9].Text) && !string.IsNullOrEmpty(listvewHorasExtras.Items[i].SubItems[10].Text))
                            {
                                TimeSpan interval = TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[10].Text) - TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[9].Text);
                                if (dayOfWeek == "domingo" && TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[10].Text) > TimeSpan.Parse("22:00") ||
                                    dayOfWeek == "domingo" && TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[10].Text) >= TimeSpan.Parse("00:00"))
                                {
                                    TimeSpan intervalBefore10PM = TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[10].Text) - TimeSpan.Parse("22:00");
                                    // verifica se intervalo de tempo é negativo
                                    if (intervalBefore10PM.TotalHours < 0)
                                    {
                                        listvewHorasExtras.Items[i].SubItems[14].Text = "0";
                                    }
                                    else
                                    {
                                        // verifica hora sai primeiro periodo
                                        if (listvewHorasExtras.Items[i].SubItems[10].Text != "00:00")
                                        {
                                            listvewHorasExtras.Items[i].SubItems[14].Text = intervalBefore10PM.TotalHours.ToString("0.###");
                                        }
                                        else
                                        {
                                            listvewHorasExtras.Items[i].SubItems[14].Text = "0";
                                        }
                                    }

                                    listvewHorasExtras.Items[i].SubItems[13].Text = interval.TotalHours.ToString("0.###");
                                }
                                else
                                {
                                    TimeSpan intervalBefore10PM = TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[10].Text) - TimeSpan.Parse("22:00");

                                    // verifica se intervalo de tempo é negativo
                                    if (intervalBefore10PM.TotalHours < 0)
                                    {
                                        listvewHorasExtras.Items[i].SubItems[12].Text = "0";
                                    }
                                    else
                                    {
                                        // verifica se hora saida primeiro periodo 
                                        if (listvewHorasExtras.Items[i].SubItems[10].Text != "00:00")
                                        {
                                            listvewHorasExtras.Items[i].SubItems[12].Text = intervalBefore10PM.TotalHours.ToString("0.###");
                                        }
                                        else
                                        {
                                            listvewHorasExtras.Items[i].SubItems[12].Text = "0";
                                        }
                                    }

                                    interval = TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[10].Text) - TimeSpan.Parse(listvewHorasExtras.Items[i].SubItems[9].Text);
                                    listvewHorasExtras.Items[i].SubItems[11].Text = interval.TotalHours.ToString("0.###");
                                }
                            }
                        }
                    }

                }

            }
        }


        private void SomaQuantidadeHorasExtras(ListView listview)
        {
            double total60p_1 = 0, total20p1_1 = 0, total100p1 = 0, total20p1_2 = 0;

            textBox60P.Text = "";
            textBox20P1.Text = "";
            textBox20P2.Text = "";
            textBox100P.Text = "";



            // iterar através de cada item na exibição de lista
            foreach (ListViewItem item in listview.Items)
            {
                // verifique se o 5º subitem (coluna) nao esta vazio
                if (!string.IsNullOrEmpty(item.SubItems[5].Text))
                {
                    total60p_1 += double.Parse(item.SubItems[5].Text);

                    // verifique se o 11º subitem (coluna) nao esta vazio
                    if (!string.IsNullOrEmpty(item.SubItems[11].Text))
                    {
                        total60p_1 += double.Parse(item.SubItems[11].Text);
                    }
                }

                // verifique se o 6º subitem (coluna) nao esta vazio
                if (!string.IsNullOrEmpty(item.SubItems[6].Text))
                {
                    total20p1_1 += double.Parse(item.SubItems[6].Text);

                    // verifique se o 12º subitem (coluna) nao esta vazio
                    if (!string.IsNullOrEmpty(item.SubItems[12].Text))
                    {
                        total20p1_1 += double.Parse(item.SubItems[12].Text);
                    }
                }

                // verifique se o 7º subitem (coluna) nao esta vazio
                if (!string.IsNullOrEmpty(item.SubItems[7].Text))
                {
                    total100p1 += double.Parse(item.SubItems[7].Text);

                    // verifique se o 13º subitem (coluna) nao esta vazio
                    if (!string.IsNullOrEmpty(item.SubItems[13].Text))
                    {
                        total100p1 += double.Parse(item.SubItems[13].Text);
                    }
                }

                // verifique se o 8º subitem (coluna) nao esta vazio
                if (!string.IsNullOrEmpty(item.SubItems[8].Text))
                {
                    total20p1_2 += double.Parse(item.SubItems[8].Text);

                    // verifique se o 14º subitem (coluna) nao esta vazio
                    if (!string.IsNullOrEmpty(item.SubItems[14].Text))
                    {
                        total20p1_2 += double.Parse(item.SubItems[14].Text);
                    }
                }
            }

            // adiciona as somas os textBox total 
            textBox60P.Text = total60p_1.ToString();
            textBox20P1.Text = total20p1_1.ToString();
            textBox100P.Text = total100p1.ToString();
            textBox20P2.Text = total20p1_2.ToString();
        }



        private void AlteraCorBackGroundListView(ListView listview)
        {
            for (int i = 1; i < listview.Items.Count; i++)
            {
                for (int j = 0; j < listview.Items[i].SubItems.Count; j++)
                {
                    if (j > 0)
                    {
                        listview.Items[3].SubItems[j].BackColor = Color.Red;
                        if (j >= 2)
                        {
                            listview.Items[3].SubItems[j].BackColor = Color.Purple;
                        }
                    }

                }
            }
        }

        private void listvewHorasExtras_ParentChanged(object sender, EventArgs e)
        {
            btnAddHoras.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

    }
}
