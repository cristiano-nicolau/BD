USE p5g2;
go



CREATE TRIGGER EnforceMaxDuration
ON Youtube.Conteúdo
AFTER INSERT, UPDATE
AS
BEGIN
    -- Check if the video duration exceeds the maximum limit (e.g., 60 minutes)
    IF EXISTS (
        SELECT * FROM inserted WHERE Duracao > '01:00:00'
    )
    BEGIN
        RAISERROR('Video duration exceeds the maximum limit.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;
END;


/*  /////////////////////////////////////////////////   */

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



/*  /////////////////////////////////////////////////   */



CREATE TRIGGER set_Conteúdo
ON [p5g2].[Youtube].[Conteúdo]
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NumLikes INT, @NumViews INT, @DataPub DATE, @MaxCodigo INT;

    SET @NumLikes = 0;
    SET @NumViews = 0;
    SET @DataPub = GETDATE();


	--Autor
    DECLARE @AutorExists INT;

    SELECT @AutorExists = COUNT(*) FROM [p5g2].[Youtube].[Utilizador] WHERE Nome_Utilizador = (SELECT Autor FROM inserted);

    IF @AutorExists = 0
    BEGIN
        RAISERROR ('Autor Inválido. este Canal não existe', 16, 1);
        RETURN;
    END;

	--Estado

    IF (SELECT Estado FROM inserted) NOT IN (0, 1)
    BEGIN
       
        RAISERROR ('Estado inválido. Estado deve ser "0" para privado ou 1 para "publico"', 16, 1);
        RETURN; 
    END

	--Codigo+1

    SELECT @MaxCodigo = MAX(Codigo) FROM [p5g2].[Youtube].[Conteúdo];

    SET @MaxCodigo = ISNULL(@MaxCodigo, 0) + 1;

    INSERT INTO [p5g2].[Youtube].[Conteúdo] (Titulo, Codigo, Autor, Tipo, Estado, Duracao, Num_Likes, Num_Views, Data_Pub)
    SELECT Titulo, @MaxCodigo, Autor, Tipo, Estado, Duracao, @NumLikes, @NumViews, @DataPub
    FROM inserted;
END;


/*  /////////////////////////////////////////////////   */

CREATE TRIGGER Utilizador_verifications
ON [p5g2].[Youtube].[Utilizador]
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Email VARCHAR(20), @NomeUtilizador VARCHAR(20), @Senha VARCHAR(15), @Nome VARCHAR(20), @DataNascimento DATE;

    SELECT @Email = Email, @NomeUtilizador = Nome_Utilizador, @Senha = Senha, @Nome = Nome, @DataNascimento = Data_de_Nascimento
    FROM inserted;

    --Email

    IF NOT EXISTS (SELECT 1 FROM inserted WHERE Email LIKE '%_@__%.__%')
    BEGIN
        
        RAISERROR ('Email com formato inválido', 16, 1);
        RETURN; 
    END;

    -- Nome_Utilizador

    IF @NomeUtilizador IS NULL
    BEGIN
  
        RAISERROR ('Nome de Utilizador inválido.', 16, 1);
        RETURN; 
    END;

	--Senha

    IF @Senha IS NULL
    BEGIN
       
        RAISERROR ('Senha Inválida.', 16, 1);
        RETURN; 
    END;

	--Name

    IF NOT EXISTS (SELECT 1 FROM inserted WHERE Nome LIKE '% %')
    BEGIN
      
        RAISERROR ('Nome Apelido Inválido. Deve conter um nome e um apelido.', 16, 1);
        RETURN; 
    END;

    --Data de Nascimento

    IF DATEDIFF(YEAR, @DataNascimento, GETDATE()) < 15
    BEGIN
        
        RAISERROR ('Data de Nascimento inválida. O utilizador deverá ter mais do que 15 anos.', 16, 1);
        RETURN; 
    END;

    -- Insert the values into the table
    INSERT INTO [p5g2].[Youtube].[Utilizador] (Nome_Utilizador, Email, Senha, Nome, Data_de_Nascimento)
    SELECT @NomeUtilizador, @Email, @Senha, @Nome, @DataNascimento;
END;






