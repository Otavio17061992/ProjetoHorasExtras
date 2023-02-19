using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SmartHorasExtras_DB.Metodos
{
    public class BancoDadosMetodos
    {
        public static SQLiteConnection sqlConnetion { get; set; }

        public static string conexao;

        public static SQLiteConnection DbConnection()
        {
            // usa a conexao
            sqlConnetion = new SQLiteConnection("Data Source="+conexao+"SmartHorasExtras.db; Version=3;");
            sqlConnetion.Open();
            return sqlConnetion;
        }

        public static void CriaBancoSQLite(string caminho)
        {
            try
            {
                // complementa o caminho para leitura
                @caminho += "SmartHorasExtras.db";

                // verfica se banco de dados esta criado
                if (!File.Exists(@caminho))
                {
                    string primeirLetracaminho = caminho.Substring(0, 1);

                    if(primeirLetracaminho == "@")
                    {
                        caminho = caminho.Remove(0, 1);
                    }

                    SQLiteConnection.CreateFile(caminho);
                    File.SetAttributes(caminho, FileAttributes.Normal);
                    File.SetAccessControl(caminho, new FileSecurity(caminho, AccessControlSections.Access));
                }
            }
            catch (Exception ex)
            {
                // - Mostrando uma mensagem de erro ao usuário
                // - Registrando a exceção em um arquivo de log
                throw new Exception("Erro ao criar o banco de dados: " + ex.Message);
            }
        }
    }
}
