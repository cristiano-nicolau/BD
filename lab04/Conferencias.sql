USE p5g2;
go

CREATE SCHEMA Conferencia;
go

CREATE TABLE Conferencia.Participante (
	
	Nome VARCHAR(30),
	Morada	VARCHAR(30),
	Email	VARCHAR(30),
	Instituição	VARCHAR(30),
	DataInscrição	date,

	PRIMARY KEY (Nome),


	);
	GO
CREATE TABLE Conferencia.Instituicao(

	Nome	VARCHAR(30),
	Endereço	VARCHAR(40),

	PRIMARY KEY (Nome),

	);
	GO

CREATE TABLE Conferencia.Artigo (
	
	Titulo VARCHAR(30),
	Num_Registo	INT,

	PRIMARY KEY(Num_Registo),

	);
	GO
CREATE TABLE Conferencia.Estudante (

	Nome VARCHAR(30),
	Comprovativo	VARCHAR(30)

	PRIMARY KEY (Nome),
	 FOREIGN KEY (Nome) REFERENCES Conferencia.Participante(Nome),
	);
	GO
CREATE TABLE Conferencia.Nestudante (

	Nome	VARCHAR(30),
	Comprovativo	VARCHAR(30)

	PRIMARY KEY (Nome),
	FOREIGN KEY (Nome) REFERENCES Conferencia.Participante(Nome),
);	
GO
CREATE TABLE Conferencia.Pessoa (

	Nome	VARCHAR(30) NOT NULL,
	Código INT,
	Email	VARCHAR(30),
	Instituicao	VARCHAR(30),

	PRIMARY KEY	(Nome),
	FOREIGN KEY (Instituicao) REFERENCES Conferencia.Instituicao(Nome),
	);
GO
CREATE TABLE Conferencia.Autor (

	
	Nome	VARCHAR(30),
	N_registo	INT,
	Titulo	VARCHAR(30),
	Num_Artigo	INT,

	PRIMARY KEY (N_registo),
	FOREIGN KEY (Num_Artigo) REFERENCES Conferencia.Artigo(Num_registo),
	FOREIGN KEY (Nome) REFERENCES Conferencia.Pessoa(Nome),
	);
GO






