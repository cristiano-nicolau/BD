using System;
using System.Data;
using System.Data.SqlClient;

namespace Proj_BD
{
    public class DataRepository
    {
        private SqlConnection connection;

        public DataRepository()
        {
            connection = getConnection();
        }

        private SqlConnection getConnection()
        {
            return new SqlConnection("Data Source=tcp:mednat.ieeta.pt\\SQLSERVER,8101;Initial Catalog=SQL Server Autentication;User ID=p5g2;Password=Santamartacity1");
        }

        private bool verifyConnection()
        {
            if (connection == null)
                connection = getConnection();

            if (connection.State != ConnectionState.Open)
                connection.Open();

            return (connection.State == ConnectionState.Open);
        }

        public bool InserirUtilizador(string nomeUtilizador, string idUtilizador, string email, string senha, string nomeApelido, string nascimento, string likes)
        {
            try
            {
                if (!verifyConnection())
                    return false;

                string query = "INSERT INTO Utilizadores (NomeUtilizador, IdUtilizador, Email, Senha, NomeApelido, Nascimento, Likes) " +
                               "VALUES (@NomeUtilizador, @IdUtilizador, @Email, @Senha, @NomeApelido, @Nascimento, @Likes)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomeUtilizador", nomeUtilizador);
                    command.Parameters.AddWithValue("@IdUtilizador", idUtilizador);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Senha", senha);
                    command.Parameters.AddWithValue("@NomeApelido", nomeApelido);
                    command.Parameters.AddWithValue("@Nascimento", nascimento);
                    command.Parameters.AddWithValue("@Likes", likes);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir utilizador: " + ex.Message);
                return false;
            }
        }

        public DataTable ListarUtilizadores()
        {
            try
            {
                if (!verifyConnection())
                {
                    Console.WriteLine("No Connection!");
                    return null;
                }

                string query = "SELECT * FROM Utilizadores";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao obter utilizadores: " + ex.Message);
                return null;
            }
        }

        public void FecharConexao()
        {
            connection.Close();
        }
    }
}
