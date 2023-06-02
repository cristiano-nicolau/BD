using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proj_BD
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        private Button btnUtilizadores;
        private Button btnConteudo;
        private Button btnCanal;
        private Button btnComentario;
        private Button btnPlaylist;
        private Button btnHistorico;
        private Panel pnlContent;
        private Button enviarUser;
        private Button verUsers;
        private Button clearPnlContent;
        private Button enviarConteudo;
        private Button verConteudos;
        private Button enviarComentario;
        private Button verComentarios;
        private Button enviarPlayList;
        private Button verPlayLists;
        private DataRepository dataRepository;
        private Button verPlayListCodigo;
        private Button unSubscriveVideo;
        private Button SubscriveVideo;
        private Button LikeVideo;
        private Button DeletePlay;



        // Campos de texto para capturar os valores do utilizador
        private TextBox txtNomeUtilizador;
        private TextBox txtemail;
        private TextBox tstSenha;
        private TextBox txtNomeApelido;
        private TextBox txtNascimento;
        private TextBox CommentId;
        private TextBox txtNomePremium;
        private TextBox txtMesesPremium;


        // campos de texto para capturar os valores do conteudo
        private TextBox TextoAutorConteudo;
        private TextBox TextoEstado;
        private TextBox TextoNumLikes;
        private TextBox TextoTipoConteudo;
        private TextBox TextTituloVideo;
        private TextBox textoDuracao;
        private TextBox textoDataPub;
        private TextBox textoNumVisualizacoes;
        private TextBox txtIdConteudo;
        
        // Campos de texto para capturar os valores do comentario
        private TextBox textUserComentario;
        private TextBox txtIdConteudoComent;
        private TextBox ComentText;
        private TextBox ComentDataText;
        private TextBox CodigoC;


        // Campos de texto para capturar os valores do Playlist
        private TextBox textUserPlaylistAutor;
        private TextBox txtTituloPlay;
        private TextBox idPlayList;
        private TextBox EstadoPlayList;
        private TextBox CodigoP;



        // Campos de texto para capturar os valores do Historico
        private TextBox VideosHistorico;
        private TextBox textUserHistoricpOwner;
        private TextBox DataHistorico;


        private TextBox Canal;
        private TextBox SenhaCanal;
        private TextBox CodigoPlayDelete;
        private TextBox CodigoLikeVideo;
        private TextBox Unfollow;
        private TextBox subscreverCanal;



        public Form1()
        {
            InitializeComponent();
            dataRepository = new DataRepository();
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {   
            btnUtilizadores = new Button();
            btnUtilizadores.Text = "Utilizadores";
            btnUtilizadores.Font = new Font(btnUtilizadores.Font, FontStyle.Bold);
            btnUtilizadores.Size = new Size(this.Width / 6, 50);
            btnUtilizadores.Location = new Point(0, 0);
            btnUtilizadores.BackColor = Color.White; // Define a cor de fundo como branco
            btnUtilizadores.FlatStyle = FlatStyle.Flat;
            btnUtilizadores.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            btnUtilizadores.Click += btnUtilizadores_Click;
            this.Controls.Add(btnUtilizadores);

            btnConteudo = new Button();
            btnConteudo.Text = "Conteúdo";
            btnConteudo.Font = new Font(btnConteudo.Font, FontStyle.Bold);
            btnConteudo.Size = new Size(this.Width / 6, 50);
            btnConteudo.Location = new Point(btnUtilizadores.Right, 0);
            btnConteudo.BackColor = Color.White; // Define a cor de fundo como branco
            btnConteudo.FlatStyle = FlatStyle.Flat;
            btnConteudo.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            btnConteudo.Click += btnConteudo_Click;
            this.Controls.Add(btnConteudo);

            btnComentario = new Button();
            btnComentario.Text = "Comentários";
            btnComentario.Font = new Font(btnComentario.Font, FontStyle.Bold);
            btnComentario.Size = new Size(this.Width / 6, 50);
            btnComentario.Location = new Point(btnConteudo.Right, 0);
            btnComentario.BackColor = Color.White; // Define a cor de fundo como branco
            btnComentario.FlatStyle = FlatStyle.Flat;
            btnComentario.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            btnComentario.Click += btnCmentarios_Click;
            this.Controls.Add(btnComentario);

            btnPlaylist = new Button();
            btnPlaylist.Text = "Playlist";
            btnPlaylist.Font = new Font(btnPlaylist.Font, FontStyle.Bold);
            btnPlaylist.Size = new Size(this.Width / 6, 50);
            btnPlaylist.Location = new Point(btnComentario.Right, 0);
            btnPlaylist.BackColor = Color.White; // Define a cor de fundo como branco
            btnPlaylist.FlatStyle = FlatStyle.Flat;
            btnPlaylist.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            btnPlaylist.Click += btnPlaylist_Click;
            this.Controls.Add(btnPlaylist);

            btnHistorico = new Button();
            btnHistorico.Text = "Histórico";
            btnHistorico.Font = new Font(btnHistorico.Font, FontStyle.Bold);
            btnHistorico.Size = new Size(this.Width / 6, 50);
            btnHistorico.Location = new Point(btnPlaylist.Right, 0);
            btnHistorico.BackColor = Color.White; // Define a cor de fundo como branco
            btnHistorico.FlatStyle = FlatStyle.Flat;
            btnHistorico.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            btnHistorico.Click += btnHistorico_Click;
            this.Controls.Add(btnHistorico);

            btnCanal = new Button();
            btnCanal.Text = "Canal";
            btnCanal.Font = new Font(btnCanal.Font, FontStyle.Bold);
            btnCanal.Size = new Size(this.Width / 6, 50);
            btnCanal.Location = new Point(btnHistorico.Right, 0);
            btnCanal.BackColor = Color.White; // Define a cor de fundo como branco
            btnCanal.FlatStyle = FlatStyle.Flat;
            btnCanal.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            btnCanal.Click += btnCanal_Click;
            this.Controls.Add(btnCanal);

            pnlContent = new Panel();
            pnlContent.Size = new Size(this.Width, this.Height - btnUtilizadores.Height);
            pnlContent.Location = new Point(0, btnUtilizadores.Bottom);
            pnlContent.BackColor = Color.DarkRed;
            pnlContent.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(pnlContent);

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Obter o objeto Graphics do formulário
            Graphics g = e.Graphics;

            // Definir a cor e a espessura da linha
            Pen pen = new Pen(Color.Black, 3);

            // Desenhar uma linha preta na parte superior do formulário
            g.DrawLine(pen, 0, 0, this.Width, 0);
        }
        private void btnCanal_Click ( object sender, EventArgs e )
        {
                        // Limpar os dados do painel
            pnlContent.Controls.Clear();
            Label NomeUtilizador = new Label();
            NomeUtilizador.Text = "Introduza o nome de utilizador e a palavra passe do canal onde quer iniciar sessao:";
            NomeUtilizador.ForeColor = Color.White;
            NomeUtilizador.Font = new Font(NomeUtilizador.Font, FontStyle.Bold);
            NomeUtilizador.Location = new Point(20, 20);
            NomeUtilizador.Size = new Size(500, 30);
            pnlContent.Controls.Add(NomeUtilizador);


            Label lblNomeUtilizador = new Label();
            lblNomeUtilizador.Text = "Nome de Utilizador:";
            lblNomeUtilizador.ForeColor = Color.White;
            lblNomeUtilizador.Font = new Font(lblNomeUtilizador.Font, FontStyle.Bold);
            lblNomeUtilizador.Location = new Point(20, 50);
            lblNomeUtilizador.Size = new Size(180, 30);
            pnlContent.Controls.Add(lblNomeUtilizador);

            Canal = new TextBox();
            Canal.Location = new Point(200, 50);
            Canal.Size = new Size(450, 40);
            pnlContent.Controls.Add(Canal);

            Label lblSenha = new Label();
            lblSenha.Text = "Senha do Utilizador:";
            lblSenha.ForeColor = Color.White;
            lblSenha.Font = new Font(lblSenha.Font, FontStyle.Bold);
            lblSenha.Location = new Point(20, 90);
            lblSenha.Size = new Size(180, 30);
            pnlContent.Controls.Add(lblSenha);

            SenhaCanal = new TextBox();
            SenhaCanal.Location = new Point(200, 90);
            SenhaCanal.Size = new Size(450, 40);
            pnlContent.Controls.Add(SenhaCanal);

            Button enviarUser = new Button();
            enviarUser.Text = "Inicia Sessão";
            enviarUser.Font = new Font(enviarUser.Font, FontStyle.Bold);
            enviarUser.Size = new Size(200, 30); // Ajusta o tamanho do botão
            enviarUser.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 130);
            enviarUser.BackColor = Color.White; // Define a cor de fundo como branco
            enviarUser.FlatStyle = FlatStyle.Flat;
            enviarUser.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            enviarUser.Click += IniciarSessao_Click;
            pnlContent.Controls.Add(enviarUser);

            Button verUsers = new Button();
            verUsers.Text = "Listar canais";
            verUsers.Font = new Font(verUsers.Font, FontStyle.Bold);
            verUsers.Size = new Size(200, 30); // Ajusta o tamanho do botão
            verUsers.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 90);
            verUsers.BackColor = Color.White; // Define a cor de fundo como branco
            verUsers.FlatStyle = FlatStyle.Flat;
            verUsers.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            verUsers.Click += ProcurarUser_Click;
            pnlContent.Controls.Add(verUsers);

            Button clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.Size = new Size(200, 30); // Ajusta o tamanho do botão
            clearPnlContent.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 50);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);
        }
        private void AfterUserConnect()
        {
            pnlContent.Controls.Clear();

            Label info1 = new Label();
            info1.Text = "Caso queira apagar uma playlist, insira o código da playlist:";
            info1.ForeColor = Color.White;
            info1.Font = new Font(info1.Font, FontStyle.Bold);
            info1.Location = new Point(20, 20);
            info1.Size = new Size(500, 30);
            pnlContent.Controls.Add(info1);


            Label llcodigo = new Label();
            llcodigo.Text = "Código:";
            llcodigo.ForeColor = Color.White;
            llcodigo.Font = new Font(llcodigo.Font, FontStyle.Bold);
            llcodigo.Location = new Point(20, 50);
            llcodigo.Size = new Size(180, 30);
            pnlContent.Controls.Add(llcodigo);

            CodigoPlayDelete = new TextBox();
            CodigoPlayDelete.Location = new Point(200, 50);
            CodigoPlayDelete.Size = new Size(450, 40);
            pnlContent.Controls.Add(CodigoPlayDelete);


            Label info2 = new Label();
            info2.Text = "Caso queira dar like num video, insira o código do video:";
            info2.ForeColor = Color.White;
            info2.Font = new Font(info2.Font, FontStyle.Bold);
            info2.Location = new Point(20, 130);
            info2.Size = new Size(500, 30);
            pnlContent.Controls.Add(info2);


            Label llcodigo2 = new Label();
            llcodigo2.Text = "Código:";
            llcodigo2.ForeColor = Color.White;
            llcodigo2.Font = new Font(llcodigo2.Font, FontStyle.Bold);
            llcodigo2.Location = new Point(20, 170);
            llcodigo2.Size = new Size(180, 30);
            pnlContent.Controls.Add(llcodigo2);

            CodigoLikeVideo = new TextBox();
            CodigoLikeVideo.Location = new Point(200, 170);
            CodigoLikeVideo.Size = new Size(450, 40);
            pnlContent.Controls.Add(CodigoLikeVideo);

            
            Label info3 = new Label();
            info3.Text = "Caso queira subscrever um canal, insira o nome do canal:";
            info3.ForeColor = Color.White;
            info3.Font = new Font(info3.Font, FontStyle.Bold);
            info3.Location = new Point(20, 250);
            info3.Size = new Size(500, 30);
            pnlContent.Controls.Add(info3);


            Label llcodigo3 = new Label();
            llcodigo3.Text = "Nome:";
            llcodigo3.ForeColor = Color.White;
            llcodigo3.Font = new Font(llcodigo3.Font, FontStyle.Bold);
            llcodigo3.Location = new Point(20, 290);
            llcodigo3.Size = new Size(180, 30);
            pnlContent.Controls.Add(llcodigo3);

            subscreverCanal = new TextBox();
            subscreverCanal.Location = new Point(200, 290);
            subscreverCanal.Size = new Size(450, 40);
            pnlContent.Controls.Add(subscreverCanal);

            Label info4 = new Label();
            info4.Text = "Caso queira retirar a subscrição de um canal, insira o nome do canal:";
            info4.ForeColor = Color.White;
            info4.Font = new Font(info4.Font, FontStyle.Bold);
            info4.Location = new Point(20, 370);
            info4.Size = new Size(500, 30);
            pnlContent.Controls.Add(info4);


            Label llcodigo4 = new Label();
            llcodigo4.Text = "Nome:";
            llcodigo4.ForeColor = Color.White;
            llcodigo4.Font = new Font(llcodigo4.Font, FontStyle.Bold);
            llcodigo4.Location = new Point(20, 410);
            llcodigo4.Size = new Size(180, 30);
            pnlContent.Controls.Add(llcodigo4);

            Unfollow = new TextBox();
            Unfollow.Location = new Point(200, 410);
            Unfollow.Size = new Size(450, 40);
            pnlContent.Controls.Add(Unfollow);

            Button DeletePlay = new Button();
            DeletePlay.Text = "Apagar Playlist";
            DeletePlay.Font = new Font(DeletePlay.Font, FontStyle.Bold);
            DeletePlay.Size = new Size(200, 30); // Ajusta o tamanho do botão
            DeletePlay.Location = new Point(pnlContent.Width - 230, 50);
            DeletePlay.BackColor = Color.White; // Define a cor de fundo como branco
            DeletePlay.FlatStyle = FlatStyle.Flat;
            DeletePlay.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            DeletePlay.Click += DeletePlay_Click;
            pnlContent.Controls.Add(DeletePlay);
            
            Button LikeVideo = new Button();
            LikeVideo.Text = "Dar Like em um video";
            LikeVideo.Font = new Font(LikeVideo.Font, FontStyle.Bold);
            LikeVideo.Size = new Size(200, 30); // Ajusta o tamanho do botão
            LikeVideo.Location = new Point(pnlContent.Width - 230, 170);
            LikeVideo.BackColor = Color.White; // Define a cor de fundo como branco
            LikeVideo.FlatStyle = FlatStyle.Flat;
            LikeVideo.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            LikeVideo.Click += LikeVideo_Click;
            pnlContent.Controls.Add(LikeVideo);

            Button SubscriveVideo = new Button();
            SubscriveVideo.Text = "Subscrever um canal";
            SubscriveVideo.Font = new Font(SubscriveVideo.Font, FontStyle.Bold);
            SubscriveVideo.Size = new Size(200, 30); // Ajusta o tamanho do botão
            SubscriveVideo.Location = new Point(pnlContent.Width - 230, 290);
            SubscriveVideo.BackColor = Color.White; // Define a cor de fundo como branco
            SubscriveVideo.FlatStyle = FlatStyle.Flat;
            SubscriveVideo.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            SubscriveVideo.Click += SubscriveVideo_Click;
            pnlContent.Controls.Add(SubscriveVideo);

            Button unSubscriveVideo = new Button();
            unSubscriveVideo.Text = "Unfollow canal";
            unSubscriveVideo.Font = new Font(unSubscriveVideo.Font, FontStyle.Bold);
            unSubscriveVideo.Size = new Size(200, 30); // Ajusta o tamanho do botão
            unSubscriveVideo.Location = new Point(pnlContent.Width - 230, 410);
            unSubscriveVideo.BackColor = Color.White; // Define a cor de fundo como branco
            unSubscriveVideo.FlatStyle = FlatStyle.Flat;
            unSubscriveVideo.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            unSubscriveVideo.Click += unSubscriveVideo_Click;
            pnlContent.Controls.Add(unSubscriveVideo);

            Button clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.Size = new Size(200, 30); // Ajusta o tamanho do botão
            clearPnlContent.Location = new Point(pnlContent.Width - 230,  480);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);
        }
        private void SubscriveVideo_Click(object sender, EventArgs e) {
            pnlContent.Controls.Clear();

            string subs = subscreverCanal.Text;

            if (string.IsNullOrWhiteSpace(subs))
            {
                MessageBox.Show("Por favor, preencha o campo.");
                return;
            }


            // Enviar os dados para o DataRepository
            bool sucesso = dataRepository.SubscreverVideo(subs);

            if (sucesso)
            {
                MessageBox.Show("Canal Subscrito com sucesso!");
                AfterUserConnect();
            }
            else
            {
                MessageBox.Show("Erro ao subscrever canal. Por favor, tente novamente, ou insira um canal correto.");
            }



        }
        private void unSubscriveVideo_Click(object sender, EventArgs e) { 
             pnlContent.Controls.Clear();

            string subs = Unfollow.Text;

            if (string.IsNullOrWhiteSpace(subs))
            {
                MessageBox.Show("Por favor, preencha o campo.");
                return;
            }


            // Enviar os dados para o DataRepository
            bool sucesso = dataRepository.unSubscreverVideo(subs);

            if (sucesso)
            {
                MessageBox.Show("Subscrição retirada com sucesso!");
                AfterUserConnect();
            }
            else
            {
                MessageBox.Show("Erro ao retirar subscrição do canal. Por favor, tente novamente, ou insira um canal correto.");
            }


        }
        private void LikeVideo_Click(object sender, EventArgs e) {

            pnlContent.Controls.Clear();

            string like = CodigoLikeVideo.Text;

            if (string.IsNullOrWhiteSpace(like))
            {
                MessageBox.Show("Por favor, preencha o campo.");
                return;
            }


            // Enviar os dados para o DataRepository
            bool sucesso = dataRepository.LikeVideo(like);

            if (sucesso)
            {
                MessageBox.Show("Like dado com sucesso!");
                AfterUserConnect();
            }
            else
            {
                MessageBox.Show("Erro ao dar like. Por favor, tente novamente.");
            }
        }
        private void DeletePlay_Click(object sender, EventArgs e) {
            pnlContent.Controls.Clear();

            int code = int.Parse(CodigoPlayDelete.Text);

            if (string.IsNullOrWhiteSpace(CodigoPlayDelete.Text))
            {
                MessageBox.Show("Por favor, preencha o campo.");
                return;
            }


            // Enviar os dados para o DataRepository
            bool sucesso = dataRepository.DeletePlaylist(code);

            if (sucesso)
            {
                MessageBox.Show("Playlist and associated playlist videos deleted successfully.");
                AfterUserConnect();
            }
            else
            {
                MessageBox.Show("Erro ao eliminar a playlist. Por favor, tente novamente.");
            }

        }

        private void IniciarSessao_Click(object sender, EventArgs e){
            pnlContent.Controls.Clear();

            // Obter os valores dos campos de texto
            string nomeUtilizador = Canal.Text;
            string senha = SenhaCanal.Text;



            // Verificar se todos os campos foram preenchidos
            if (string.IsNullOrWhiteSpace(nomeUtilizador) || string.IsNullOrWhiteSpace(senha) )
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            // Enviar os dados para o DataRepository
            bool sucesso = dataRepository.IniciarSessaoUser(nomeUtilizador, senha);

            if (sucesso)
            {
                MessageBox.Show("Sessao iniciada com sucesso!");
                AfterUserConnect();
            }
            else
            {
                MessageBox.Show("Erro ao iniciar Sessao. Por favor, tente novamente.");
            }


        }

        private void ProcurarUser_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            // Limpar os dados do painel
            clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Size = new Size(80, 30);
            clearPnlContent.Location = new Point(pnlContent.Width - 250, pnlContent.Height - 300);
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);

            // Obter os utilizadores do DataRepository
            DataTable utilizadores = dataRepository.ProcurarUser();

            // Criar uma DataGridView para exibir os utilizadores
            DataGridView dgvUtilizadores = new DataGridView();
            dgvUtilizadores.BackgroundColor = Color.Gray;
            dgvUtilizadores.Font = new Font(dgvUtilizadores.Font, FontStyle.Bold);
            dgvUtilizadores.DataSource = utilizadores;
            dgvUtilizadores.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(dgvUtilizadores);
        }

        //
        // Utilizador
        //

        private void btnUtilizadores_Click(object sender, EventArgs e)
        {
            // Limpa os dados do painel 
            pnlContent.Controls.Clear();

            // Cria os controles para inserir os dados do utilizador
            Label lblNomeUtilizador = new Label();
            lblNomeUtilizador.Text = "Nome de Utilizador:";
            lblNomeUtilizador.ForeColor = Color.White;
            lblNomeUtilizador.Font = new Font(lblNomeUtilizador.Font, FontStyle.Bold);
            lblNomeUtilizador.Location = new Point(20, 10);
            lblNomeUtilizador.Size = new Size(180, 30); 
            pnlContent.Controls.Add(lblNomeUtilizador);

            txtNomeUtilizador = new TextBox();
            txtNomeUtilizador.Location = new Point(200, 10);
            txtNomeUtilizador.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtNomeUtilizador);

            Label lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.ForeColor = Color.White;
            lblEmail.Font = new Font(lblEmail.Font, FontStyle.Bold);
            lblEmail.Location = new Point(20, 50);
            lblEmail.Size = new Size(180, 30); 
            pnlContent.Controls.Add(lblEmail);

            txtemail = new TextBox();
            txtemail.Location = new Point(200, 50);
            txtemail.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtemail);

            Label lblSenha = new Label();
            lblSenha.Text = "Senha:";
            lblSenha.ForeColor = Color.White;
            lblSenha.Font = new Font(lblSenha.Font, FontStyle.Bold);
            lblSenha.Location = new Point(20, 90);
            lblSenha.Size = new Size(180, 30); 
            pnlContent.Controls.Add(lblSenha);

            tstSenha = new TextBox();
            tstSenha.Location = new Point(200, 90);
            tstSenha.Size = new Size(450, 40); 
            pnlContent.Controls.Add(tstSenha);

            Label lblNomeApelido = new Label();
            lblNomeApelido.Text = "Nome e Apelido:";
            lblNomeApelido.ForeColor = Color.White;
            lblNomeApelido.Font = new Font(lblNomeApelido.Font, FontStyle.Bold);
            lblNomeApelido.Location = new Point(20, 130);
            lblNomeApelido.Size = new Size(180, 30); 
            pnlContent.Controls.Add(lblNomeApelido);

            txtNomeApelido = new TextBox();
            txtNomeApelido.Location = new Point(200, 130);
            txtNomeApelido.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtNomeApelido);

            Label lblNascimento = new Label();
            lblNascimento.Text = "Data Nascimento:";
            lblNascimento.ForeColor = Color.White;
            lblNascimento.Font = new Font(lblNascimento.Font, FontStyle.Bold);
            lblNascimento.Location = new Point(20, 170);
            lblNascimento.Size = new Size(180, 30); 
            pnlContent.Controls.Add(lblNascimento);

            txtNascimento = new TextBox();
            txtNascimento.Location = new Point(200, 170);
            txtNascimento.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtNascimento);


            Label lblNomePremium = new Label();
            lblNomePremium.Text = "Deseja Premium? Insira por favor :";
            lblNomePremium.ForeColor = Color.White;
            lblNomePremium.Font = new Font(lblNomePremium.Font, FontStyle.Bold);
            lblNomePremium.Location = new Point(20, pnlContent.Height-250);
            lblNomePremium.Size = new Size(250, 30);
            pnlContent.Controls.Add(lblNomePremium);

            txtNomePremium = new TextBox();
            txtNomePremium.Location = new Point(200, pnlContent.Height - 220);
            txtNomePremium.Size = new Size(250, 40);
            pnlContent.Controls.Add(txtNomePremium);

            Label lblMesesPremium = new Label();
            lblMesesPremium.Text = "Número de meses que deseja o Premium:";
            lblMesesPremium.ForeColor = Color.White;
            lblMesesPremium.Font = new Font(lblMesesPremium.Font, FontStyle.Bold);
            lblMesesPremium.Location = new Point(20, pnlContent.Height - 180);
            lblMesesPremium.Size = new Size(180, 30);
            pnlContent.Controls.Add(lblMesesPremium);

            txtMesesPremium = new TextBox();
            txtMesesPremium.Location = new Point(200, pnlContent.Height - 150);
            txtMesesPremium.Size = new Size(250, 40);
            pnlContent.Controls.Add(txtMesesPremium);

            Button SubmeterPremium = new Button();
            SubmeterPremium.Text = "Premium";
            SubmeterPremium.Font = new Font(SubmeterPremium.Font, FontStyle.Bold);
            SubmeterPremium.Size = new Size(200, 30); // Ajusta o tamanho do botão
            SubmeterPremium.Location = new Point(pnlContent.Width - 230, pnlContent.Height- 150);
            SubmeterPremium.BackColor = Color.White; // Define a cor de fundo como branco
            SubmeterPremium.FlatStyle = FlatStyle.Flat;
            SubmeterPremium.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            SubmeterPremium.Click += SubmeterPremium_Click;
            pnlContent.Controls.Add(SubmeterPremium);

            Button enviarUser = new Button();
            enviarUser.Text = "Criar Utilizador";
            enviarUser.Font = new Font(enviarUser.Font, FontStyle.Bold);
            enviarUser.Size = new Size(200, 30); // Ajusta o tamanho do botão
            enviarUser.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 130 );
            enviarUser.BackColor = Color.White; // Define a cor de fundo como branco
            enviarUser.FlatStyle = FlatStyle.Flat;
            enviarUser.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            enviarUser.Click += EnviarUser_Click;
            pnlContent.Controls.Add(enviarUser);

            Button verUsers = new Button();
            verUsers.Text = "Ver Utilizadores";
            verUsers.Font = new Font(verUsers.Font, FontStyle.Bold);
            verUsers.Size = new Size(200, 30); // Ajusta o tamanho do botão
            verUsers.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 90);
            verUsers.BackColor = Color.White; // Define a cor de fundo como branco
            verUsers.FlatStyle = FlatStyle.Flat;
            verUsers.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            verUsers.Click += VerUsers_Click;
            pnlContent.Controls.Add(verUsers);

            Button clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.Size = new Size(200, 30); // Ajusta o tamanho do botão
            clearPnlContent.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 50);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);
        }


        private void SubmeterPremium_Click(object sender,EventArgs e)
        {
            string nomeUtilizador = txtNomePremium.Text;
            string meses = txtMesesPremium.Text;

            if (string.IsNullOrWhiteSpace(nomeUtilizador) || string.IsNullOrWhiteSpace(meses))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }


            bool sucesso = dataRepository.SubmeterPremium(nomeUtilizador, meses);

            if (sucesso)
            {
                MessageBox.Show("Utlizador é agora Premium!");
                LimparCamposUtilizador();
            }
            else
            {
                MessageBox.Show("Erro!");
            }

        }
        private void EnviarUser_Click(object sender, EventArgs e)
        {
            // Obter os valores dos campos de texto
            string nomeUtilizador = txtNomeUtilizador.Text;
            string email = txtemail.Text;
            string senha = tstSenha.Text;
            string nomeApelido = txtNomeApelido.Text;
            string nascimentoText = txtNascimento.Text;


            // Verificar se todos os campos foram preenchidos
            if (string.IsNullOrWhiteSpace(nomeUtilizador) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha) ||
                string.IsNullOrWhiteSpace(nomeApelido) || string.IsNullOrWhiteSpace(nascimentoText))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            if (!DateTime.TryParse(nascimentoText, out DateTime nascimento))
            {
                MessageBox.Show("Formato de data inválido. Por favor, insira uma data válida.");
                return;
            }

            // Enviar os dados para o DataRepository
            bool sucesso = dataRepository.InserirUtilizador(nomeUtilizador,  email, senha, nomeApelido, nascimento);

            if (sucesso)
            {
                MessageBox.Show("Utilizador criado com sucesso!");
                LimparCamposUtilizador();
            }
            else
            {
                MessageBox.Show("Erro ao criar o utilizador. Por favor, tente novamente.");
            }
        }

        private void VerUsers_Click(object sender, EventArgs e)
        {
            // Limpar os dados do painel
            pnlContent.Controls.Clear();

            clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Size = new Size(80, 30);
            clearPnlContent.Location = new Point(pnlContent.Width - 100, pnlContent.Height - 300);
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);

            // Obter os utilizadores do DataRepository
            DataTable utilizadores = dataRepository.ListarUtilizadores();

            // Criar uma DataGridView para exibir os utilizadores
            DataGridView dgvUtilizadores = new DataGridView();
            dgvUtilizadores.BackgroundColor = Color.Gray;
            dgvUtilizadores.Font = new Font(dgvUtilizadores.Font, FontStyle.Bold);
            dgvUtilizadores.DataSource = utilizadores;
            dgvUtilizadores.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(dgvUtilizadores);

 
        }
        private void LimparCamposUtilizador()
        {
            txtNomeUtilizador.Text = string.Empty;
            txtemail.Text = string.Empty;
            tstSenha.Text = string.Empty;
            txtNomeApelido.Text = string.Empty;
            txtNascimento.Text = string.Empty;
        }

        //
        // Conteudo
        // 
         private void btnConteudo_Click(object sender, EventArgs e)
        {
            // Limpa os dados do painel 
            pnlContent.Controls.Clear();

            // Cria os controles para inserir os dados do utilizador
            Label lblTituloConteudo = new Label();
            lblTituloConteudo.Text = "Nome de Conteudo:";
            lblTituloConteudo.ForeColor = Color.White;
            lblTituloConteudo.Font = new Font(lblTituloConteudo.Font, FontStyle.Bold);
            lblTituloConteudo.Location = new Point(20, 10);
            lblTituloConteudo.Size = new Size(180, 30); 
            pnlContent.Controls.Add(lblTituloConteudo);

            TextTituloVideo = new TextBox();
            TextTituloVideo.Location = new Point(200, 10);
            TextTituloVideo.Size = new Size(450, 40); 
            pnlContent.Controls.Add(TextTituloVideo);

            Label IdConteudo = new Label();
            IdConteudo.Text = "Id Conteudo:";
            IdConteudo.ForeColor = Color.White;
            IdConteudo.Font = new Font(IdConteudo.Font, FontStyle.Bold);
            IdConteudo.Location = new Point(20, 50);
            IdConteudo.Size = new Size(180, 30); 
            pnlContent.Controls.Add(IdConteudo);

            txtIdConteudo = new TextBox();
            txtIdConteudo.Location = new Point(200, 50);
            txtIdConteudo.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtIdConteudo);

            Label AutorConteudo = new Label();
            AutorConteudo.Text = "Autor:";
            AutorConteudo.ForeColor = Color.White;
            AutorConteudo.Font = new Font(AutorConteudo.Font, FontStyle.Bold);
            AutorConteudo.Location = new Point(20, 90);
            AutorConteudo.Size = new Size(180, 30); 
            pnlContent.Controls.Add(AutorConteudo);

            TextoAutorConteudo = new TextBox();
            TextoAutorConteudo.Location = new Point(200, 90);
            TextoAutorConteudo.Size = new Size(450, 40); 
            pnlContent.Controls.Add(TextoAutorConteudo);

            Label TipoConteudo = new Label();
            TipoConteudo.Text = "Tipo:";
            TipoConteudo.ForeColor = Color.White;
            TipoConteudo.Font = new Font(TipoConteudo.Font, FontStyle.Bold);
            TipoConteudo.Location = new Point(20, 130);
            TipoConteudo.Size = new Size(180, 30); 
            pnlContent.Controls.Add(TipoConteudo);

            TextoTipoConteudo = new TextBox();
            TextoTipoConteudo.Location = new Point(200, 130);
            TextoTipoConteudo.Size = new Size(450, 40); 
            pnlContent.Controls.Add(TextoTipoConteudo);

            Label lblEstado = new Label();
            lblEstado.Text = "Estado:";
            lblEstado.ForeColor = Color.White;
            lblEstado.Font = new Font(lblEstado.Font, FontStyle.Bold);
            lblEstado.Location = new Point(20, 170);
            lblEstado.Size = new Size(180, 30); 
            pnlContent.Controls.Add(lblEstado);

            TextoEstado = new TextBox();
            TextoEstado.Location = new Point(200, 170);
            TextoEstado.Size = new Size(450, 40); 
            pnlContent.Controls.Add(TextoEstado);

            Label lblDuracao = new Label();
            lblDuracao.Text = "Duração:";
            lblDuracao.ForeColor = Color.White;
            lblDuracao.Font = new Font(lblDuracao.Font, FontStyle.Bold);
            lblDuracao.Location = new Point(20, 210);
            lblDuracao.Size = new Size(180, 30); 
            pnlContent.Controls.Add(lblDuracao);

            textoDuracao = new TextBox();
            textoDuracao.Location = new Point(200, 210);
            textoDuracao.Size = new Size(450, 40); 
            pnlContent.Controls.Add(textoDuracao);

            Label lblNumLikes = new Label();
            lblNumLikes.Text = "Nr Likes:";
            lblNumLikes.ForeColor = Color.White;
            lblNumLikes.Font = new Font(lblNumLikes.Font, FontStyle.Bold);
            lblNumLikes.Location = new Point(20, 250);
            lblNumLikes.Size = new Size(180, 30); 
            pnlContent.Controls.Add(lblNumLikes);

            TextoNumLikes = new TextBox();
            TextoNumLikes.Location = new Point(200, 250);
            TextoNumLikes.Size = new Size(450, 40); 
            pnlContent.Controls.Add(TextoNumLikes);

            Label lblNumVisualizacoes = new Label();
            lblNumVisualizacoes.Text = "Nr Views:";
            lblNumVisualizacoes.ForeColor = Color.White;
            lblNumVisualizacoes.Font = new Font(lblNumVisualizacoes.Font, FontStyle.Bold);
            lblNumVisualizacoes.Location = new Point(20, 290);
            lblNumVisualizacoes.Size = new Size(180, 30); 
            pnlContent.Controls.Add(lblNumVisualizacoes);

            textoNumVisualizacoes = new TextBox();
            textoNumVisualizacoes.Location = new Point(200, 290);
            textoNumVisualizacoes.Size = new Size(450, 40); 
            pnlContent.Controls.Add(textoNumVisualizacoes);

            Label lblDataPub = new Label();
            lblDataPub.Text = "Publicado:";
            lblDataPub.ForeColor = Color.White;
            lblDataPub.Font = new Font(lblDataPub.Font, FontStyle.Bold);
            lblDataPub.Location = new Point(20, 330);
            lblDataPub.Size = new Size(180, 30); 
            pnlContent.Controls.Add(lblDataPub);

            textoDataPub = new TextBox();
            textoDataPub.Location = new Point(200, 330);
            textoDataPub.Size = new Size(450, 40); 
            pnlContent.Controls.Add(textoDataPub);

            Button enviarConteudo = new Button();
            enviarConteudo.Text = "Criar Conteúdo";
            enviarConteudo.Font = new Font(enviarConteudo.Font, FontStyle.Bold);
            enviarConteudo.Size = new Size(200, 30); // Ajusta o tamanho do botão
            enviarConteudo.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 130 );
            enviarConteudo.BackColor = Color.White; // Define a cor de fundo como branco
            enviarConteudo.FlatStyle = FlatStyle.Flat;
            enviarConteudo.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            enviarConteudo.Click += enviarConteudo_Click;
            pnlContent.Controls.Add(enviarConteudo);

            Button verConteudos = new Button();
            verConteudos.Text = "Ver Conteúdo";
            verConteudos.Font = new Font(verConteudos.Font, FontStyle.Bold);
            verConteudos.Size = new Size(200, 30); // Ajusta o tamanho do botão
            verConteudos.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 90);
            verConteudos.BackColor = Color.White; // Define a cor de fundo como branco
            verConteudos.FlatStyle = FlatStyle.Flat;
            verConteudos.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            verConteudos.Click += verConteudos_Click;
            pnlContent.Controls.Add(verConteudos);

            Button clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.Size = new Size(200, 30); // Ajusta o tamanho do botão
            clearPnlContent.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 50);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);
        }
        public void enviarConteudo_Click (object sender, EventArgs e){
            
            string tipoConteudo = TextoTipoConteudo.Text;
            string idConteudo = txtIdConteudo.Text;
            string EstadoConteudo = TextoEstado.Text;
            string ViewsConteudo = textoNumVisualizacoes.Text;
            string pubConteudo = textoDataPub.Text;
            string DuracaoConteudo = textoDuracao.Text;
            string AutorConteudo = TextoAutorConteudo.Text;
            string TituloConteudo = TextTituloVideo.Text;
            string likesConteudo = TextoNumLikes.Text;

             // Verificar se todos os campos foram preenchidos
            if (string.IsNullOrWhiteSpace(tipoConteudo) || string.IsNullOrWhiteSpace(idConteudo) ||
                string.IsNullOrWhiteSpace(EstadoConteudo) || string.IsNullOrWhiteSpace(ViewsConteudo) ||
                string.IsNullOrWhiteSpace(pubConteudo) || string.IsNullOrWhiteSpace(DuracaoConteudo) ||
                string.IsNullOrWhiteSpace(AutorConteudo) || string.IsNullOrWhiteSpace(TituloConteudo) || string.IsNullOrWhiteSpace(likesConteudo))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }
            int id = int.Parse(idConteudo);
            int likes = int.Parse(likesConteudo);
            int views = int.Parse(ViewsConteudo);
            TimeSpan duracao = TimeSpan.Parse(DuracaoConteudo);
            DateTime pub = DateTime.Parse(pubConteudo);

            // Enviar os dados para o DataRepository
            bool sucesso = dataRepository.InserirConteudo(tipoConteudo, id, EstadoConteudo, views, pub, duracao, AutorConteudo, TituloConteudo, likes);

             if (sucesso)
             {
                 MessageBox.Show("Conteudo criado com sucesso!");
                 LimparCamposConteudo();
             }
             else
             {
                 MessageBox.Show("Erro ao criar o conteudo. Por favor, tente novamente.");
             }


        }
        public void verConteudos_Click (object sender, EventArgs e){ 
             // Limpar os dados do painel
            pnlContent.Controls.Clear();

            clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Size = new Size(80, 30);
            clearPnlContent.Location = new Point(pnlContent.Width - 100, pnlContent.Height - 90);
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);

            // Obter os utilizadores do DataRepository
            DataTable utilizadores = dataRepository.ListarConteudo();

            // Criar uma DataGridView para exibir os utilizadores
            DataGridView dgvUtilizadores = new DataGridView();
            dgvUtilizadores.DataSource = utilizadores;
            dgvUtilizadores.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(dgvUtilizadores);
        }
        public void LimparCamposConteudo (){
            TextoTipoConteudo.Text = string.Empty;
            txtIdConteudo.Text = string.Empty;
            TextoEstado.Text = string.Empty;
            textoNumVisualizacoes.Text = string.Empty;
            textoDataPub.Text = string.Empty;
            textoDuracao.Text = string.Empty;
            TextoAutorConteudo.Text = string.Empty;
            TextTituloVideo.Text = string.Empty;
            TextoNumLikes.Text = string.Empty;
        }



        //
        // Comentarios 
        // 
        private void btnCmentarios_Click(object sender, EventArgs e)
        {
            // Limpa os dados do painel 
            pnlContent.Controls.Clear();

            // Cria os controles para inserir os dados do utilizador
            Label lblNomeUser = new Label();
            lblNomeUser.Text = "Nome de Utilizador:";
            lblNomeUser.ForeColor = Color.White;
            lblNomeUser.Font = new Font(lblNomeUser.Font, FontStyle.Bold);
            lblNomeUser.Location = new Point(20, 10);
            lblNomeUser.Size = new Size(180, 30);
            pnlContent.Controls.Add(lblNomeUser);

            textUserComentario = new TextBox();
            textUserComentario.Location = new Point(200, 10);
            textUserComentario.Size = new Size(450, 40);
            pnlContent.Controls.Add(textUserComentario);

            Label IdConteudo = new Label();
            IdConteudo.Text = "Id Conteudo:";
            IdConteudo.ForeColor = Color.White;
            IdConteudo.Font = new Font(IdConteudo.Font, FontStyle.Bold);
            IdConteudo.Location = new Point(20, 50);
            IdConteudo.Size = new Size(180, 30);
            pnlContent.Controls.Add(IdConteudo);

            txtIdConteudoComent = new TextBox();
            txtIdConteudoComent.Location = new Point(200, 50);
            txtIdConteudoComent.Size = new Size(450, 40);
            pnlContent.Controls.Add(txtIdConteudoComent);

            Label Comentario = new Label();
            Comentario.Text = "Comentário:";
            Comentario.ForeColor = Color.White;
            Comentario.Font = new Font(Comentario.Font, FontStyle.Bold);
            Comentario.Location = new Point(20, 90);
            Comentario.Size = new Size(180, 30);
            pnlContent.Controls.Add(Comentario);

            ComentText = new TextBox();
            ComentText.Location = new Point(200, 90);
            ComentText.Size = new Size(450, 40);
            pnlContent.Controls.Add(ComentText);

            Label DataComentario = new Label();
            DataComentario.Text = "Data do Comentário:";
            DataComentario.ForeColor = Color.White;
            DataComentario.Font = new Font(DataComentario.Font, FontStyle.Bold);
            DataComentario.Location = new Point(20, 130);
            DataComentario.Size = new Size(180, 30);
            pnlContent.Controls.Add(DataComentario);

            ComentDataText = new TextBox();
            ComentDataText.Location = new Point(200, 130);
            ComentDataText.Size = new Size(450, 40);
            pnlContent.Controls.Add(ComentDataText);

            Label IdComentário = new Label();
            IdComentário.Text = "Id Comentário:";
            IdComentário.ForeColor = Color.White;
            IdComentário.Font = new Font(IdComentário.Font, FontStyle.Bold);
            IdComentário.Location = new Point(20, 180);
            IdComentário.Size = new Size(180, 30);
            pnlContent.Controls.Add(IdComentário);

            CommentId = new TextBox();
            CommentId.Location = new Point(200, 180);
            CommentId.Size = new Size(450, 40);
            pnlContent.Controls.Add(CommentId);


            Button enviarComentario = new Button();
            enviarComentario.Text = "Criar Comentário";
            enviarComentario.Font = new Font(enviarComentario.Font, FontStyle.Bold);
            enviarComentario.Size = new Size(200, 30); // Ajusta o tamanho do botão
            enviarComentario.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 130);
            enviarComentario.BackColor = Color.White; // Define a cor de fundo como branco
            enviarComentario.FlatStyle = FlatStyle.Flat;
            enviarComentario.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            enviarComentario.Click += enviarComentario_Click;
            pnlContent.Controls.Add(enviarComentario);

            Button verComentarios = new Button();
            verComentarios.Text = "Ver Comentários";
            verComentarios.Font = new Font(verComentarios.Font, FontStyle.Bold);
            verComentarios.Size = new Size(200, 30); // Ajusta o tamanho do botão
            verComentarios.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 90);
            verComentarios.BackColor = Color.White; // Define a cor de fundo como branco
            verComentarios.FlatStyle = FlatStyle.Flat;
            verComentarios.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            verComentarios.Click += verComentarios_Click;
            pnlContent.Controls.Add(verComentarios);

            Button clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.Size = new Size(200, 30); // Ajusta o tamanho do botão
            clearPnlContent.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 50);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);


            Label TextCodigoP = new Label();
            TextCodigoP.Text = "A informação abaixo so é preenchida no caso do utilizador querer saber mais informações sobre os comentarios de algum conteudo.";
            TextCodigoP.ForeColor = Color.White;
            TextCodigoP.Font = new Font(TextCodigoP.Font, FontStyle.Bold);
            TextCodigoP.Location = new Point(20, 350);
            TextCodigoP.Size = new Size(650, 30);
            pnlContent.Controls.Add(TextCodigoP);

            Label lblCodigoP = new Label();
            lblCodigoP.Text = "Codigo Conteudo:";
            lblCodigoP.ForeColor = Color.White;
            lblCodigoP.Font = new Font(lblCodigoP.Font, FontStyle.Bold);
            lblCodigoP.Location = new Point(20, 390);
            lblCodigoP.Size = new Size(180, 30);
            pnlContent.Controls.Add(lblCodigoP);

            CodigoC = new TextBox();
            CodigoC.Location = new Point(200, 390);
            CodigoC.Size = new Size(450, 40);
            pnlContent.Controls.Add(CodigoC);

            
            Button allComentarios = new Button();
            allComentarios.Text = "Ver Mais Sobre o Conteúdo";
            allComentarios.Font = new Font(allComentarios.Font, FontStyle.Bold);
            allComentarios.Size = new Size(200, 30);
            allComentarios.Location = new Point(pnlContent.Width - 230, 390);
            allComentarios.BackColor = Color.White;
            allComentarios.FlatStyle = FlatStyle.Flat;
            allComentarios.FlatAppearance.BorderColor = Color.Black;
            allComentarios.Click += allComentarios_Click;
            pnlContent.Controls.Add(allComentarios);
        }
        public void enviarComentario_Click(object sender, EventArgs e)
        {
            //apos o user clicar no mentario em vez de dar clear a tudo como fazia antes mostrar o comentario ou seja dar clear dos buttons e das labels e dar print com o codigo do conteudo, nome do conteudo, user que comentou, comentario e data 
            string UserComentario = textUserComentario.Text;
            string idConteudo = txtIdConteudoComent.Text;
            string Comentario = ComentText.Text;
            string data = ComentDataText.Text;
            string idC = CommentId.Text;

            // Verificar se todos os campos foram preenchidos
            if (string.IsNullOrWhiteSpace(UserComentario) || string.IsNullOrWhiteSpace(idConteudo) ||
                string.IsNullOrWhiteSpace(Comentario) || string.IsNullOrWhiteSpace(data))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }
            DateTime duracao = DateTime.Parse(data);
            int id = int.Parse(idConteudo);
            int idComentário = int.Parse(idC);

            // Enviar os dados para o DataRepository
            bool sucesso = dataRepository.InserirComentario(UserComentario, Comentario, duracao, id,idComentário);

             if (sucesso)
             {
                 MessageBox.Show("Comentario criado com sucesso!");

            }
            else
             {
                 MessageBox.Show("Erro ao criar o Comentario. Por favor, tente novamente.");
             }


        }
        public void verComentarios_Click(object sender, EventArgs e)
        {
            // Limpar os dados do painel
            pnlContent.Controls.Clear();

            clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Size = new Size(80, 30);
            clearPnlContent.Location = new Point(pnlContent.Width - 100, pnlContent.Height - 50);
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);

            // Obter os utilizadores do DataRepository
             DataTable utilizadores = dataRepository.ListarComentario();

             // Criar uma DataGridView para exibir os utilizadores
             DataGridView dgvUtilizadores = new DataGridView();
             dgvUtilizadores.DataSource = utilizadores;
             dgvUtilizadores.Dock = DockStyle.Fill;
             pnlContent.Controls.Add(dgvUtilizadores);

        }
         public void allComentarios_Click(object sender, EventArgs e)
        {
            
            string idConteudo = CodigoC.Text;
            int id = int.Parse(idConteudo);
            // Limpar os dados do painel
            pnlContent.Controls.Clear();

            clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Size = new Size(80, 30);
            clearPnlContent.Location = new Point(pnlContent.Width - 100, pnlContent.Height - 50);
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);

            // Obter os utilizadores do DataRepository
             DataTable utilizadores = dataRepository.ListarUmComentario(id);

             // Criar uma DataGridView para exibir os utilizadores
             DataGridView dgvUtilizadores = new DataGridView();
             dgvUtilizadores.DataSource = utilizadores;
             dgvUtilizadores.Dock = DockStyle.Fill;
             pnlContent.Controls.Add(dgvUtilizadores);



        }

        //
        // Playlist 
        // 
        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            // Limpa os dados do painel 
            pnlContent.Controls.Clear();

            // Cria os controles para inserir os dados do utilizador
            Label lblNomeUser = new Label();
            lblNomeUser.Text = "Nome de Utilizador:";
            lblNomeUser.ForeColor = Color.White;
            lblNomeUser.Font = new Font(lblNomeUser.Font, FontStyle.Bold);
            lblNomeUser.Location = new Point(20, 10);
            lblNomeUser.Size = new Size(180, 30);
            pnlContent.Controls.Add(lblNomeUser);

            textUserPlaylistAutor = new TextBox();
            textUserPlaylistAutor.Location = new Point(200, 10);
            textUserPlaylistAutor.Size = new Size(450, 40);
            pnlContent.Controls.Add(textUserPlaylistAutor);

            Label TituloPlay = new Label();
            TituloPlay.Text = "Titulo PlayList:";
            TituloPlay.ForeColor = Color.White;
            TituloPlay.Font = new Font(TituloPlay.Font, FontStyle.Bold);
            TituloPlay.Location = new Point(20, 50);
            TituloPlay.Size = new Size(180, 30);
            pnlContent.Controls.Add(TituloPlay);

            txtTituloPlay = new TextBox();
            txtTituloPlay.Location = new Point(200, 50);
            txtTituloPlay.Size = new Size(450, 40);
            pnlContent.Controls.Add(txtTituloPlay);

            Label lblidPlayList = new Label();
            lblidPlayList.Text = "Id Playlist:";
            lblidPlayList.ForeColor = Color.White;
            lblidPlayList.Font = new Font(lblidPlayList.Font, FontStyle.Bold);
            lblidPlayList.Location = new Point(20, 90);
            lblidPlayList.Size = new Size(180, 30);
            pnlContent.Controls.Add(lblidPlayList);

            idPlayList = new TextBox();
            idPlayList.Location = new Point(200, 90);
            idPlayList.Size = new Size(450, 40);
            pnlContent.Controls.Add(idPlayList);

            Label lblEstadoPlayList = new Label();
            lblEstadoPlayList.Text = "Estado:";
            lblEstadoPlayList.ForeColor = Color.White;
            lblEstadoPlayList.Font = new Font(lblEstadoPlayList.Font, FontStyle.Bold);
            lblEstadoPlayList.Location = new Point(20, 130);
            lblEstadoPlayList.Size = new Size(180, 30);
            pnlContent.Controls.Add(lblEstadoPlayList);


            EstadoPlayList = new TextBox();
            EstadoPlayList.Location = new Point(200, 130);
            EstadoPlayList.Size = new Size(450, 40);
            pnlContent.Controls.Add(EstadoPlayList);


            Label TextCodigoP = new Label();
            TextCodigoP.Text = "A informação abaixo so é preenchida no caso do utilizador querer saber mais informações a cerca de alguma playlis, como por exemplo o conteudo, etc.";
            TextCodigoP.ForeColor = Color.White;
            TextCodigoP.Font = new Font(TextCodigoP.Font, FontStyle.Bold);
            TextCodigoP.Location = new Point(20, 350);
            TextCodigoP.Size = new Size(650, 30);
            pnlContent.Controls.Add(TextCodigoP);

            Label lblCodigoP = new Label();
            lblCodigoP.Text = "Codigo Playlist:";
            lblCodigoP.ForeColor = Color.White;
            lblCodigoP.Font = new Font(lblCodigoP.Font, FontStyle.Bold);
            lblCodigoP.Location = new Point(20, 390);
            lblCodigoP.Size = new Size(180, 30);
            pnlContent.Controls.Add(lblCodigoP);

            CodigoP = new TextBox();
            CodigoP.Location = new Point(200, 390);
            CodigoP.Size = new Size(450, 40);
            pnlContent.Controls.Add(CodigoP);


            Button enviarPlayList = new Button();
            enviarPlayList.Text = "Criar PlayList";
            enviarPlayList.Font = new Font(enviarPlayList.Font, FontStyle.Bold);
            enviarPlayList.Size = new Size(200, 30); // Ajusta o tamanho do botão
            enviarPlayList.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 130);
            enviarPlayList.BackColor = Color.White; // Define a cor de fundo como branco
            enviarPlayList.FlatStyle = FlatStyle.Flat;
            enviarPlayList.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            enviarPlayList.Click += enviarPlayList_Click;
            pnlContent.Controls.Add(enviarPlayList);

            Button verPlayList = new Button();
            verPlayList.Text = "Ver PlayLists Criadas";
            verPlayList.Font = new Font(verPlayList.Font, FontStyle.Bold);
            verPlayList.Size = new Size(200, 30); // Ajusta o tamanho do botão
            verPlayList.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 90);
            verPlayList.BackColor = Color.White; // Define a cor de fundo como branco
            verPlayList.FlatStyle = FlatStyle.Flat;
            verPlayList.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            verPlayList.Click += verPlayList_Click;
            pnlContent.Controls.Add(verPlayList);

            Button clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.Size = new Size(200, 30); // Ajusta o tamanho do botão
            clearPnlContent.Location = new Point(pnlContent.Width - 230, pnlContent.Height / 2 - 50);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);

            Button verPlayListCodigo = new Button();
            verPlayListCodigo.Text = "Ver Mais Sobre uma PlayList";
            verPlayListCodigo.Font = new Font(verPlayListCodigo.Font, FontStyle.Bold);
            verPlayListCodigo.Size = new Size(200, 30);
            verPlayListCodigo.Location = new Point(pnlContent.Width - 230, 390);
            verPlayListCodigo.BackColor = Color.White;
            verPlayListCodigo.FlatStyle = FlatStyle.Flat;
            verPlayListCodigo.FlatAppearance.BorderColor = Color.Black;
            verPlayListCodigo.Click += verPlayListCodigo_Click;
            pnlContent.Controls.Add(verPlayListCodigo);


        }
        public void enviarPlayList_Click(object sender, EventArgs e)
        {
            //apos o user clicar no criar em vez de dar clear a tudo como fazia antes mostrar a playlist ou seja dar clear dos buttons e das labels e dar print de uma tabela do comentario
            string UserPlaylistAutor = textUserPlaylistAutor.Text;
            string TituloPlayList = txtTituloPlay.Text;
            string CodigoPlayList = idPlayList.Text;
            string EstadoP = EstadoPlayList.Text;

            // Verificar se todos os campos foram preenchidos
           if (string.IsNullOrWhiteSpace(UserPlaylistAutor) || string.IsNullOrWhiteSpace(TituloPlayList) ||
                string.IsNullOrWhiteSpace(CodigoPlayList) || string.IsNullOrWhiteSpace(EstadoP))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            int CodigoP = int.Parse(CodigoPlayList);
            int EstadoP2 = int.Parse(EstadoP);
            int Num_Likes=0;

            bool sucesso = dataRepository.InserirPlayList(TituloPlayList, CodigoP,UserPlaylistAutor,Num_Likes,EstadoP2);


            if (sucesso)
            {
                MessageBox.Show("Playlist criada com sucesso.");
                LimparCamposPlaylist();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao criar a playlist.");
            }
        }
        public void verPlayList_Click(object sender, EventArgs e)
        {

            pnlContent.Controls.Clear();

            Button clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.BackColor = Color.White;
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black;
            clearPnlContent.Size = new Size(80, 30);
            clearPnlContent.Location = new Point(pnlContent.Width - 100, pnlContent.Height - 90);
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);

            // Retrieve playlists from the database
          DataTable playlists = dataRepository.ListarPlayList();

            // Create a DataGridView to display the playlists
            DataGridView dgvUtilizadores = new DataGridView();
            dgvUtilizadores.DataSource = playlists;
            dgvUtilizadores.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(dgvUtilizadores);
        }

        public void verPlayListCodigo_Click(object sender, EventArgs e){

            string codigoP = CodigoP.Text;

            int codigo = int.Parse(codigoP);

            if (string.IsNullOrWhiteSpace(codigoP))
            {
                MessageBox.Show("Por favor, preencha o campo para saber mais dados.");
                return;
            }


            pnlContent.Controls.Clear();

            Button clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.BackColor = Color.White;
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black;
            clearPnlContent.Size = new Size(80, 30);
            clearPnlContent.Location = new Point(pnlContent.Width - 100, pnlContent.Height - 90);
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);


            // Retrieve playlists from the database
            DataTable playlists2 = dataRepository.ListarConteudoPlaylist(codigo);

            // Create a DataGridView to display the playlists
            DataGridView dgvUtilizadores = new DataGridView();
            dgvUtilizadores.DataSource = playlists2;
            dgvUtilizadores.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(dgvUtilizadores);

        }

        
        public void LimparCamposPlaylist (){
            textUserPlaylistAutor.Text = "";
            txtTituloPlay.Text = "";
            idPlayList.Text = "";
            EstadoPlayList.Text = "";
        }

         //
        // Historico 
        // 
        private void btnHistorico_Click(object sender, EventArgs e)
        {
            // Limpar os dados do painel
            pnlContent.Controls.Clear();

            clearPnlContent = new Button();
            clearPnlContent.Text = "Close";
            clearPnlContent.Font = new Font(clearPnlContent.Font, FontStyle.Bold);
            clearPnlContent.BackColor = Color.White; // Define a cor de fundo como branco
            clearPnlContent.FlatStyle = FlatStyle.Flat;
            clearPnlContent.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            clearPnlContent.Size = new Size(80, 30);
            clearPnlContent.Location = new Point(pnlContent.Width - 100, pnlContent.Height - 50);
            clearPnlContent.Click += ClearPnlContent_Click;
            pnlContent.Controls.Add(clearPnlContent);

            // Obter os utilizadores do DataRepository
            DataTable utilizadores = dataRepository.ListaHistoricos();

            // Criar uma DataGridView para exibir os utilizadores
            DataGridView dgvUtilizadores = new DataGridView();
            dgvUtilizadores.DataSource = utilizadores;
            dgvUtilizadores.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(dgvUtilizadores);
        }

    

        // Limpar tudo botao close geral

        private void ClearPnlContent_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
        }
    }
}
