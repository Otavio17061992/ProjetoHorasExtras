using SmartHorasExtras.Controllers.FormMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartHorasExtras_DB.Metodos;
using SmartHorasExtras_DB.Dominios;

namespace SmartHorasExtras.Views
{
    public partial class TelaCadastrarHorasExtras : Form
    {
        TelaListaHorasExtras tela_horas_extras = Application.OpenForms.OfType<TelaListaHorasExtras>().FirstOrDefault();
        TelaPrincipal tela_principal = Application.OpenForms.OfType<TelaPrincipal>().FirstOrDefault();
        TelaColaboradores tela_colaboradores = Application.OpenForms.OfType<TelaColaboradores>().FirstOrDefault();
        string EntradaHoras, SaidaHoras;
        bool clientePreenchido = true;
        bool preenchimentoCorreto = true;
        HorasExtrasDominios HorasExtrasDb = new HorasExtrasDominios();
        bool botaoEditarClick = false;
        bool botaoAddicionarClick = false;
        bool addclickDuplo = false;

        bool primeiroPeriodoOK = true;



        public TelaCadastrarHorasExtras()
        {
            InitializeComponent();
        }

        // Método que verifica qual evento de clique foi acionado dos botões editar, adicionar ou duplo clique do mouse
        private void VerificaBotaoClicado()
        {
            if (tela_horas_extras.addicionar)
            {
                // Se o botão adicionar foi clicado
                buttonAdicionar.Text = "Adicionar";
                tela_horas_extras.addicionar = false;
                botaoAddicionarClick = true;
            }
            else if (tela_horas_extras.editar)
            {
                // Se o botão editar foi clicado
                buttonAdicionar.Text = "Alterar";
                tela_horas_extras.editar = false;
                botaoEditarClick = true;
            }
            else if (tela_horas_extras.clickDuploAlterar)
            {
                // Se o duplo clique foi acionado e o botão editar foi clicado
                buttonAdicionar.Text = "Alterar";
                tela_horas_extras.clickDuploAlterar = false;
            }
            else if (tela_horas_extras.clickDuplo)
            {
                // Se o duplo clique foi acionado e o botão adicionar foi clicado
                buttonAdicionar.Text = "Adicionar";
                tela_horas_extras.clickDuplo = false;
                addclickDuplo = true;
            }
        }

        private void TelaCadastrarHorasExtras_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            PreencheCamposTextBox();

            textBoxCliente.Text = tela_horas_extras.horas_extras.cliente;
            ReparteHoraExtra(tela_horas_extras.horas_extras.p1_entrada, textHoraEntradaP1, textMinutoEntradaP1);
            ReparteHoraExtra(tela_horas_extras.horas_extras.p1_saida, textHoraSaidaP1, textMinutoSaidaP1);
            ReparteHoraExtra(tela_horas_extras.horas_extras.p2_entrada, textHoraEntradaP2, textMinutoEntradaP2);
            ReparteHoraExtra(tela_horas_extras.horas_extras.p2_saida, textHoraSaidaP2, textMinutoSaidaP2);

            // veririca qual botao foi clicado no form pai 'ListaHorasExtras'
            VerificaBotaoClicado();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            int estaPreenchido = 0;

            // lista para armazenar horas Extras
            var listaTextBox = new List<TextBox>
            {
            textHoraEntradaP1,
            textMinutoEntradaP1,
            textHoraSaidaP1,
            textMinutoSaidaP1,
            textHoraEntradaP2,
            textMinutoEntradaP2,
            textHoraSaidaP2,
            textMinutoSaidaP2
            };

            // percorre todos os textBox
            foreach (TextBox textBox in listaTextBox)
            {
                // verifica se tem algum textBox preenchido
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    // acumula 1 sempre que nao estiver preenchido
                    estaPreenchido += 1;
                }
            }

