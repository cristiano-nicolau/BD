	USE p5g2;
	GO

	/*CREATE SCHEMA Youtube;
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




CREATE TRIGGER trg_UpdateLikes
ON Youtube.Conteúdo
AFTER INSERT
AS
BEGIN
    UPDATE c
    SET c.Num_Likes = c.Num_Likes + 1
    FROM Youtube.Conteúdo c
    INNER JOIN inserted i ON c.Codigo = i.Codigo;
END;


ALTER TRIGGER [Youtube].[trg_UpdateLikes]
ON [Youtube].[Conteúdo]
AFTER INSERT
AS
BEGIN
    DECLARE @code INT;
    SET @code = (SELECT Codigo FROM inserted);
    
    UPDATE c
    SET c.Num_Likes = c.Num_Likes + 1
    FROM Youtube.Conteúdo c
    WHERE c.Codigo = @code;
END;


CREATE FUNCTION Youtube.CalculatePlaylistDuration
(
    @PlaylistID INT
)
RETURNS TIME
AS
BEGIN
    DECLARE @TotalSeconds INT;

    SELECT @TotalSeconds = SUM(DATEPART(SECOND, c.Duracao)) +
                           SUM(DATEPART(MINUTE, c.Duracao)) * 60 +
                           SUM(DATEPART(HOUR, c.Duracao)) * 3600
    FROM Youtube.Conteúdo c
    INNER JOIN Youtube.PlaylistVideo pv ON c.Codigo = pv.VideoID
    WHERE pv.PlaylistID = @PlaylistID;

    DECLARE @TotalDuration TIME;
    SET @TotalDuration = DATEADD(SECOND, @TotalSeconds, '00:00:00');

    RETURN @TotalDuration;
END;



CREATE PROCEDURE Youtube.UpdateSubscribers
    @CanalName VARCHAR(20)
AS
BEGIN
    UPDATE Youtube.Canal
    SET Num_Subscritores = Num_Subscritores + 1
    WHERE Nome_Utilizador = @CanalName;
END;



CREATE PROCEDURE Youtube.UpdateSubscribers2
    @CanalName VARCHAR(20)
AS
BEGIN
    UPDATE Youtube.Canal
    SET Num_Subscritores = Num_Subscritores - 1
    WHERE Nome_Utilizador = @CanalName;
END;



CREATE PROCEDURE [Youtube].[CreateUtilizadorAndCanal]
    @Nome_Utilizador VARCHAR(20),
    @Email VARCHAR(20),
    @Senha VARCHAR(15),
    @Nome VARCHAR(20),
    @Nascimento DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Insert into Utilizador table
    INSERT INTO [Youtube].[Utilizador] (Nome_Utilizador, Email, Senha, Nome, Data_de_Nascimento)
    VALUES (@Nome_Utilizador, @Email, @Senha, @Nome, @Nascimento);

    -- Insert into Canal table
    INSERT INTO [Youtube].[Canal] (Nome_Utilizador, Num_Subscritores, Num_Conteudo, Descrição_Canal)
    VALUES (@Nome_Utilizador, 0, 0, '');
END;




CREATE PROCEDURE Youtube.DeletePlaylist
    @PlaylistID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Delete corresponding records from PlaylistVideo table
        DELETE FROM [Youtube].[PlaylistVideo] WHERE PlaylistID = @PlaylistID;

        -- Delete the playlist
        DELETE FROM [Youtube].[Playlist] WHERE CodigoP = @PlaylistID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW; -- Rethrow the error
    END CATCH;
END;


*/





















