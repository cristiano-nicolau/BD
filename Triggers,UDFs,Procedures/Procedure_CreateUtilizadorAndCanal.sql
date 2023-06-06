Use p5g2;
go

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