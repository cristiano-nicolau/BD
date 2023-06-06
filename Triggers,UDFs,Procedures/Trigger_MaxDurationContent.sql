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