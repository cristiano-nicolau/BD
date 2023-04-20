CREATE SCHEMA Prescrições
go

ALTER TABLE Prescrições.Farmaco DROP CONSTRAINT Farmaco_numRegFarm;
AlTER TABLE Prescrições.prescrição DROP CONSTRAINT Prescrição_Utente;
ALTER TABLE Prescrições.prescrição DROP CONSTRAINT Prescrição_Medico;
AlTER TABLE Prescrições.prescrição DROP CONSTRAINT Prescrição_Farmacia;
ALTER TABLE Prescrições.presc_farmaco	DROP CONSTRAINT Presc_num;
ALTER TABLE Prescrições.presc_farmaco	DROP CONSTRAINT  Presc_numfarm;
ALTER TABLE Prescrições.presc_farmaco DROP CONSTRAINT Presc_farmaco;


DROP TABLE Prescrições.Medico;
DROP TABLE Prescrições.Paciente;
DROP TABLE Prescrições.Farmacia;
DROP TABLE Prescriçóes.Farmaceutica;
DROP TABLE Prescrições.Farmaco;
DROP TABLE Prescrições.prescrição;
DROP TABLE Prescrições.presc_farmaco;



CREATE TABLE Prescrições.Medico(

	numSNS	INT NOT NULL,
	Nome	VARCHAR(20) NOT NULL,
	Especialidade VARCHAR(20) NOT NULL,

	PRIMARY KEY (numSNS)

	);

		

CREATE TABLE Prescrições.Paciente(
		
		numUtente	INT	NOT NULL,
		Nome	VARCHAR(20)	NOT NULL,
		DataNasc DATE ,
		Endereço VARCHAR(30) NOT NULL,

		PRIMARY KEY (numUtente)

		);

CREATE TABLE Prescrições.Farmacia(

		Nome	VARCHAR(20) NOT NULL,
		Telefone CHAR(9) NOT NULL,
		Endereço	VARCHAR(30) NOT NULL,

		PRIMARY KEY (Nome)

		);

CREATE TABLE Prescrições.Farmaceutica(

		numReg	INT NOT NULL,
		Nome	VARCHAR(20) NOT NULL,
		Endereço VARCHAR(30) NOT NULL,

		PRIMARY KEY (numReg)
		
		);

CREATE TABLE Prescrições.Farmaco(

		numRegFarm	INT NOT NULL,
		nome	VARCHAR(20)	NOT NULL,
		formula VARCHAR(30) NOT NULL,

		PRIMARY KEY(nome)

		);


CREATE TABLE Prescrições.prescrição(

		numPresc INT NOT NULL,
		numUtente INT NOT NULL,
		numMedico	INT NOT NULL,
		farmacia VARCHAR(20),
		dataProc DATE ,

		PRIMARY KEY (numPresc)

		);


CREATE TABLE Prescrições.presc_farmaco(

		numPresc	INT NOT NULL,
		numRegFarm	INT NOT NULL,
		nomeFarmaco	VARCHAR(20) NOT NULL,

		PRIMARY KEY (numPresc)

		);


ALTER TABLE Prescriçóes.Farmaco ADD CONSTRAINT Farmaco_numRegFarm FOREIGN KEY (numRegFarm) REFERENCES Prescrições.Farmaceutica(numReg); 
AlTER TABLE Prescrições.prescrição ADD CONSTRAINT Prescrição_Utente FOREIGN KEY (numUtente) REFERENCES Prescrições.Paciente(numUtente);
ALTER TABLE Prescrições.prescrição ADD CONSTRAINT Prescrição_Medico FOREIGN KEY (numMedico) REFERENCES Prescrições.Medico(numSNS);
AlTER TABLE Prescrições.prescrição ADD CONSTRAINT Prescrição_Farmacia FOREIGN KEY (farmacia) REFERENCES Prescrições.Farmacia(Nome);
ALTER TABLE Prescrições.presc_farmaco ADD CONSTRAINT Presc_num FOREIGN KEY (numPresc) REFERENCES Prescriçõe.prescrição(numPresc);
ALTER TABLE Prescrições.presc_farmaco ADD CONSTRAINT Presc_numfarm FOREIGN KEY (numRegFarm) REFERENCES Prescrição.Farmaco(numRegFarm);
ALTER TABLE Prescrições.presc_farmaco ADD CONSTRAINT Presc_farmaco FOREIGN KEY (nomeFarmaco) REFERENCES Prescrição.Farmaco(nome);







