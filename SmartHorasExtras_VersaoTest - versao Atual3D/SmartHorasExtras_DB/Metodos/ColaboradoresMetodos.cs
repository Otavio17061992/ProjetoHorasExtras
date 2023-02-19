using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using SmartHorasExtras_DB.Dominios;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace SmartHorasExtras_DB.Metodos
{
    public class ColaboradoresMetodos
    {
        private string _path;
        string conexao = "Data Source=C:\\ControleHorasExtras\\SmartHorasExtras.db";

        public ColaboradoresMetodos(string path)
        {
            _path = path;
        }


        public static void CriarTabelaColaboradores()
        {
            using (var con = new SQLiteConnection("Data Source=C:\\ControleHorasExtras\\SmartHorasExtras.db;Version=3;"))
            {
                using (SQLiteCommand command = con.CreateCommand())
                {
                    con.Open();
                    // Verifica se a tabela já existe antes de tentar criá-la
                    command.CommandText = "SELECT name FROM sqlite_master WHERE name='Colaboradores'";

                    var tableExistsQuery = command.ExecuteScalar();

                    if (tableExistsQuery == null)
                    {
                        command.CommandText = "CREATE TABLE Colaboradores (ID INTEGER PRIMARY KEY AUTOINCREMENT, Nome VARCHAR(30), Departamento VARCHAR(30), TipoColaborador INT, Senha VARCHAR(8))";
                        command.ExecuteNonQuery();
                    }

                    con.Close();
                }
            }
        }


        public static DataTable GetColaboradores()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = BancoDadosMetodos.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Colaboradores";
                    da = new SQLiteDataAdapter(cmd.CommandText, BancoDadosMetodos.DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // retorna todos os registros do colaborador em tabela
        public static DataTable GetColaborador(int Id)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();

            try
            {
                using (var cmd = BancoDadosMetodos.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Colaboradores Where Id=" + Id;
                    dataAdapter = new SQLiteDataAdapter(cmd.CommandText, BancoDadosMetodos.DbConnection());
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        // adiciona o colaborador DB e retorna seu ID
        public static int AddColaborador(ColaboradoresDominios colaborador)
        {
            try
            {
                using (var cmd = BancoDadosMetodos.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Colaboradores (nome, departamento, TipoColaborador, Senha) values (@nome, @departamento, @TipoColaborador, @Senha); SELECT last_insert_rowid();";
                    cmd.Parameters.AddWithValue("@Nome", colaborador.Nome);
                    cmd.Parameters.AddWithValue("@Departamento", colaborador.Departamento);
                    cmd.Parameters.AddWithValue("@TipoColaborador", colaborador.TipoUsuario);
                    cmd.Parameters.AddWithValue("@Senha", colaborador.Senha);
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    return id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // seleciona colaborador pelo nome 
        public static ColaboradoresDominios GetColaboradorPeloNome(string name)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\ControleHorasExtras\\SmartHorasExtras.db"))
            {
                conn.Open();

                string query = "SELECT * FROM Colaboradores WHERE Nome = @name";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nome = reader.GetString(1);
                            string departamento = reader.GetString(2);
                            int tipoUsuario = reader.GetInt32(3);
                            string senha = reader.GetString(4);

                            return new ColaboradoresDominios(id, nome, departamento, tipoUsuario, senha);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static string GetUsuarioPeloNomeRetornaDepartamento(string name)
        {
            string departamento = "";

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\ControleHorasExtras\\SmartHorasExtras.db"))
            {
                conn.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT Departamento FROM Colaboradores WHERE Nome = @name", conn))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            departamento = reader["Departamento"].ToString();
                        }
                    }
                }
            }
            return departamento;
        }

        public static int GetUsuarioPeloNome(string name)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\ControleHorasExtras\\SmartHorasExtras.db"))
            {
                conn.Open();

                string query = "SELECT id FROM Colaboradores WHERE Nome = @name";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            return id;
                        }
                        else
                        {
                            return -1; // return -1 or any other value to indicate that the user was not found
                        }
                    }
                }
            }
        }


        public static void AtualizaColaborador(ColaboradoresDominios colaborador)
        {
            try
            {
                using (var cmd = BancoDadosMetodos.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "UPDATE Colaboradores SET Nome=@nome, Departamento=@departamentp WHERE ID=@ID";
                    cmd.Parameters.AddWithValue("@Id", colaborador.Id);
                    cmd.Parameters.AddWithValue("@Nome", colaborador.Nome);
                    cmd.Parameters.AddWithValue("@Departamento", colaborador.Departamento);
                    cmd.ExecuteNonQuery();
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void ExcluirColaborador(int Id)
        {
            try
            {
                using (var cmd = BancoDadosMetodos.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Colaboradores Where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static int GetColaboradorTipo(string name)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\ControleHorasExtras\\SmartHorasExtras.db"))
            {
                connection.Open();
                using (SQLiteCommand command = BancoDadosMetodos.DbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT TipoColaborador FROM Colaboradores WHERE Nome = @Nome";
                    command.Parameters.AddWithValue("@Nome", name);
                    var result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        // valida senha do colaborador
        public static ColaboradoresDominios ValidaColaborador(string nome, string senha)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\ControleHorasExtras\\SmartHorasExtras.db"))
            {
                connection.Open();

                using (SQLiteCommand command = BancoDadosMetodos.DbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT TipoColaborador FROM Colaboradores WHERE Nome = @Nome AND Senha = @Senha";
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Senha", senha);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Login e senha válidos
                            int type = reader.GetInt32(0);
                            return new ColaboradoresDominios { TipoUsuario = type, EhValido = true };
                        }
                        else
                        {
                            // Login ou senha inválidos
                            return new ColaboradoresDominios { TipoUsuario = 0, EhValido = false };
                        }
                    }
                }
            }
        }

        public static ColaboradoresDominios GetColaboradorPeloNome(string name,bool colabe)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=C:\\ControleHorasExtras\\SmartHorasExtras.db"))
            {
                conn.Open();

                string query = "SELECT * FROM Colaboradores WHERE Nome = @Nome";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", name);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            string NomeUsuario = reader.GetString(1);
                            string Departamento = reader.GetString(2);
                            int tipoColaborador = reader.GetInt32(3);
                            string Senha = reader.GetString(4);
                            return new ColaboradoresDominios(ID,NomeUsuario,Departamento,tipoColaborador,Senha);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        // altera senha do usuario
        public static void UpdateSenhaColaborador(ColaboradoresDominios Colaborador, string senha)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=C:\\ControleHorasExtras\\SmartHorasExtras.db"))
                {
                    using (SQLiteCommand command = BancoDadosMetodos.DbConnection().CreateCommand())
                    {
                        command.CommandText = "UPDATE Colaboradores SET Senha=@Senha WHERE Nome=@Nome";
                        command.Parameters.AddWithValue("@Nome", Colaborador.Nome);
                        command.Parameters.AddWithValue("@Senha", senha);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
