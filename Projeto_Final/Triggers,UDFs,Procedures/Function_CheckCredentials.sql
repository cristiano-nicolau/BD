Use p5g2
go

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
