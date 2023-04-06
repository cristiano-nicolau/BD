USE p5g2;
go

CREATE SCHEMA GestaoATL;
go


DROP TABLE GestaoATL.Atividades;
DROP TABLE GestaoATL.Enc_Edcucacao;
DROP TABLE GestaoATL.Pessoa;
DROP TABLE GestaoATL.Professor;
DROP TABLE GestaoATL.Aluno;
DROP TABLE GestaoATL.Turma;
DROP TABLE GestaoATL.P_Autorizada;

CREATE TABLE GestaoATL.Atividades (

	Custo		INT,
	Designacao	VARCHAR(30),
	Identificador INT,
	Turma_Identificador	INT,
	Aluno_Pessoa_NumCC	VARCHAR(9),

	PRIMARY KEY (Identificador)


	);


CREATE TABLE GestaoATL.Turma (

	AnoLetivo   INT,
	NumMaxAlunos INT not null,
	Designacao	VARCHAR(30),
	Identificador	INT,
	Professor_Numfunc	INT,
	Atividades_Identificador	INT,

	PRIMARY KEY (Identificador),
	FOREIGN KEY (Atividades_Identificador) REFERENCES GestaoATL.Atividades(Identificador)

	);

CREATE TABLE GestaoATL.Pessoa (

	Nome VARCHAR(30),
	NumCC VARCHAR(9),
	Morada VARCHAR(30),
	DataNasc date,

	PRIMARY KEY (NumCC)

	);

CREATE TABLE GestaoATL.Aluno (

	NumCC VARCHAR(9),
	Turma_Identificador INT,
	Atividades_Identificador INT,


	PRIMARY KEY (NumCC),
	FOREIGN KEY (Atividades_Identificador) REFERENCES GestaoATL.Atividades(Identificador),
	FOREIGN KEY (Turma_Identificador) REFERENCES GestaoATL.Turma(Identificador),
	FOREIGN KEY (NumCC) REFERENCES GestaoATL.Pessoa(NumCC)
	
	
	);

CREATE TABLE GestaoATL.Professor (

	NumFunc INT,
	Telemovel VARCHAR(9),
	Email	VARCHAR(30),
	Turma_Identificador	INT,
	NumCC	VARCHAR(9),

	PRIMARY KEY (NumFunc),
	FOREIGN KEY (Turma_Identificador) REFERENCES GestaoATL.Turma(Identificador),
	FOREIGN KEY (NumCC) REFERENCES GestaoATL.Pessoa(NumCC)

	);



CREATE TABLE GestaoATL.P_Autorizada (

	NumCC	VARCHAR(9),

	PRIMARY KEY (NumCC),
	FOREIGN KEY (NumCC) REFERENCES GestaoATL.Aluno(NumCC)

	);



CREATE TABLE GestaoATL.Enc_Educacao (

	NumCC	VARCHAR(9),
	RelacaoAluno VARCHAR(30),
	Telemovel	VARCHAR(9),
	Email	VARCHAR(30),
	NumCC_Aluno VARCHAR(9),

	PRIMARY KEY (NumCC),
	FOREIGN KEY (NumCC) REFERENCES GestaoATL.Pessoa(NumCC),
	FOREIGN KEY (NumCC_Aluno) REFERENCES GestaoATL.P_Autorizada(NumCC)

	);

	









