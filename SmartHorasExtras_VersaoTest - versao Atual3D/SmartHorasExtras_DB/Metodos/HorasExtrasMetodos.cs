using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHorasExtras_DB.Dominios;
using System.Data.SQLite;
using System.Data;

namespace SmartHorasExtras_DB.Metodos
{
    public class HorasExtrasMetodos
    {
        public static void CriarTabelaHorasExtras()
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=C:\\ControleHorasExtras\\SmartHorasExtras.db;Version=3;"))
            {
                using (SQLiteCommand command = con.CreateCommand())
                {
                    con.Open();
                    command.CommandText = "SELECT name FROM sqlite_master WHERE name='HistoricoHorasExtras'";
                    // Verifica se a tabela já existe antes de tentar criá-la
                    var tableExistsQuery = command.ExecuteScalar();


                    if (tableExistsQuery == null)
                    {
                        command.CommandText = "CREATE TABLE HistoricoHorasExtras (ID INTEGER PRIMARY KEY AUTOINCREMENT, IDColaborador INTEGER, Cliente VARCHAR(30), DataRegistro DATETIME, Entrada_1 DATETIME, Saida_1 DATETIME,  Entrada_2 DATETIME,  Saida_2 DATETIME,  FOREIGN KEY(IDColaborador) REFERENCES Colaboradores(ID))";
                        command.ExecuteNonQuery();
                    }

                    con.Close();
                }

            }
        }


        public static void AddHorasExtras(HorasExtrasDominios horasExtras)
        {
            try
            {
                // código para adicionar horas extras ao banco de dados
                using (SQLiteConnection connection = new SQLiteConnection())
                {
                    using (var command = BancoDadosMetodos.DbConnection().CreateCommand())
                    {
                        command.CommandText = "INSERT INTO HistoricoHorasExtras(IdColaborador, Cliente, DataRegistro, Entrada_1, Saida_1, Entrada_2, Saida_2 ) VALUES (@IdColaborador, @Cliente, @DataRegistro, @Entrada_1, @Saida_1, @Entrada_2, @Saida_2)";
                        command.Prepare();

                        command.Parameters.AddWithValue("@IdColaborador", horasExtras.colaborador_id);
                        command.Parameters.AddWithValue("@Cliente", horasExtras.cliente);
                        command.Parameters.AddWithValue("@DataRegistro", horasExtras.data);
                        command.Parameters.AddWithValue("@Entrada_1", horasExtras.p1_entrada);
                        command.Parameters.AddWithValue("@Saida_1", horasExtras.p1_saida);
                        command.Parameters.AddWithValue("@Entrada_2", horasExtras.p2_entrada);
                        command.Parameters.AddWithValue("@Saida_2", horasExtras.p2_saida);


                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Erro ao Adicionar horas extras: " + ex.Message);
            }
        }


        public static DataTable GetHorasExtras(HorasExtrasDominios horasExtras)
        {
            DataTable tabela = new DataTable();
            try
            {
                using (var cmd = BancoDadosMetodos.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT  DataRegistro, Cliente, Entrada_1, Saida_1, Entrada_2, Saida_2 FROM HistoricoHorasExtras WHERE IDColaborador=@IDColaborador";
                    cmd.Parameters.AddWithValue("@IDColaborador", horasExtras.colaborador_id);

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    adapter.Fill(tabela);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tabela;
        }


        public static void AtualizarHorasExtras(HorasExtrasDominios horasExtras)
        {
            // código para atualizar horas extras no banco de dados
            try
            {
                using (var command = BancoDadosMetodos.DbConnection().CreateCommand())
                {
                    command.CommandText = "UPDATE HistoricoHorasExtras SET cliente=@Cliente, entrada_1=@Entrada_1, saida_1=@Saida_1, entrada_2=@Entrada_2, saida_2=@Saida_2 WHERE DataRegistro=@DataRegistro";

                    command.Parameters.AddWithValue("@Cliente", horasExtras.cliente);
                    command.Parameters.AddWithValue("@Entrada_1", horasExtras.p1_entrada);
                    command.Parameters.AddWithValue("@Saida_1", horasExtras.p1_saida);
                    command.Parameters.AddWithValue("@Entrada_2", horasExtras.p2_entrada);
                    command.Parameters.AddWithValue("@Saida_2", horasExtras.p2_saida);
                    command.Parameters.AddWithValue("@DataRegistro", horasExtras.data);

                    command.ExecuteNonQuery();
                };
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Erro ao Atualizar horas extras: " + ex.Message + " StackTrace: " + ex.StackTrace);
            }

        }

        public static DataTable BuscarTodosHorasExtras(int Id)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();

            try
            {
                using (var cmd = BancoDadosMetodos.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM HistoricoHorasExtras Where Id=@Id";
                    dataAdapter = new SQLiteDataAdapter(cmd.CommandText, BancoDadosMetodos.DbConnection());
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (SQLiteException ex)
            {

                return null;
            }
        }

        public static void ExcluirHorasExtras(HorasExtrasDominios horasExtras)
        {
            try
            {
                using (var cmd = BancoDadosMetodos.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM HistoricoHorasExtras Where DataRegistro=@DataRegistro";
                    cmd.Parameters.AddWithValue("@DataRegistro", horasExtras.data);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //Tratamento de exceção
                throw ex;
            }
        }
    }
}
