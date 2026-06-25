CREATE PROCEDURE sp_CerrarIncidencia
(
    @ID INT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (
            SELECT 1
            FROM Incidencias
            WHERE ID = @ID
            AND Comentario IS NOT NULL
            AND LTRIM(RTRIM(Comentario)) <> ''
        )
        BEGIN
            RAISERROR('No se puede cerrar una incidencia sin comentario de resolución.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        DECLARE @IDEstadoCerrado INT;

        SELECT @IDEstadoCerrado = ID
        FROM Estados
        WHERE Nombre = 'Cerrado';

        UPDATE Incidencias
        SET
            IDEstado = @IDEstadoCerrado,
            FechaCierre = GETDATE(),
            FechaModificacion = GETDATE()
        WHERE ID = @ID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;