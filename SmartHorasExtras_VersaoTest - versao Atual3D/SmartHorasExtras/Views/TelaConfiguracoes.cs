using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartHorasExtras.Controllers;
using SmartHorasExtras.Controllers.FormMessageBox;
using SmartHorasExtras.Controllers.IniFiles;

namespace SmartHorasExtras.Views
{
    public partial class TelaConfiguracoes : Form
    {
        TelaPrincipal tela_prinpical = Application.OpenForms.OfType<TelaPrincipal>().FirstOrDefault();
        string caminho_completo;
        string diretorio;

        public TelaConfiguracoes()
        {
            InitializeComponent();

            textBoxCaminho.Text = @tela_prinpical.caminhoDB;

            //textBoxCaminho.Text = textBoxCaminho.Text.Remove(0, 1);

            diretorio = textBoxCaminho.Text;

        }

        /// <summary>
        /// salva o novo caminho para o arquivo do banco de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string caminho = SetaCaminho(textBoxCaminho.Text);

            INiFilesPadrao IniFiles = new INiFilesPadrao(@caminho + "Caminho.ini");

            // seta o novo caminho
            IniFiles.Write("Caminho", textBoxCaminho.Text, "BancoDados");

            IniFiles = new INiFilesPadrao(@caminho + "Caminho.ini", true);

            string retorn = IniFiles.GetSetting("BancoDados", "Caminho");

            tela_prinpical.caminhoDB = textBoxCaminho.Text;

            // verifica se arquivo foi salvo
            if (retorn == textBoxCaminho.Text.ToUpper())
            {
                // apresenta mensagem de sucesso
                FormMessage msgCustom = new FormMessage("Sucesso", "O caminho foi salvo.", SmartHorasExtras.Properties.Resources.sucesso1, MessageBoxButtons.OK);
                msgCustom.ShowDialog();
            }
            else
            {
                // apresenta mensagem de erro
                FormMessage msgCustom = new FormMessage("Atenção", "Houve um erro ao salvar o caminho.", SmartHorasExtras.Properties.Resources.erro1, MessageBoxButtons.OK);
                msgCustom.ShowDialog();
            }

        }

        private string SetaCaminho(string caminho)
        {
            // Edita retorno do caminho passado pela class Files
            char PrimeiraLetra = caminho[0].ToString().ToUpper()[0];
            char QuartaLetra = caminho[3].ToString().ToUpper()[0];
            string caminhoDBfiltrado = PrimeiraLetra + caminho.Substring(1, 2) + QuartaLetra + caminho.Substring(3);
            caminhoDBfiltrado = caminhoDBfiltrado.Remove(4, 1);


            return caminhoDBfiltrado;
        }


        private void btnCaminho_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            // define as propriedades do controle OpenFileDialog
            ofd.Multiselect = false;
            ofd.Title = "Selecionar o caminho do Banco de Dados";
            ofd.InitialDirectory = diretorio;

            // filtra para exibir somente arquivos do banco de dados SQLite           
            ofd.Filter = "Banco Dados SQLite (*.DB;*.db)|*.DB;*.db";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            ofd.ReadOnlyChecked = true;
            ofd.ShowReadOnly = true;

            DialogResult result = ofd.ShowDialog();

            // verifica se arquivo foi selecionado
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                // pega o caminho completo do arquivo OTA
                textBoxCaminho.Text = ofd.FileName.Replace(ofd.SafeFileName, "");

                // pega o novo caminho completo
                caminho_completo = ofd.FileName;
            }
        }
    }
}
