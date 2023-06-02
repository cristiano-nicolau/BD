	USE p5g2;
	GO

	

	CREATE SCHEMA Youtube;
	GO

	CREATE TABLE Youtube.Estados (
		state_id TINYINT PRIMARY KEY,
		state_name VARCHAR(20)
	);

	CREATE TABLE Youtube.Utilizador (
		Nome_Utilizador varchar(20) not null,
		Email varchar(20) not null,
		Senha varchar(15) not null,
		Nome varchar(20) not null,
		Data_de_Nascimento date not null,
		PRIMARY KEY(Nome_Utilizador)
	);
	GO

		CREATE TABLE Youtube.Premium (
		Data_de_Encerramento date not null,
		Valor_a_pagar FLOAT,
		Nome_Utilizador varchar(20) not null,
		Num_Meses int not null,
		IsPremium bit not null,
		PRIMARY KEY(Nome_Utilizador),
		FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador(Nome_Utilizador)
	);
	GO


	CREATE TABLE Youtube.Canal (
		Nome_Utilizador varchar(20) not null,
		Num_Subscritores int,
		Num_conteudo int,
		Descri��o_Canal varchar(600),
		Subscreve int,
		PRIMARY KEY(Nome_Utilizador),
		FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador(Nome_Utilizador)
	);
	GO

	CREATE TABLE Youtube.Conteudo (
		Titulo varchar(40) not null,
		Codigo int,
		Autor varchar(20) not null,
		Tipo varchar(20) not null,
		Estado varchar(20) not null,
		Dura��o time not null,
		Num_Likes int,
		Num_Visualiza��es int,
		Data_Publica��o date not null,
		UNIQUE(Codigo),
		PRIMARY KEY(Codigo),
		FOREIGN KEY (Autor) REFERENCES Youtube.Canal(Nome_Utilizador)
	);
	GO

	CREATE TABLE Youtube.Descric�o (
		Codigo int,
		Texto varchar(500),
		PRIMARY KEY (Codigo),
		FOREIGN KEY (Codigo) REFERENCES Youtube.Conte�do(Codigo),
	);
	GO

	CREATE TABLE Youtube.Playlist (
		Titulo varchar(30) not null,
		CodigoP int,
		Autor varchar(20) not null,
		Num_Likes int,
		Estado TINYINT,
		UNIQUE(CodigoP),
		PRIMARY KEY(CodigoP),
		FOREIGN KEY (Autor) REFERENCES Youtube.Utilizador(Nome_Utilizador),
		FOREIGN KEY (Estado) REFERENCES Youtube.Estados(state_id)
	);
	GO

CREATE TABLE Youtube.Coment�rios (
    CodigoComentario INT PRIMARY KEY,
    Autor VARCHAR(20) NOT NULL,
    Texto VARCHAR(300) NOT NULL,
    Data_Coment�rio DATE NOT NULL,
    Codigo INT NOT NULL,
    FOREIGN KEY (Autor) REFERENCES Youtube.Utilizador(Nome_Utilizador),
    FOREIGN KEY (Codigo) REFERENCES Youtube.Conte�do(Codigo)
);
	GO

	CREATE TABLE Youtube.Hist�rico (
		Titulo varchar(30) not null,
		Codigo int,
		Data_de_Visualiza��o date not null,
		Nome_Utilizador varchar(20) not null,
		PRIMARY KEY (Codigo),
		FOREIGN KEY (Codigo) REFERENCES Youtube.Conte�do(Codigo),
		FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador(Nome_Utilizador)
	);
	GO

	 CREATE TABLE Youtube.PlaylistVideo (
		PlaylistID int,
		VideoID int,
		PRIMARY KEY (PlaylistID, VideoID),
		FOREIGN KEY (PlaylistID) REFERENCES Youtube.Playlist(CodigoP),
		FOREIGN KEY (VideoID) REFERENCES Youtube.Conte�do(Codigo)
	);
	GO


	ALTER TABLE Youtube.Coment�rios ADD CONSTRAINT C�digoV FOREIGN KEY (C�digoV) REFERENCES Youtube.Conte�do(Codigo);



	 ALTER TABLE Youtube.Descri��o
	ADD CONSTRAINT FK_Descri��o_Conte�do FOREIGN KEY (Codigo) REFERENCES Youtube.Conte�do(Codigo);
	GO

	-- Add foreign key constraints to the 'Playlist' table
	ALTER TABLE Youtube.Playlist
	ADD CONSTRAINT FK_Playlist_Utilizador FOREIGN KEY (Autor) REFERENCES Youtube.Utilizador(Nome_Utilizador),
		CONSTRAINT FK_Playlist_Estados FOREIGN KEY (Estado) REFERENCES Youtube.Estados(state_id);
	GO

	-- Add foreign key constraints to the 'Coment�rios' table
	ALTER TABLE Youtube.Coment�rios
	ADD CONSTRAINT FK_Coment�rios_Utilizador FOREIGN KEY (Autor) REFERENCES Youtube.Utilizador(Nome_Utilizador),
		CONSTRAINT FK_Coment�rios_Conte�do FOREIGN KEY (C�digoV) REFERENCES Youtube.Conte�do(Codigo);
	GO

	-- Add foreign key constraints to the 'Hist�rico' table
	ALTER TABLE Youtube.Hist�rico
	ADD CONSTRAINT FK_Hist�rico_Conte�do FOREIGN KEY (Codigo) REFERENCES Youtube.Conte�do(Codigo),
		CONSTRAINT FK_Hist�rico_Utilizador FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador(Nome_Utilizador);
	GO

	


























