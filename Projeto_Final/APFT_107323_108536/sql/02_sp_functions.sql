USE p5g2;
go;

/* /////////////////////////////////////////////////  


				Functions


/////////////////////////////////////////////////   */



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


/* /////////////////////////////////////////////////  */


CREATE FUNCTION Youtube.CheckCredentials (@NomeUtilizador varchar(100), @Senha varchar(100))
RETURNS bit
AS
BEGIN
    DECLARE @Exists bit;
    SET @Exists = (
        SELECT CASE WHEN EXISTS (
            SELECT 1 FROM [p5g2].[Youtube].[Utilizador]
            WHERE Nome_Utilizador = @NomeUtilizador AND Senha = @Senha
        ) THEN 1 ELSE 0 END
    );
    RETURN @Exists;
END


/* /////////////////////////////////////////////////  


				Procedures


/////////////////////////////////////////////////   */



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

/* /////////////////////////////////////////////////  */


CREATE PROCEDURE Youtube.UpdateSubscribers
    @CanalName VARCHAR(20)
AS
BEGIN
    UPDATE Youtube.Canal
    SET Num_Subscritores = Num_Subscritores + 1
    WHERE Nome_Utilizador = @CanalName;
END;


/* /////////////////////////////////////////////////  */



CREATE PROCEDURE Youtube.UpdateSubscribers2
    @CanalName VARCHAR(20)
AS
BEGIN
    UPDATE Youtube.Canal
    SET Num_Subscritores = Num_Subscritores - 1
    WHERE Nome_Utilizador = @CanalName;
END;


/* /////////////////////////////////////////////////  */


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


