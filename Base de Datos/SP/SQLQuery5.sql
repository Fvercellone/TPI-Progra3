create PROCEDURE sp_ResolverIncidencia
(
    @ID INT,
    @ComentarioResolucion VARCHAR(500)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF @ComentarioResolucion IS NULL OR LTRIM(RTRIM(@ComentarioResolucion)) = ''
        BEGIN
            RAISERROR('Debe ingresar un comentario de resolución.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        DECLARE @IDEstadoResuelto INT;

        SELECT @IDEstadoResuelto = ID
        FROM Estados
        WHERE Nombre = 'Resuelto';

        UPDATE Incidencias
        SET
            IDEstado = @IDEstadoResuelto,
            Comentario = @ComentarioResolucion,
            FechaResolucion = GETDATE(),
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