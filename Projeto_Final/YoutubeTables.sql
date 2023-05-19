Use p5g2;
go


CREATE SCHEMA Youtube;
go


CREATE TABLE Youtube.Estado (



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
	Data_Visualização date not null,
		
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


	PRIMARY KEY(Autor),

);


CREATE TABLE Youtube.Histórico (

	Titulo varchar(30) not null,
	Codigo int,
	Data_de_Visualização date not null,
	Utilizador varchar(30) not null,

);


