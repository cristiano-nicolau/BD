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
        private Button btnComentario;
        private Button btnPlaylist;
        private Button btnHistorico;
        private Panel pnlContent;
        private Button enviarUser;
        private Button verUsers;
        private Button clearPnlContent;
        private Button enviarConteudo;
        private Button verConteudos;
        private DataRepository dataRepository;

        // Campos de texto para capturar os valores do utilizador
        private TextBox txtNomeUtilizador;
        private TextBox txtIdUser;
        private TextBox txtemail;
        private TextBox tstSenha;
        private TextBox txtNomeApelido;
        private TextBox txtNascimento;
        private TextBox txtLikes;
        
        
        // Campos de texto para capturar os valores do utilizador
        private TextBox TextoAutorConteudo;
        private TextBox TextoEstado;
        private TextBox TextoNumLikes;
        private TextBox TextoTipoConteudo;
        private TextBox TextTituloVideo;
        private TextBox textoDuracao;
        private TextBox textoDataPub;
        private TextBox textoNumVisualizacoes;
        private TextBox txtIdConteudo;

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
            btnUtilizadores.Size = new Size(this.Width / 5, 50);
            btnUtilizadores.Location = new Point(0, 0);
            btnUtilizadores.BackColor = Color.White; // Define a cor de fundo como branco
            btnUtilizadores.FlatStyle = FlatStyle.Flat;
            btnUtilizadores.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            btnUtilizadores.Click += btnUtilizadores_Click;
            this.Controls.Add(btnUtilizadores);

            btnConteudo = new Button();
            btnConteudo.Text = "Conteúdo";
            btnConteudo.Font = new Font(btnConteudo.Font, FontStyle.Bold);
            btnConteudo.Size = new Size(this.Width / 5, 50);
            btnConteudo.Location = new Point(btnUtilizadores.Right, 0);
            btnConteudo.BackColor = Color.White; // Define a cor de fundo como branco
            btnConteudo.FlatStyle = FlatStyle.Flat;
            btnConteudo.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            btnConteudo.Click += btnConteudo_Click;
            this.Controls.Add(btnConteudo);

            btnComentario = new Button();
            btnComentario.Text = "Comentário";
            btnComentario.Font = new Font(btnComentario.Font, FontStyle.Bold);
            btnComentario.Size = new Size(this.Width / 5, 50);
            btnComentario.Location = new Point(btnConteudo.Right, 0);
            btnComentario.BackColor = Color.White; // Define a cor de fundo como branco
            btnComentario.FlatStyle = FlatStyle.Flat;
            btnComentario.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            this.Controls.Add(btnComentario);

            btnPlaylist = new Button();
            btnPlaylist.Text = "Playlist";
            btnPlaylist.Font = new Font(btnPlaylist.Font, FontStyle.Bold);
            btnPlaylist.Size = new Size(this.Width / 5, 50);
            btnPlaylist.Location = new Point(btnComentario.Right, 0);
            btnPlaylist.BackColor = Color.White; // Define a cor de fundo como branco
            btnPlaylist.FlatStyle = FlatStyle.Flat;
            btnPlaylist.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            this.Controls.Add(btnPlaylist);

            btnHistorico = new Button();
            btnHistorico.Text = "Histórico";
            btnHistorico.Font = new Font(btnHistorico.Font, FontStyle.Bold);
            btnHistorico.Size = new Size(this.Width / 5, 50);
            btnHistorico.Location = new Point(btnPlaylist.Right, 0);
            btnHistorico.BackColor = Color.White; // Define a cor de fundo como branco
            btnHistorico.FlatStyle = FlatStyle.Flat;
            btnHistorico.FlatAppearance.BorderColor = Color.Black; // Define a cor da borda como preta
            this.Controls.Add(btnHistorico);

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
            lblNomeUtilizador.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblNomeUtilizador);

            txtNomeUtilizador = new TextBox();
            txtNomeUtilizador.Location = new Point(150, 10);
            txtNomeUtilizador.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtNomeUtilizador);

            Label lblIdUser = new Label();
            lblIdUser.Text = "Id Utilizador:";
            lblIdUser.ForeColor = Color.White;
            lblIdUser.Font = new Font(lblIdUser.Font, FontStyle.Bold);
            lblIdUser.Location = new Point(20, 50);
            lblIdUser.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblIdUser);

            txtIdUser = new TextBox();
            txtIdUser.Location = new Point(150, 50);
            txtIdUser.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtIdUser);

            Label lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.ForeColor = Color.White;
            lblEmail.Font = new Font(lblEmail.Font, FontStyle.Bold);
            lblEmail.Location = new Point(20, 90);
            lblEmail.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblEmail);

            txtemail = new TextBox();
            txtemail.Location = new Point(150, 90);
            txtemail.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtemail);

            Label lblSenha = new Label();
            lblSenha.Text = "Senha:";
            lblSenha.ForeColor = Color.White;
            lblSenha.Font = new Font(lblSenha.Font, FontStyle.Bold);
            lblSenha.Location = new Point(20, 130);
            lblSenha.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblSenha);

            tstSenha = new TextBox();
            tstSenha.Location = new Point(150, 130);
            tstSenha.Size = new Size(450, 40); 
            pnlContent.Controls.Add(tstSenha);

            Label lblNomeApelido = new Label();
            lblNomeApelido.Text = "Nome e Apelido:";
            lblNomeApelido.ForeColor = Color.White;
            lblNomeApelido.Font = new Font(lblNomeApelido.Font, FontStyle.Bold);
            lblNomeApelido.Location = new Point(20, 170);
            lblNomeApelido.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblNomeApelido);

            txtNomeApelido = new TextBox();
            txtNomeApelido.Location = new Point(150, 170);
            txtNomeApelido.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtNomeApelido);

            Label lblNascimento = new Label();
            lblNascimento.Text = "Data Nascimento:";
            lblNascimento.ForeColor = Color.White;
            lblNascimento.Font = new Font(lblNascimento.Font, FontStyle.Bold);
            lblNascimento.Location = new Point(20, 210);
            lblNascimento.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblNascimento);

            txtNascimento = new TextBox();
            txtNascimento.Location = new Point(150, 210);
            txtNascimento.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtNascimento);

            Label lblLikes = new Label();
            lblLikes.Text = "Nr Likes:";
            lblLikes.ForeColor = Color.White;
            lblLikes.Font = new Font(lblLikes.Font, FontStyle.Bold);
            lblLikes.Location = new Point(20, 250);
            lblLikes.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblLikes);

            txtLikes = new TextBox();
            txtLikes.Location = new Point(150, 250);
            txtLikes.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtLikes);

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

        private void EnviarUser_Click(object sender, EventArgs e)
        {
            // Obter os valores dos campos de texto
            string nomeUtilizador = txtNomeUtilizador.Text;
            string idUtilizador = txtIdUser.Text;
            string email = txtemail.Text;
            string senha = tstSenha.Text;
            string nomeApelido = txtNomeApelido.Text;
            string nascimento = txtNascimento.Text;
            string likes = txtLikes.Text;

            // Verificar se todos os campos foram preenchidos
            if (string.IsNullOrWhiteSpace(nomeUtilizador) || string.IsNullOrWhiteSpace(idUtilizador) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha) ||
                string.IsNullOrWhiteSpace(nomeApelido) || string.IsNullOrWhiteSpace(nascimento) ||
                string.IsNullOrWhiteSpace(likes))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            // Enviar os dados para o DataRepository
            bool sucesso = dataRepository.InserirUtilizador(nomeUtilizador, idUtilizador, email, senha, nomeApelido, nascimento, likes);

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

            // Obter os utilizadores do DataRepository
            DataTable utilizadores = dataRepository.ListarUtilizadores();

            // Criar uma DataGridView para exibir os utilizadores
            DataGridView dgvUtilizadores = new DataGridView();
            dgvUtilizadores.DataSource = utilizadores;
            dgvUtilizadores.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(dgvUtilizadores);

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
        }
        private void LimparCamposUtilizador()
        {
            txtNomeUtilizador.Text = string.Empty;
            txtIdUser.Text = string.Empty;
            txtemail.Text = string.Empty;
            tstSenha.Text = string.Empty;
            txtNomeApelido.Text = string.Empty;
            txtNascimento.Text = string.Empty;
            txtLikes.Text = string.Empty;
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
            lblTituloConteudo.Text = "Nome de Utilizador:";
            lblTituloConteudo.ForeColor = Color.White;
            lblTituloConteudo.Font = new Font(lblTituloConteudo.Font, FontStyle.Bold);
            lblTituloConteudo.Location = new Point(20, 10);
            lblTituloConteudo.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblTituloConteudo);

            TextTituloVideo = new TextBox();
            TextTituloVideo.Location = new Point(150, 10);
            TextTituloVideo.Size = new Size(450, 40); 
            pnlContent.Controls.Add(TextTituloVideo);

            Label IdConteudo = new Label();
            IdConteudo.Text = "Id Utilizador:";
            IdConteudo.ForeColor = Color.White;
            IdConteudo.Font = new Font(IdConteudo.Font, FontStyle.Bold);
            IdConteudo.Location = new Point(20, 50);
            IdConteudo.Size = new Size(200, 30); 
            pnlContent.Controls.Add(IdConteudo);

            txtIdConteudo = new TextBox();
            txtIdConteudo.Location = new Point(150, 50);
            txtIdConteudo.Size = new Size(450, 40); 
            pnlContent.Controls.Add(txtIdConteudo);

            Label AutorConteudo = new Label();
            AutorConteudo.Text = "Email:";
            AutorConteudo.ForeColor = Color.White;
            AutorConteudo.Font = new Font(AutorConteudo.Font, FontStyle.Bold);
            AutorConteudo.Location = new Point(20, 90);
            AutorConteudo.Size = new Size(200, 30); 
            pnlContent.Controls.Add(AutorConteudo);

            TextoAutorConteudo = new TextBox();
            TextoAutorConteudo.Location = new Point(150, 90);
            TextoAutorConteudo.Size = new Size(450, 40); 
            pnlContent.Controls.Add(TextoAutorConteudo);

            Label TipoConteudo = new Label();
            TipoConteudo.Text = "Senha:";
            TipoConteudo.ForeColor = Color.White;
            TipoConteudo.Font = new Font(TipoConteudo.Font, FontStyle.Bold);
            TipoConteudo.Location = new Point(20, 130);
            TipoConteudo.Size = new Size(200, 30); 
            pnlContent.Controls.Add(TipoConteudo);

            TextoTipoConteudo = new TextBox();
            TextoTipoConteudo.Location = new Point(150, 130);
            TextoTipoConteudo.Size = new Size(450, 40); 
            pnlContent.Controls.Add(TextoTipoConteudo);

            Label lblEstado = new Label();
            lblEstado.Text = "Nome e Apelido:";
            lblEstado.ForeColor = Color.White;
            lblEstado.Font = new Font(lblEstado.Font, FontStyle.Bold);
            lblEstado.Location = new Point(20, 170);
            lblEstado.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblEstado);

            TextoEstado = new TextBox();
            TextoEstado.Location = new Point(150, 170);
            TextoEstado.Size = new Size(450, 40); 
            pnlContent.Controls.Add(TextoEstado);

            Label lblDuracao = new Label();
            lblDuracao.Text = "Data Nascimento:";
            lblDuracao.ForeColor = Color.White;
            lblDuracao.Font = new Font(lblDuracao.Font, FontStyle.Bold);
            lblDuracao.Location = new Point(20, 210);
            lblDuracao.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblDuracao);

            textoDuracao = new TextBox();
            textoDuracao.Location = new Point(150, 210);
            textoDuracao.Size = new Size(450, 40); 
            pnlContent.Controls.Add(textoDuracao);

            Label lblNumLikes = new Label();
            lblNumLikes.Text = "Nr Likes:";
            lblNumLikes.ForeColor = Color.White;
            lblNumLikes.Font = new Font(lblNumLikes.Font, FontStyle.Bold);
            lblNumLikes.Location = new Point(20, 250);
            lblNumLikes.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblNumLikes);

            TextoNumLikes = new TextBox();
            TextoNumLikes.Location = new Point(150, 250);
            TextoNumLikes.Size = new Size(450, 40); 
            pnlContent.Controls.Add(TextoNumLikes);

            Label lblNumVisualizacoes = new Label();
            lblNumVisualizacoes.Text = "Nr Views:";
            lblNumVisualizacoes.ForeColor = Color.White;
            lblNumVisualizacoes.Font = new Font(lblNumVisualizacoes.Font, FontStyle.Bold);
            lblNumVisualizacoes.Location = new Point(20, 290);
            lblNumVisualizacoes.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblNumVisualizacoes);

            textoNumVisualizacoes = new TextBox();
            textoNumVisualizacoes.Location = new Point(150, 290);
            textoNumVisualizacoes.Size = new Size(450, 40); 
            pnlContent.Controls.Add(textoNumVisualizacoes);

            Label lblDataPub = new Label();
            lblDataPub.Text = "Publicado:";
            lblDataPub.ForeColor = Color.White;
            lblDataPub.Font = new Font(lblDataPub.Font, FontStyle.Bold);
            lblDataPub.Location = new Point(20, 330);
            lblDataPub.Size = new Size(200, 30); 
            pnlContent.Controls.Add(lblDataPub);

            textoDataPub = new TextBox();
            textoDataPub.Location = new Point(150, 330);
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

            // Enviar os dados para o DataRepository
          /*  bool sucesso = dataRepository.InseriConteudo(tipoConteudo, idConteudo, EstadoConteudo, ViewsConteudo, pubConteudo, DuracaoConteudo, AutorConteudo, TituloConteudo, likesConteudo);

            if (sucesso)
            {
                MessageBox.Show("Utilizador criado com sucesso!");
                LimparCamposUtilizador();
            }
            else
            {
                MessageBox.Show("Erro ao criar o utilizador. Por favor, tente novamente.");
            }

            */
        }
        public void verConteudos_Click (object sender, EventArgs e){ 
             // Limpar os dados do painel
            pnlContent.Controls.Clear();



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

        // Limpar tudo botao close geral

        private void ClearPnlContent_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
        }
    }
}
