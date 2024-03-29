using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            return new SqlConnection("data Source= tcp:mednat.ieeta.pt\\SQLSERVER,8101;initial Catalog = p5g2;uid = p5g2;password = Santamartacity1");
        }

        private bool verifyConnection()
        {
            if (connection == null) 
                connection = getConnection();

            if (connection.State != ConnectionState.Open)
                connection.Open();
    

            return (connection.State == ConnectionState.Open);
        }



        /// /////////////////////////////////////// ////////////////////////////////////////
        /// 
        /// 

        public bool DeletePlaylist(int playlistID)
        {
            try
            {
                if (!verifyConnection())
                {
                    return false;
                }
                try {

                    using (SqlCommand command = new SqlCommand("Youtube.DeletePlaylist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PlaylistID", playlistID);

                        command.ExecuteNonQuery();
                    }

                    return true;
                }catch (Exception ex)
                {
                    MessageBox.Show("Error deleting playlist: " + ex.Message);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting playlist: " + ex.Message);
                return false;
            }
        }
        public bool LikeVideo(string codigo)
        {
            try
            {
                    if (!verifyConnection())
                        return false;

                    string updateQuery = "UPDATE [Youtube].[Conteúdo] SET Num_Likes = Num_Likes + 1 WHERE Codigo = @Codigo";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Codigo", codigo);
                        command.ExecuteNonQuery();

                   
                    }
                    return true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao dar like no video: " + ex.Message);
                return false;
            }
        }

        public bool viewContent(int id)
        {
            try
            {
                    if (!verifyConnection())
                        return false;

                    string updateQuery = "UPDATE [Youtube].[Conteúdo] SET Num_Views = Num_Views+1 WHERE Codigo = @Codigo";
                    string insertQuery = "INSERT INTO [Youtube].[Historico] (Titulo, Codigo, Data_de_Visualizacao) " +
                                         "SELECT Titulo, Codigo, GETDATE() FROM [Youtube].[Conteúdo] WHERE Codigo = @Codigo";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Codigo", id);
                        command.ExecuteNonQuery();

                    
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@Codigo", id);
                        insertCommand.ExecuteNonQuery();
                    }
                    return true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ver Conteúdo: " + ex.Message);
                return false;
            }
        }
        public bool unSubscreverVideo(string subs)
        {
            try
            {
                if (!verifyConnection())
                    return false;

                using (SqlCommand command = new SqlCommand("Youtube.UpdateSubscribers2", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CanalName", subs);

                    command.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar as credenciais: " + ex.Message);
                return false;
            }
        }
        public bool SubscreverVideo(string subs)
        {
            try
            {
                if (!verifyConnection())
                    return false;

                using (SqlCommand command = new SqlCommand("Youtube.UpdateSubscribers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CanalName", subs);

                    command.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao subscrever o canal: " + ex.Message);
                return false;
            }
        }
        public bool IniciarSessaoUser(string nomeUtilizador, string senha)
        {
            try
            {
                if (!verifyConnection())
                    return false;

                string query = "SELECT [Youtube].[CheckCredentials](@NomeUtilizador, @Senha)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomeUtilizador", nomeUtilizador);
                    command.Parameters.AddWithValue("@Senha", senha);

                    bool exists = (bool)command.ExecuteScalar();

                    return exists;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar as credenciais: " + ex.Message);
                return false;
            }
        }
        public DataTable ProcurarUser()
         {
   
            try
            {
                if (!verifyConnection())
                {
                    Console.WriteLine("No Connection!");
                    return null;
                }

                string query = "SELECT u.Nome_Utilizador, u.Senha, c.Num_Subscritores, c.Num_Conteudo, c.Descrição_Canal " +
                "FROM [p5g2].[Youtube].[Utilizador] u " +
                "INNER JOIN [p5g2].[Youtube].[Canal] c ON u.Nome_Utilizador = c.Nome_Utilizador " +
                "WHERE u.Nome_Utilizador = c.Nome_Utilizador";

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

        // Utilzadores
        public bool InserirUtilizador(string nomeUtilizador, string email, string senha, string nomeApelido, DateTime nascimento)
        {
            try
            {
                if (!verifyConnection())
                    return false;

                string query = "[Youtube].[CreateUtilizadorAndCanal]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nome_Utilizador", nomeUtilizador);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Senha", senha);
                    command.Parameters.AddWithValue("@Nome", nomeApelido);
                    command.Parameters.AddWithValue("@Nascimento", nascimento);

                    command.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir utilizador: " + ex.Message);
                return false;
            }
        }


        public  bool  SubmeterPremium(String nomeUtilizador, String meses)
        {
            int nmeses = int.Parse(meses);

            try
            {
                if (!verifyConnection())
                    return false;

                string query = "INSERT INTO Youtube.Premium (Nome_Utilizador, Num_Meses) " +
                               "VALUES (@Nome_Utilizador,@meses)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Nome_Utilizador", nomeUtilizador);
                    command.Parameters.AddWithValue("@meses", nmeses);


                    command.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir Premium: " + ex.Message);
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

                string query = "SELECT U.Nome_Utilizador, U.Email, U.Nome, U.Data_de_Nascimento, CASE WHEN P.IsPremium = 1 THEN 'Premium' ELSE '' END AS Premium, P.Data_de_Encerramento, P.Valor_a_pagar FROM[p5g2].[Youtube].[Utilizador] U LEFT JOIN[p5g2].[Youtube].[Premium] P ON U.Nome_Utilizador = P.Nome_Utilizador;";
               
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


        // Conteudo
        public bool InserirConteudo(string tipoConteudo, string EstadoConteudo, TimeSpan duracao, string AutorConteudo, string TituloConteudo)
        {
            try
            {
                if (!verifyConnection())
                    return false;

                string query = "INSERT INTO [p5g2].[Youtube].[Conteúdo] (Titulo, Autor, Tipo, Estado, Duracao) VALUES(@Titulo, @autor, @Tipo, @estado, @dura);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titulo", TituloConteudo);
                    command.Parameters.AddWithValue("@autor", AutorConteudo);
                    command.Parameters.AddWithValue("@Tipo", tipoConteudo);
                    command.Parameters.AddWithValue("@estado", EstadoConteudo);
                    command.Parameters.AddWithValue("@dura", duracao);


                    int rowsAffected = command.ExecuteNonQuery();
                    
                    // apagar a proxima linha de codigo esta ca so para testes
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir utilizador: " + ex.Message);
                return false;
            }
        }
        public DataTable ListarConteudo() 
        {
            try
            {
                if (!verifyConnection())
                {
                    Console.WriteLine("No Connection!");
                    return null;
                }

                string query = "SELECT C.Codigo, C.Titulo, C.Autor, C.Tipo, E.state_name AS Estado, C.Duracao, C.Num_Likes, C.Num_Views, C.Data_Pub FROM Youtube.Conteúdo C JOIN Youtube.Estados E ON C.Estado = E.state_id";
            

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
                MessageBox.Show("Erro ao obter Comentarios: " + ex.Message);
                return null;
            }
        }

        // Comentario
        public bool InserirComentario(string Autor, string Texto, int CódigoV)
        {
            //apos o user clicar no mentario em vez de dar clear a tudo como fazia antes mostrar o comentario ou seja dar clear dos buttons e das labels e dar print com o codigo do conteudo, nome do conteudo, user que comentou, comentario e data 
            try
            {
                if (!verifyConnection())
                    return false;

                string query = "INSERT INTO Youtube.Comentários (Autor,Texto,Codigo) " +
                               "VALUES (@Autor, @Texto, @CódigoV)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Autor", Autor);
                    command.Parameters.AddWithValue("@Texto", Texto);
                    command.Parameters.AddWithValue("@CódigoV", CódigoV);

                    // apagar a proxima linha de codigo esta ca so para testes
                    int rowsAffected = command.ExecuteNonQuery();

                    // apagar a proxima linha de codigo esta ca so para testes
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir Comentário : " + ex.Message);
                return false;
            }


        }
        public DataTable ListarComentario()
        {
            try
            {
                if (!verifyConnection())
                {
                    return null;
                }

                string query = "SELECT * FROM [p5g2].[Youtube].[Comentários]";

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

        public DataTable ListarUmComentario(int idConteudo)
        {
            try
            {
                if (!verifyConnection())
                {
                    Console.WriteLine("No Connection!");
                    return null;
                }

                string query = @"SELECT c.Titulo AS NomeConteudo,
                u.Nome_Utilizador AS NomeUtilizador, 
                com.Autor, com.Texto AS Comentario, com.Data_Comentário
                FROM Youtube.Conteúdo c
                INNER JOIN Youtube.Canal cn ON c.Autor = cn.Nome_Utilizador
                INNER JOIN Youtube.Comentários com ON com.Codigo = c.Codigo
                INNER JOIN Youtube.Utilizador u ON u.Nome_Utilizador = com.Autor
                WHERE c.Codigo = @idConteudo;";



                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idConteudo", idConteudo);

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
                Console.WriteLine("Erro ao obter Comentários do conteúdo: " + ex.Message);
                return null;
            }
        }


        // PlayList

        public bool AddContentToPlaylist(int VideoID, int PlaylistID)
        {
            try
            {
                if (!verifyConnection())
                    return false;

                string query = "Youtube.AdicionarContentNaPlaylist";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@VideoID", VideoID);
                    command.Parameters.AddWithValue("@PlaylistID", PlaylistID);

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding content to playlist: " + ex.Message);
                return false;
            }

        }


        public bool InserirPlayList(String Titulo,String Autor,int Num_Likes,int EstadoP)
        {
            //apos o user clicar no mentario em vez de dar clear a tudo como fazia antes mostrar o comentario ou seja dar clear dos buttons e das labels e dar print com o codigo do conteudo, nome do conteudo, user que comentou, comentario e data 
            try
            {
                if (!verifyConnection())
                    return false;

                string query = "INSERT INTO Youtube.Playlist (Titulo, Autor, Num_Likes, Estado) " +
                               "VALUES (@TituloPlaylist, @AutorPlaylist,  @Num_Likes, @Estado)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TituloPlaylist",Titulo);
                    command.Parameters.AddWithValue("@AutorPlaylist", Autor);
                    command.Parameters.AddWithValue("@Num_Likes",Num_Likes);
                    command.Parameters.AddWithValue("@Estado", EstadoP);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir playlist: " + ex.Message);
                return false;
            }
        }
        public DataTable ListarPlayList()
        {
            try
            {
                if (!verifyConnection())
                {
                    Console.WriteLine("No Connection!");
                    return null;
                }

                string query = @"SELECT p.Titulo, p.CodigoP AS PlaylistID, [p5g2].[Youtube].CalculatePlaylistDuration(p.CodigoP) AS PlayList_Time_Duration,
                p.Autor, p.Num_Likes, e.state_name AS Estado
                FROM [p5g2].[Youtube].[Playlist] p
                JOIN [p5g2].[Youtube].[Estados] e ON p.Estado = e.state_id";




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
                Console.WriteLine("Erro ao obter playlists: " + ex.Message);
                return null;
            }
        }


      public DataTable ListarConteudoPlaylist(int CodigoP){

        //by the code of the playlist we can see the content of the playlist
        try
        {
            if (!verifyConnection())
            {
                Console.WriteLine("No Connection!");
                return null;
            }   

            string query= "SELECT C.Codigo, C.Titulo, C.Autor, C.Tipo, E.state_name AS Estado, C.Duracao, C.Num_Likes, C.Num_Views, C.Data_Pub FROM Youtube.Conteúdo AS C INNER JOIN Youtube.PlaylistVideo AS PV ON C.Codigo = PV.VideoID INNER JOIN Youtube.Estados AS E ON C.Estado = E.state_id WHERE PV.PlaylistID = @playlistID ";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@playlistID", CodigoP);
                    try
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao obter Playlist: " + ex.Message);
                        return null;
                    }
                }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao obter conteudo da playlist: " + ex.Message);
            return null;
        }

      }

        public DataTable ListaHistoricos()
        {
            try
            {
                if (!verifyConnection())
                {
                    Console.WriteLine("No Connection!");
                    return null;
                }

                string query = "SELECT Titulo, Codigo, Data_de_Visualizacao FROM[p5g2].[Youtube].[Historico] ORDER BY CodigoContentVisto DESC";

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
