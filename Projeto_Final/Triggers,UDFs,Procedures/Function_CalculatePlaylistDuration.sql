USE p5g2;
go;

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