            // verifica se tem ao menos um preenchido
            if (estaPreenchido != 0)
            {
                this.Opacity = 0;
                panelCadastrarHoras.Hide();
                FormMessage msgSair = new FormMessage("ATENÇÃO", "Deseja Realmente cancelar as alterações?", SmartHorasExtras.Properties.Resources.pergunta1, MessageBoxButtons.YesNo, MessageBoxButtons.YesNo);
                msgSair.ShowDialog();

                // verifica se a resposta e sim para fechar a aplicacao
                if (msgSair.DialogResult == DialogResult.Yes)
                {
                    this.Close();
                    msgSair.Close();
                }
                else
                {
                    // aumenta opacidade do form cadastrarHoras
                    this.Opacity = 100;
                    panelCadastrarHoras.Show();
                    msgSair.Close();
                }
            }
            else
            {
                // fecha tela CadastrarHorasExtras
                this.Close();
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            // verifica se todos os textBox estao vazios
            var todosOsCamposEstaoVazios = string.IsNullOrEmpty(textHoraEntradaP1.Text) && string.IsNullOrEmpty(textMinutoEntradaP1.Text)
                                         && string.IsNullOrEmpty(textHoraSaidaP1.Text) && string.IsNullOrEmpty(textMinutoSaidaP1.Text)
                                         && string.IsNullOrEmpty(textHoraEntradaP2.Text) && string.IsNullOrEmpty(textMinutoEntradaP2.Text)
                                         && string.IsNullOrEmpty(textHoraSaidaP2.Text) && string.IsNullOrEmpty(textMinutoSaidaP2.Text);

            if (todosOsCamposEstaoVazios)
            {
                // Se todos os campos estiverem vazios, mostra uma mensagem de aviso e fecha a tela
                FormMessage msgAtencao = new FormMessage("ATENÇÃO", "Não foi Adicionada nenhuma hora extra", SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.OK);
                msgAtencao.ShowDialog();
                this.Close();
                return;
            }
            else if (string.IsNullOrEmpty(textHoraEntradaP1.Text) && string.IsNullOrEmpty(textMinutoEntradaP1.Text)
                && string.IsNullOrEmpty(textHoraSaidaP1.Text) && string.IsNullOrEmpty(textMinutoSaidaP1.Text))
            {
                // verifica se o campo cliente esta vazio
                if (string.IsNullOrEmpty(textBoxCliente.Text))
                {
                    // Se o campo cliente estiver vazio, mostra uma mensagem de erro e coloca o cursor no campo cliente
                    FormMessage msgErro = new FormMessage("Atenção", "O Campo Cliente é obrigatório",
                    SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.OK);
                    msgErro.ShowDialog();
                    textBoxCliente.Focus();
                    preenchimentoCorreto = false;
                    return;
                }
                else
                {
                    //valida o preenchimento do perido 2
                    ValidaGrupoPeriodo(textHoraEntradaP2, textMinutoEntradaP2, textHoraSaidaP2, textMinutoSaidaP2, groupBoxPerido2);
                    if (preenchimentoCorreto != true)
                    {
                        // mantem aberto a Tela CadastrarHorasExtras
                        this.Show();
                    }
                    else
                    {
                        // adiciona horas extras ao banco de dados 
                        AdicionaHorasBancoDados();


                        // fecha tela cadastrarHorasExtras
                        this.Close();
                    }
                }
            }
            else if (string.IsNullOrEmpty(textHoraEntradaP2.Text) && string.IsNullOrEmpty(textMinutoEntradaP2.Text)
                && string.IsNullOrEmpty(textHoraSaidaP2.Text) && string.IsNullOrEmpty(textMinutoSaidaP2.Text))
            {
                // verifica se o campo cliente esta vazio
                if (string.IsNullOrEmpty(textBoxCliente.Text))
                {
                    // Se o campo cliente estiver vazio, mostra uma mensagem de erro e coloca o cursor no campo cliente
                    FormMessage msgErro = new FormMessage("Atenção", "O Campo Cliente é obrigatório",
                    SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.OK);
                    msgErro.ShowDialog();
                    textBoxCliente.Focus();
                    preenchimentoCorreto = false;
                    return;
                }
                else
                {
                    //valida o preenchimento do perido 1
                    ValidaGrupoPeriodo(textHoraEntradaP1, textMinutoEntradaP1, textHoraSaidaP1, textMinutoSaidaP1, groupBoxPerido1);

                    // verifica se o preenchimento esta correto
                    if (preenchimentoCorreto == false)
                    {
                        // mantem a tela CadastrarHorasExtras aberta
                        this.Show();
                    }
                    else
                    {
                        // adiciona ao banco de dados 
                        AdicionaHorasBancoDados();


                        // fecha tela cadastrarHorasExtras
                        this.Close();
                    }
                }
            }
            else
            {
                // verifica se o campo cliente esta vazio
                if (string.IsNullOrEmpty(textBoxCliente.Text))
                {
                    // Se o campo cliente estiver vazio, mostra uma mensagem de erro e coloca o cursor no campo cliente
                    FormMessage msgErro = new FormMessage("Atenção", "O Campo Cliente é obrigatório",
                    SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.OK);

                    // mostra mensagem de erro 
                    msgErro.ShowDialog();

                    // coloca cursor no campo cliente
                    textBoxCliente.Focus();

                    // mantem a variavel preenchimento correto como false
                    preenchimentoCorreto = false;
                    return;
                }
                // verifica os dois grupos ao mesmo tempo
                else
                {
                    //valida o preenchimento do perido 1 
                    ValidaGrupoPeriodo(textHoraEntradaP1, textMinutoEntradaP1, textHoraSaidaP1, textMinutoSaidaP1, groupBoxPerido1);

                    //valida o preenchimento do perido 1 
                    ValidaGrupoPeriodo(textHoraEntradaP2, textMinutoEntradaP2, textHoraSaidaP2, textMinutoSaidaP2, groupBoxPerido2);

                    // verifica se o preenchimento esta correto
                    if (preenchimentoCorreto == false)
                    {
                        this.Show();
                    }
                    else
                    {
                        // adiciona horas no banco de dados
                        AdicionaHorasBancoDados();


                        // fecha tela CadastrarHorasExtras
                        this.Close();
                    }

                }
            }
        }


