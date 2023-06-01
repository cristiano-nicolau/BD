Use p5g2;
go;

CREATE PROCEDURE Youtube.UpdateSubscribers2
    @CanalName VARCHAR(20)
AS
BEGIN
    UPDATE Youtube.Canal
    SET Num_Subscritores = Num_Subscritores - 1
    WHERE Nome_Utilizador = @CanalName;
END;