	USE p5g2;
	GO

	/*

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
		Descrição_Canal varchar(600),
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
		Duração time not null,
		Num_Likes int,
		Num_Visualizações int,
		Data_Publicação date not null,
		UNIQUE(Codigo),
		PRIMARY KEY(Codigo),
		FOREIGN KEY (Autor) REFERENCES Youtube.Canal(Nome_Utilizador)
	);
	GO

	CREATE TABLE Youtube.Descricão (
		Codigo int,
		Texto varchar(500),
		PRIMARY KEY (Codigo),
		FOREIGN KEY (Codigo) REFERENCES Youtube.Conteúdo(Codigo),
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

CREATE TABLE Youtube.Comentários (
    CodigoComentario INT PRIMARY KEY,
    Autor VARCHAR(20) NOT NULL,
    Texto VARCHAR(300) NOT NULL,
    Data_Comentário DATE NOT NULL,
    Codigo INT NOT NULL,
    FOREIGN KEY (Autor) REFERENCES Youtube.Utilizador(Nome_Utilizador),
    FOREIGN KEY (Codigo) REFERENCES Youtube.Conteúdo(Codigo)
);
	GO

	CREATE TABLE Youtube.Histórico (
		Titulo varchar(30) not null,
		Codigo int,
		Data_de_Visualização date not null,
		Nome_Utilizador varchar(20) not null,
		PRIMARY KEY (Codigo),
		FOREIGN KEY (Codigo) REFERENCES Youtube.Conteúdo(Codigo),
		FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador(Nome_Utilizador)
	);
	GO

	 CREATE TABLE Youtube.PlaylistVideo (
		PlaylistID int,
		VideoID int,
		PRIMARY KEY (PlaylistID, VideoID),
		FOREIGN KEY (PlaylistID) REFERENCES Youtube.Playlist(CodigoP),
		FOREIGN KEY (VideoID) REFERENCES Youtube.Conteúdo(Codigo)
	);
	GO


	ALTER TABLE Youtube.Comentários ADD CONSTRAINT CódigoV FOREIGN KEY (CódigoV) REFERENCES Youtube.Conteúdo(Codigo);



	 ALTER TABLE Youtube.Descrição
	ADD CONSTRAINT FK_Descrição_Conteúdo FOREIGN KEY (Codigo) REFERENCES Youtube.Conteúdo(Codigo);
	GO

	-- Add foreign key constraints to the 'Playlist' table
	ALTER TABLE Youtube.Playlist
	ADD CONSTRAINT FK_Playlist_Utilizador FOREIGN KEY (Autor) REFERENCES Youtube.Utilizador(Nome_Utilizador),
		CONSTRAINT FK_Playlist_Estados FOREIGN KEY (Estado) REFERENCES Youtube.Estados(state_id);
	GO

	-- Add foreign key constraints to the 'Comentários' table
	ALTER TABLE Youtube.Comentários
	ADD CONSTRAINT FK_Comentários_Utilizador FOREIGN KEY (Autor) REFERENCES Youtube.Utilizador(Nome_Utilizador),
		CONSTRAINT FK_Comentários_Conteúdo FOREIGN KEY (CódigoV) REFERENCES Youtube.Conteúdo(Codigo);
	GO

	-- Add foreign key constraints to the 'Histórico' table
	ALTER TABLE Youtube.Histórico
	ADD CONSTRAINT FK_Histórico_Conteúdo FOREIGN KEY (Codigo) REFERENCES Youtube.Conteúdo(Codigo),
		CONSTRAINT FK_Histórico_Utilizador FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador(Nome_Utilizador);
	GO

	*/



CREATE TRIGGER SetPremiumStatus
ON Youtube.Premium
AFTER INSERT
AS
BEGIN
    DECLARE @Nome_Utilizador varchar(20);
    DECLARE @Num_Meses int;
    DECLARE @Data_Encerramento date;
    DECLARE @Valor_a_Pagar float;

    -- Retrieve the necessary information from the inserted row
    SELECT @Nome_Utilizador = Nome_Utilizador, @Num_Meses = Num_Meses
    FROM inserted;

    -- Calculate the expiration date by adding the specified number of months to the current date
    SET @Data_Encerramento = DATEADD(MONTH, @Num_Meses, GETDATE());

    -- Calculate the value to be paid
    SET @Valor_a_Pagar = @Num_Meses * 9.99;

    -- Update the Premium table with the calculated values
    UPDATE Youtube.Premium
    SET Data_de_Encerramento = @Data_Encerramento,
        Valor_a_pagar = @Valor_a_Pagar
    WHERE Nome_Utilizador = @Nome_Utilizador;

    -- Update the IsPremium column based on the number of months
    UPDATE Youtube.Premium
    SET IsPremium = 1
    WHERE Nome_Utilizador = @Nome_Utilizador AND @Num_Meses > 0;

    UPDATE Youtube.Premium
    SET IsPremium = 0
    WHERE Nome_Utilizador = @Nome_Utilizador AND @Num_Meses <= 0;
END;




