        private void MostraErroDataHora(TextBox[] textsBox, GroupBox periodo)
        {
            // percorre o array de textBox em pares
            for (int i = 0; i < textsBox.Length; i += 2)
            {
                if (!IsValidTime(textsBox[i].Text, textsBox[i + 1].Text))
                {
                    // mostra mensagem de hora inválida
                    FormMessage msgAtencao = new FormMessage("ATENÇÃO", "A hora da " + textsBox[i].Tag  + " do " + periodo.Tag + " são inválidas", SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.OK);
                    msgAtencao.ShowDialog();

                    // mantem o cursor no textBox fazio
                    textsBox[i].Focus();
                    return;
                }
            }
        }

        private bool IsValidTime(string hours, string minutes)
        {
            // Declara as variáveis para armazenar as horas e minutos como inteiros
            int intHours, intMinutes;

            // Tentar parsear os textos em hours e minutes para inteiros
            if (int.TryParse(hours, out intHours) && int.TryParse(minutes, out intMinutes))
            {
                // Verifica se as horas estão dentro do intervalo válido (0 a 23)
                // e se os minutos estão dentro do intervalo válido (0 a 59)
                if (intHours >= 0 && intHours <= 23 && intMinutes >= 0 && intMinutes <= 59)
                {
                    // Retorna verdadeiro se as horas e minutos são válidos
                    return true;
                }
            }

            // Retorna falso se as horas e minutos não são válidos
            return false;
        }


