CREATE PROCEDURE sp_ReasignarIncidencia
(
    @ID INT,
    @IDEmpleado INT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM Incidencias WHERE ID = @ID)
        BEGIN
            RAISERROR('La incidencia no existe.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        DECLARE @IDEstadoAsignado INT;

        SELECT @IDEstadoAsignado = ID
        FROM Estados
        WHERE Nombre = 'Asignado';

        UPDATE Incidencias
        SET
            IDEmpleado = @IDEmpleado,
            IDEstado = @IDEstadoAsignado,
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