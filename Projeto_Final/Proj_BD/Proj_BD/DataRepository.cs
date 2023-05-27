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






        /// /////////////////////////////////////// Mudar Queries ////////////////////////////////////////

        // Utilzadores
        public bool InserirUtilizador(string nomeUtilizador, string email, string senha, string nomeApelido, DateTime nascimento)
        {
            try
            {
                if (!verifyConnection())
                    return false;

                string query = "INSERT INTO [p5g2].[Youtube].[Utilizador] (Nome_Utilizador, Email, Senha, Nome, Data_de_Nascimento) " +
                               "VALUES (@NomeUtilizador, @Email, @Senha, @NomeApelido, @Nascimento)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomeUtilizador", nomeUtilizador);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Senha", senha);
                    command.Parameters.AddWithValue("@NomeApelido", nomeApelido);
                    command.Parameters.AddWithValue("@Nascimento", nascimento);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir utilizador: " + ex.Message);
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

                string query = "SELECT * FROM [p5g2].[Youtube].[Utilizador]";

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
        public bool InserirConteudo(string tipoConteudo, int id, string EstadoConteudo, int views, DateTime pub, TimeSpan duracao, string AutorConteudo, string TituloConteudo, int likes)
        {
            try
            {
                if (!verifyConnection())
                    return false;

                string query = "INSERT INTO [p5g2].[Youtube].[Conteúdo] (Titulo, Codigo, Autor, Tipo, Estado, Duracao, Num_Likes, Num_Views, Data_Pub) " +
                               "VALUES (@Titulo, @id, @autor, @Tipo, @estado, @dura, @Likes, @views, @pub)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titulo", TituloConteudo);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@autor", AutorConteudo);
                    command.Parameters.AddWithValue("@Tipo", tipoConteudo);
                    command.Parameters.AddWithValue("@estado", EstadoConteudo);
                    command.Parameters.AddWithValue("@dura", duracao);
                    command.Parameters.AddWithValue("@Likes", likes);
                    command.Parameters.AddWithValue("@views", views);
                    command.Parameters.AddWithValue("@pub", pub);


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

                string query = "SELECT * FROM [p5g2].[Youtube].[Conteúdo]";

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
        public bool InserirComentario(string Autor, string Texto, DateTime Data_Comentário, int CódigoV)
        {
            //apos o user clicar no mentario em vez de dar clear a tudo como fazia antes mostrar o comentario ou seja dar clear dos buttons e das labels e dar print com o codigo do conteudo, nome do conteudo, user que comentou, comentario e data 


            try
            {
                if (!verifyConnection())
                    return false;

                string query = "INSERT INTO Youtube.Comentários (Autor,Texto,Data_Comentário,CódigoV) " +
                               "VALUES (@Autor, @Texto, @Data_Comentário, @CódigoV)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Autor", Autor);
                    command.Parameters.AddWithValue("@Texto", Texto);
                    command.Parameters.AddWithValue("@Data_Comentário", Data_Comentário);
                    command.Parameters.AddWithValue("@CódigoV", CódigoV);

                    int rowsAffected = command.ExecuteNonQuery();
                    // apagar a proxima linha de codigo esta ca so para testes
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir utilizador: " + ex.Message);
                return false;
            }
        }
        public DataTable ListarComentario()
        {
            try
            {
                if (!verifyConnection())
                {
                    Console.WriteLine("No Connection!");
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

         // PlayList
        public bool InserirPlayList(String Titulo,int CodigoP,String Autor,int Num_Likes,int EstadoP)
        {
            //apos o user clicar no mentario em vez de dar clear a tudo como fazia antes mostrar o comentario ou seja dar clear dos buttons e das labels e dar print com o codigo do conteudo, nome do conteudo, user que comentou, comentario e data 
            try
            {
                if (!verifyConnection())
                    return false;

                string query = "INSERT INTO Youtube.Playlist (Titulo, CodigoP, Autor, Num_Likes, Estado) " +
                               "VALUES (@TituloPlaylist, @CodigoP, @AutorPlaylist,  @Num_Likes, @Estado)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TituloPlaylist",Titulo);
                    command.Parameters.AddWithValue("@CodigoP", CodigoP);
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

                string query = "SELECT * FROM [p5g2].[Youtube].[Playlist]";

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

            string query= "SELECT C.Codigo, C.Titulo, C.Autor, C.Tipo, C.Estado, C.Duração, C.Num_Likes, C.Num_Visualizações, C.Data_Publicação FROM Youtube.Conteúdo AS C INNER JOIN Youtube.PlaylistVideo AS PV ON C.Codigo = PV.VideoID WHERE PV.PlaylistID = @playlistID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CodigoP", CodigoP);
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
            Console.WriteLine("Erro ao obter conteudo da playlist: " + ex.Message);
            return null;
        }

      }

         // Historicos
        public bool InserirHistorico()
        {
            //apos o user clicar no mentario em vez de dar clear a tudo como fazia antes mostrar o comentario ou seja dar clear dos buttons e das labels e dar print com o codigo do conteudo, nome do conteudo, user que comentou, comentario e data 

            try
            {
                if (!verifyConnection())
                    return false;

                string query = "INSERT INTO Youtube.Histórico (Titulo,Codigo,Data_de_Visualização) " +
                               "VALUES (@Titulo, @Codigo, @Data_de_Visualização)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titulo", tipoConteudo);
                    command.Parameters.AddWithValue("@Codigo", idConteudo);
                    command.Parameters.AddWithValue("@Data_de_Visualização", EstadoConteudo);
                    command.Parameters.AddWithValue("@Data_de_Visualização", ViewsConteudo);

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
        public DataTable ListaHistoricos()
        {
            try
            {
                if (!verifyConnection())
                {
                    Console.WriteLine("No Connection!");
                    return null;
                }

                string query = "SELECT * FROM [p5g2].[Youtube].[Historicos]";

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
