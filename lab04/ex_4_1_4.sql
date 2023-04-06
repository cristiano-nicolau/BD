use p5g2
go

CREATE SCHEMA Medicamento;
go

DROP TABLE Medicamento.Especialidade;
DROP TABLE Medicamento.Medico;
DROP TABLE Medicamento.Paciente;
DROP TABLE Medicamento.Farmacia;
DROP TABLE Medicamento.Farmacos;
DROP TABLE Medicamento.Prescricao;
DROP TABLE Medicamento.CompanhiaFarmaceutica;
DROP TABLE Medicamento.ProduzirMedicamentos;
DROP TABLE Medicamento.Venda;

CREATE TABLE Medicamento.Especialidade(
	tipoEspecialidade				VARCHAR(30)		NOT NULL,	
	codigo							INT				NOT NULL,
	PRIMARY KEY(codigo) 
);

CREATE TABLE Medicamento.Medico (
	n_id							INT				NOT NULL,
	Nome							VARCHAR(30)		NOT NULL,
	codigoEspecialidade				INT				NOT NULL,
	PRIMARY KEY(n_id),
	FOREIGN KEY(codigoEspecialidade) REFERENCES	Medicamento.Especialidade(codigo));


CREATE TABLE Medicamento.Paciente(
	DataNasc						DATE				NOT NULL,
	endereco						VARCHAR(20), 
	Nome							VARCHAR(30)			NOT NULL,
	N_utente						INT					NOT NULL,
	PRIMARY KEY(N_utente),
);


CREATE TABLE Medicamento.Farmacia (
	Telefone						INT					NOT NULL,
	Endereco						VARCHAR(30),	
	Nome							INT 				NOT NULL,
	F_NIF							INT					NOT NULL,
	PRIMARY KEY(F_NIF),
	); 

CREATE TABLE Medicamento.Farmacos(
	Nome_comercial					VARCHAR(20)			NOT NULL,
	Formula							VARCHAR(20) 		NOT NULL,
	PRIMARY KEY(Formula),
);

CREATE TABLE Medicamento.Prescricao(
	Dataa							DATE,				 
	n_prescricao					INT					NOT NULL,
	Medico_responsavel				INT,
	Farmacia						INT,
	Paciente						INT,
	Farmacos						VARCHAR(20),
	PRIMARY KEY(n_prescricao),
	FOREIGN KEY(Medico_responsavel)	REFERENCES Medicamento.Medico(n_id),
	FOREIGN KEY(Farmacia)	REFERENCES Medicamento.Farmacia(F_NIF),
	FOREIGN KEY(Paciente)	REFERENCES Medicamento.Paciente(N_utente),
	FOREIGN KEY(Farmacos)	REFERENCES Medicamento.Farmacos(Formula));



CREATE TABLE Medicamento.CompanhiaFarmaceutica(
	N_Registo_nacional				INT					NOT NULL,
	Nome							VARCHAR(20),
	Telefone						INT					NOT NULL,
	PRIMARY KEY(N_Registo_Nacional),
);

CREATE TABLE Medicamento.ProduzirMedicamentos(
	companhia_farmaceutica			INT					NOT NULL,
	medicamentos					VARCHAR(20)			NOT NULL,
	PRIMARY KEY (companhia_farmaceutica, medicamentos),
	FOREIGN KEY(companhia_farmaceutica)		REFERENCES	Medicamento.CompanhiaFarmaceutica(N_Registo_nacional),
	FOREIGN KEY(medicamentos)				REFERENCES Medicamento.Farmacos(Formula));


CREATE TABLE Medicamento.Venda(
	Farmacia						INT					NOT NULL,
	Produtos						VARCHAR(20)			NOT NULL,
	PRIMARY KEY (Farmacia, Produtos),
	FOREIGN KEY(Farmacia)	REFERENCES	Medicamento.Farmacia(F_NIF),
	FOREIGN KEY(Produtos)	REFERENCES  Medicamento.Farmacos(Formula));

