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