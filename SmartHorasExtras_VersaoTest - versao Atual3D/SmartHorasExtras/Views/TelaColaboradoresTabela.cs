using SmartHorasExtras_DB.Dominios;
using SmartHorasExtras_DB.Metodos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace SmartHorasExtras.Views
{
    public partial class TelaColaboradoresTabela : Form
    {
        public TelaColaboradoresTabela()
        {
            InitializeComponent();

            CopiaDataTableParaListView(ColaboradoresMetodos.GetColaboradores(),listViewColaboradores);
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

        private void listViewColaboradores_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
