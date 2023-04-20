
CREATE SCHEMA stock;
GO


ALTER TABLE stock.fornecedor DROP CONSTRAINT Tipo_For;
ALTER TABLE stock.encomenda DROP CONSTRAINT Enc_for; 
ALTER TABLE stock.item DROP CONSTRAINT item_num; 
ALTER TABLE stock.item DROP CONSTRAINT item_cod;


DROP TABLE stock.tipo_fornecedor;
DROP TABLE stock.fornecedor;
DROP TABLE stock.produto;
DROP TABLE stock.encomenda;
DROP TABLE stock.item;



CREATE TABLE stock.tipo_fornecedor(
	codigo		INT		NOT NULL,
	designacao		VarChar(20),

	PRIMARY KEY(codigo)
);


CREATE TABLE stock.fornecedor(
	nif					INT			NOT NULL,
	nome				VarChar(30)	NOT NULL,
	endereco			VarChar(40) NOT NULL,
	fax					INT,
	condpag				INT			NOT NULL,
	tipo				INT			NOT NULL,

	primary key (nif)
);

CREATE TABLE stock.produto(
	codigo		INT				NOT NULL,
	nome		VARCHAR(30)		NOT NULL,
	iva		DECIMAL(3,2)	NOT NULL,
	preco		Money			NOT NULL,
	unidades		INT				NOT NULL

	PRIMARY KEY(codigo)
);


CREATE TABLE stock.encomenda(
	[data]				DATE,
	numero				INT			NOT NULL,
	fornecedor			INT			NOT NULL,

	PRIMARY KEY(numero)
);



CREATE TABLE stock.item(
	unidades		INT		NOT NULL,
	numEnc			INT		NOT NULL,		
	codProd			INT		NOT NULL,
	
	
	PRIMARY KEY(codProd,numEnc)
);

ALTER TABLE stock.fornecedor ADD CONSTRAINT Tipo_For FOREIGN KEY (tipo) REFERENCES stock.tipo_fornecedor(codigo);
ALTER TABLE stock.encomenda ADD CONSTRAINT Enc_for FOREIGN KEY (fornecedor) REFERENCES stock.fornecedor(nif); 
ALTER TABLE stock.item ADD CONSTRAINT item_num FOREIGN KEY (numEnc) REFERENCES stock.encomenda(numEnc);
ALTER TABLE stock.item ADD CONSTRAINT item_cod FOREIGN KEY (codProd) REFERENCES stock.produto(codigo);


