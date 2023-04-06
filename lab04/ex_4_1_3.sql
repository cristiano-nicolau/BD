USE p5g2;
GO

CREATE SCHEMA Stockss;
GO


CREATE TABLE Stockss.Produto(
	Nome			varchar(20) NOT NULL,
	Preco			int NOT NULL,
	IVA			int NOT NULL,
	Codigo		int NOT NULL,
	Arm_Quan_Pr	int,
	PRIMARY KEY(Codigo),
	);
GO


CREATE TABLE Stockss.Armazem(
	Codigo	int NOT NULL PRIMARY KEY,
	Morada varchar(20) NOT NULL,
	ProdutoCodigo	int NOT NULL,
	FOREIGN KEY(ProdutoCodigo) REFERENCES Stockss.Produto(Codigo),
);
GO


CREATE TABLE Stockss.Fornecedor(
	Nome			varchar(20) NOT NULL,
	NIF	varchar(50) NOT NULL,
	Endereco		varchar(50) NOT NULL,
	Codigo	int NOT NULL,
	Fax			varchar(20) NOT NULL,
	Pagamento		int NOT NULL UNIQUE,
	PRIMARY KEY(Codigo),
);
GO
CREATE TABLE Stockss.Encomenda(
	Num_Encomenda	int NOT NULL PRIMARY KEY,
	DataEncomenda date NOT NULL,
	Quantidade int NOT NULL,
	Codigo_Fornecedor	int NOT NULL ,
	Produto_Codigo int NOT NULL,
	FOREIGN KEY (Codigo_Fornecedor) REFERENCES Stockss.Fornecedor(Codigo),
	FOREIGN KEY (Produto_Codigo) REFERENCES Stockss.Produto(Codigo)
);
GO


CREATE TABLE Stockss.CondPagamento(
	Prazo date NOT NULL,
	Codigo int NOT NULL PRIMARY KEY,
	Pagamento	int NOT NULL, 
	FOREIGN KEY  (Codigo) REFERENCES Stockss.Fornecedor(Pagamento)
);
GO