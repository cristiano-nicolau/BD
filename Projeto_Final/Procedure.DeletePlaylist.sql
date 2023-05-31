USE p5g2;
go;


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