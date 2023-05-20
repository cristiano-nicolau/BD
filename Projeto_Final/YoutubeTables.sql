Use p5g2;
go


CREATE SCHEMA Youtube;
go


CREATE TABLE Youtube.Estados (

	state_id TINYINT PRIMARY KEY,
	state_name VARCHAR(20),

);



CREATE TABLE Youtube.Utilizador (

	Nome_Utilizador varchar(20) not null,
	Email varchar(20) not null,
	Senha varchar(15) not null,
	Nome varchar(20) not null,
	Data_de_Nascimento date not null,


	PRIMARY KEY(Nome_Utilizador),

);
go


CREATE TABLE Youtube.Premium (

	Data_de_Encerramento  date not null,
	Valor_a_pagar  FLOAT,
	Nome_Utilizador varchar(20) not null,


	PRIMARY KEY(Nome_Utilizador),
);
go

CREATE TABLE Youtube.Canal (

	Nome_Utilizador varchar(20) not null,
	Num_Subscritores int,
	Num_conteudo int, 
	Descrição_Canal varchar(600),
	Subscreve int ,

	PRIMARY KEY(Nome_Utilizador),

);
go


CREATE TABLE Youtube.Conteúdo (

	Titulo varchar(40) not null,
	Codigo int,
	Autor varchar(20) not null,
	Tipo varchar(20) not null,
	Estado varchar(20) not null,
	Duração time not null,
	Num_Likes int,
	Num_Visualizações int,
	Data_Publicação date not null,
		
	UNIQUE(codigo),

	PRIMARY KEY(Codigo),

);


CREATE TABLE Youtube.Descrição (

	Codigo int,
	Texto varchar(500),
	Num_Likes int,
	Num_Visualizações int, 
	Data_Publicação date not null,

	PRIMARY KEY (Codigo),

);
go


CREATE TABLE Youtube.Playlist(

	Titulo varchar(30) not null,
	CodigoP int,
	Autor varchar(30) not null,
	Num_Likes int,
	Estado varchar(10) not null,

	UNIQUE(CodigoP),

	PRIMARY KEY(CodigoP),

);


CREATE TABLE Youtube.Comentários (

	Autor varchar(30) not null,
	Texto varchar(300) not null,
	Data_Comentário date not null,


	PRIMARY KEY(Autor),

);


CREATE TABLE Youtube.Histórico (

	Titulo varchar(30) not null,
	Codigo int,
	Data_de_Visualização date not null,
	Nome_Utilizador varchar(30) not null,

	PRIMARY KEY (Codigo),

);


ALTER TABLE Youtube.Canal ADD CONSTRAINT Nome_Utilizador FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador;

ALTER TABLE Youtube.Conteúdo ADD CONSTRAINT Autor FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Canal;

ALTER TABLE Youtube.Descrição ADD CONSTRAINT Codigo FOREIGN KEY (Codigo) REFERENCES Youtube.Conteudo;

ALTER TABLE Youtube.Descrição ADD CONSTRAINT Num_Likes FOREIGN KEY (Num_Likes) REFERENCES Youtube.Conteudo;

ALTER TABLE Youtube.Descrição ADD CONSTRAINT Num_Visualizações FOREIGN KEY (Num_Visualizações) REFERENCES Youtube.Conteudo;

ALTER TABLE Youtube.Descrição ADD CONSTRAINT Data_Publicação FOREIGN KEY (Data_Publicação) REFERENCES Youtube.Conteudo;

ALTER TABLE Youtube.Playlist ADD CONSTRAINT Autor FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador;

ALTER TABLE Youtube.Playlist ADD CONSTRAINT Estado FOREIGN KEY (state_id) REFERENCES Youtube.Estados;

ALTER TABLE Youtube.Comentários ADD CONSTRAINT Autor FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador;

ALTER TABLE Youtube.Histórico ADD CONSTRAINT Codigo FOREIGN KEY (Codigo) REFERENCES Youtube.Conteudo;

ALTER TABLE Youtube.Histórico ADD CONSTRAINT Nome_Utilizador FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador;





INSERT INTO Youtube.Estados (state_id, state_name) VALUES (0,'Private'), (1,'Public');