        // valido grupo horas extras
        private void ValidaGrupoPeriodo(TextBox horaEntrada, TextBox minutoEntrada, TextBox horaSaida, TextBox minutoSaida, GroupBox periodo)
        {
            string[] entradaHoras = new string[4];
            TextBox[] textBoxes = { horaEntrada, minutoEntrada, horaSaida, minutoSaida };
            string nomePeriodo = (string)periodo.Tag;
            TimeSpan lower = TimeSpan.Parse("00:00");
            TimeSpan upper1 = TimeSpan.Parse("11:59");
            TimeSpan upper2 = TimeSpan.Parse("23:59");


            // percorre o array de textBox
            for (int i = 0; i < textBoxes.Length; i++)
            {
                // verifica se contem algum textBox vazio
                if (string.IsNullOrEmpty(textBoxes[i].Text))
                {
                    // mostra mensagem textBox vazio
                    FormMessage msgAtencao = new FormMessage("ATENÇÃO", "A " + textBoxes[i].Tag + " do " + periodo.Tag + ".\nNão foi preenchido corretamente", SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.OK);
                    msgAtencao.ShowDialog();

                    // mantem o cursor no textBox fazio
                    textBoxes[i].Focus();

                    // preenchimento incorreto
                    preenchimentoCorreto = false;
                    return;
                }
                else
                {
                    // Se preenchido passa conteudo do textBox para array auxiliar
                    entradaHoras[i] = textBoxes[i].Text;
                }
            }

            // verifica se o length do array auxiliar e > 4
            if (entradaHoras.Length > 4)
            {
                // limpa o array evitando copias do mesmo texto
                Array.Clear(entradaHoras, 0, entradaHoras.Length);
                return;
            }

            // armazena o retorno do metodo ValidaHorasMinutos
            bool validadaHoras = ValidaHorasMinutos(entradaHoras);

            // verifica se o retorna da funcao nao e TimeSpanValido
            if (validadaHoras == false)
            {
                MostraErroDataHora(textBoxes, periodo);
                primeiroPeriodoOK = false;
                preenchimentoCorreto = false;
            }
            else
            {
                // verifica se e 1º periodo
                if (nomePeriodo == "1º Periodo")
                {
                    TimeSpan EntradaP1 = TimeSpan.Parse(EntradaHoras);
                    TimeSpan SaidaP1 = TimeSpan.Parse(SaidaHoras);

                    if (string.IsNullOrEmpty(textBoxCliente.Text))
                    {
                        clientePreenchido = false;
                    }

                    // verifica se esta no limete 00:00 a 11:59
                    if (EntradaP1 >= lower && EntradaP1 <= upper1 && SaidaP1 >= EntradaP1 && SaidaP1 <= upper1)
                    {
                        // Verifica se o cliente foi preenchido
                        if (clientePreenchido != false)
                        {
                            // Adiciona as informações do cliente e os horários de entrada e saída no primeiro período no objeto "tela_horas_extras.horas_extras"
                            tela_horas_extras.horas_extras.cliente = textBoxCliente.Text;
                            tela_horas_extras.horas_extras.p1_entrada = EntradaHoras;
                            tela_horas_extras.horas_extras.p1_saida = SaidaHoras;

                            // Adiciona as informações do cliente e os horários de entrada e saída no primeiro período no objeto "HorasExtrasDb"
                            HorasExtrasDb.p1_entrada = EntradaHoras;
                            HorasExtrasDb.p1_saida = SaidaHoras;
                            preenchimentoCorreto = true;

                            // marca como verdadeiro que o primeiro período está preenchido corretamente
                            primeiroPeriodoOK = true;
                        }
                    }
                    // Verifica se os horários de entrada e saída do primeiro período são "00:00"
                    else if (EntradaP1 == lower && SaidaP1 == lower)
                    {
                        // Adiciona as informações do cliente e os horários de entrada e saída no segundo período no objeto "tela_horas_extras.horas_extras"
                        tela_horas_extras.horas_extras.cliente = textBoxCliente.Text;
                        tela_horas_extras.horas_extras.p2_entrada = EntradaHoras;
                        tela_horas_extras.horas_extras.p2_saida = SaidaHoras;

                        // Adiciona as informações do cliente e os horários de entrada e saída no segundo período no objeto "HorasExtrasDb"
                        HorasExtrasDb.p2_entrada = EntradaHoras;
                        HorasExtrasDb.p2_saida = SaidaHoras;
                        preenchimentoCorreto = true;

                        // marca como verdadeiro que o primeiro período está preenchido corretamente
                        primeiroPeriodoOK = true;
                    }
                    else
                    {
                        // se nao estiver apresenta a mesagem de erro para usuario
                        FormMessage msgAtencao = new FormMessage("Atenção", "No 1º período é válido apenas horarios entre 00:00 e 11:59", SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.OK);
                        msgAtencao.ShowDialog();
                        preenchimentoCorreto = false;
                        primeiroPeriodoOK = false;
                        return;
                    }
                }
                else if (nomePeriodo == "2º Periodo") // verifica se e 2º periodo
                {
                    TimeSpan EntradaP2 = TimeSpan.Parse(EntradaHoras);
                    TimeSpan SaidaP2 = TimeSpan.Parse(SaidaHoras);

                    // verifica se o campo cliente esta preenchido
                    if (string.IsNullOrEmpty(textBoxCliente.Text))
                    {
                        clientePreenchido = false;
                    }

                    // Verifica se o preenchimento do formulário está correto
                    if (primeiroPeriodoOK == false)
                    {
                        preenchimentoCorreto = false;
                    }
                    else
                    {
                        preenchimentoCorreto = true;
                    }

                    // verifica se esta no lime 12:00 a 23:59
                    if (EntradaP2 > upper1 && EntradaP2 <= upper2 && SaidaP2 >= EntradaP2 && SaidaP2 <= upper2)
                    {
                        // Adiciona o cliente preenchido e as horas do período 2 ao listView
                        if (clientePreenchido != false)
                        {
                            // Adiciona as informações do cliente e os horários de entrada e saída no segundo período no objeto "tela_horas_extras.horas_extras"
                            tela_horas_extras.horas_extras.cliente = textBoxCliente.Text;
                            tela_horas_extras.horas_extras.p2_entrada = EntradaHoras;
                            tela_horas_extras.horas_extras.p2_saida = SaidaHoras;
                            HorasExtrasDb.p2_entrada = EntradaHoras;
                            HorasExtrasDb.p2_saida = SaidaHoras;
                            preenchimentoCorreto = true;

                            // Verifica se o preenchimento do formulário está correto
                            if (primeiroPeriodoOK == false)
                            {
                                preenchimentoCorreto = false;
                            }
                            else
                            {
                                preenchimentoCorreto = true;
                            }
                        }
                    }
                    // verifica se os campos estao preenchidos com "00:00"
                    else if (EntradaP2 == lower && SaidaP2 == lower)
                    {
                        // Adiciona as informações do cliente e os horários de entrada e saída no segundo período no objeto "tela_horas_extras.horas_extras"
                        tela_horas_extras.horas_extras.cliente = textBoxCliente.Text;
                        tela_horas_extras.horas_extras.p2_entrada = EntradaHoras;
                        tela_horas_extras.horas_extras.p2_saida = SaidaHoras;
                        HorasExtrasDb.p2_entrada = EntradaHoras;
                        HorasExtrasDb.p2_saida = SaidaHoras;
                        preenchimentoCorreto = true;

                        // Verifica se o preenchimento do formulário está correto
                        if (primeiroPeriodoOK == false)
                        {
                            preenchimentoCorreto = false;
                        }
                        else
                        {
                            preenchimentoCorreto = true;
                        }
                    }
                    else
                    {
                        // se nao estiver apresenta a mesagem de erro para usuario
                        FormMessage msgAtencao = new FormMessage("Atenção", "No 2º período é válido apenas horarios entre 12:00 e 23:59", SmartHorasExtras.Properties.Resources.atencao, MessageBoxButtons.OK);
                        msgAtencao.ShowDialog();
                        preenchimentoCorreto = false;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Metodo recebe como parametro um array do tipo String, converte o array em duas strings 
        /// passando como retorno um valor booleano verdadeiro ou falso derivado do retorno metodo CheckTimeRange
        /// </summary>
        // Valida se as horas e minutos estão no formato correto
        private bool ValidaHorasMinutos(string[] array)
        {
            try
            {
                // Junta os elementos do array em uma string separada por vírgulas
                string timeStringEntrada = String.Join(", ", array);
                // Remove as vírgulas da string
                string result = timeStringEntrada.Replace(",", "");
                // Extrai as horas e minutos da entrada
                string hour1 = result.Substring(0, 2);
                string minute1 = result.Substring(3, 2);
                // Extrai as horas e minutos da saída
                string hour2 = result.Substring(6, 2);
                string minute2 = result.Substring(9, 2);
                // Armazena as horas e minutos de entrada e saída em formato de string
                EntradaHoras = hour1 + ":" + minute1;
                SaidaHoras = hour2 + ":" + minute2;

                // Verifica se as horas estão dentro do intervalo permitido (00:00 até 23:59)
                return CheckTimeRange(EntradaHoras, SaidaHoras);
            }
            catch (Exception)
            {
                // Retorna false em caso de erro
                return false;
            }
        }


        /// <summary>
        /// Verifica se os valores passados como parametro estao vazios,
        /// verifica se os valores passados podem ser comparados com timeSpan validos
        /// </summary>
        private bool CheckTimeRange(string input1, string input2)
        {
            TimeSpan timer1;
            TimeSpan timer2;

            // verifica se as strings estam vazias
            if (string.IsNullOrEmpty(input1) || string.IsNullOrEmpty(input2))
            {
                return false;
            }
            if (!TimeSpan.TryParse(input1, out timer1))
            {
                return false;
            }
            if (!TimeSpan.TryParse(input2, out timer2))
            {
                return false;
            }
            TimeSpan lower = TimeSpan.Parse("00:00");
            TimeSpan upper1 = TimeSpan.Parse("11:59");
            TimeSpan upper2 = TimeSpan.Parse("23:59");
            return (timer1 >= lower && timer1 <= upper1 && timer2 >= lower && timer2 <= upper1) ||
                   (timer1 >= lower && timer1 <= upper2 && timer2 >= lower && timer2 <= upper2);
        }

        /// <summary>
        /// Recebe a string vinda da classe horas extras 
        /// divindo a string em duas partes hora "00" e minuto "00"
        /// armazena as duas string em dois textBox Hora e textBox minuto
        /// </summary>
        private void ReparteHoraExtra(string horaExtra, TextBox hora, TextBox minuto)
        {
            if (!string.IsNullOrEmpty(horaExtra))
            {
                string part1 = horaExtra.Substring(0, 2);
                string part2 = horaExtra.Substring(3, 2);

                hora.Text = part1;
                minuto.Text = part2;
            }
        }

        // metodo que preenche os campos dia ano e mes recebido pelo listView
        private void PreencheCamposTextBox()
        {
            textBoxDiaEntraP1.Text = tela_horas_extras.horas_extras.dia;
            textBoxDiaSaidaP1.Text = tela_horas_extras.horas_extras.dia;
            textBoxDiaSaidaP2.Text = tela_horas_extras.horas_extras.dia;
            textBoxDiaEntraP2.Text = tela_horas_extras.horas_extras.dia;
            textBoxMesEntraP1.Text = tela_horas_extras.horas_extras.mes.PadLeft(2, '0');
            textBoxAnoEntraP1.Text = tela_horas_extras.horas_extras.ano;
            textBoxMesEntraP2.Text = tela_horas_extras.horas_extras.mes.PadLeft(2, '0');
            textBoxAnoEntraP2.Text = tela_horas_extras.horas_extras.ano;
            textBoxMesSaidaP1.Text = tela_horas_extras.horas_extras.mes.PadLeft(2, '0');
            textBoxAnoSaidaP1.Text = tela_horas_extras.horas_extras.ano;
            textBoxMesSaidaP2.Text = tela_horas_extras.horas_extras.mes.PadLeft(2, '0');
            textBoxAnoSaidaP2.Text = tela_horas_extras.horas_extras.ano;
        }

        // Adiciona ou atualiza as horas no banco de dados
        private void AdicionaHorasBancoDados()
        {
            // Verifica se o botão "Editar" foi clicado
            if (botaoEditarClick == true)
            {
                // Atribui o cliente ao objeto HorasExtrasDb
                HorasExtrasDb.cliente = textBoxCliente.Text;

                // Verifica se o usuário é um Admin
                if (tela_colaboradores != null)
                {
                    HorasExtrasDb.colaborador_id = tela_colaboradores.IDColab;
                }
                // Verifica se o usuário é um colaborador
                if (tela_principal.IDColaborador > 0)
                {
                    HorasExtrasDb.colaborador_id = tela_principal.IDColaborador;
                }

                // Converte a data em formato string para o tipo DateTime
                string data2 = string.Format("{0}/{1}/{2} 00:00:00", textBoxAnoEntraP2.Text, textBoxMesEntraP2.Text, textBoxDiaEntraP2.Text);
                HorasExtrasDb.data = Convert.ToDateTime(data2);

                // Atualiza as horas extras no banco de dados
                HorasExtrasMetodos.AtualizarHorasExtras(HorasExtrasDb);

                // Define botaoEditarClick como false
                botaoEditarClick = false;

                // Fecha a janela atual
                this.Close();
            }

            // Verifica se o botão "Adicionar" foi clicado
            if (botaoAddicionarClick == true || addclickDuplo == true)
            {
                // Atribui o cliente ao objeto HorasExtrasDb
                HorasExtrasDb.cliente = textBoxCliente.Text;

                // Verifica se o usuário é um Admin
                if (tela_colaboradores != null)
                {
                    HorasExtrasDb.colaborador_id = tela_colaboradores.IDColab;
                }

                // Verifica se o usuário é um colaborador
                if (tela_principal.IDColaborador > 0)
                {
                    HorasExtrasDb.colaborador_id = tela_principal.IDColaborador;
                }

                // Converte a data em formato string para o tipo DateTime
                string data2 = string.Format("{0}/{1}/{2} 00:00:00", textBoxAnoEntraP2.Text, textBoxMesEntraP2.Text, textBoxDiaEntraP2.Text);
                HorasExtrasDb.data = Convert.ToDateTime(data2);

                // Adiciona as horas extras no banco de dados
                HorasExtrasMetodos.AddHorasExtras(HorasExtrasDb);


                botaoAddicionarClick = false;

                this.Close();
            }
        }


    }
}
