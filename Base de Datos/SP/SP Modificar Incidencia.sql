CREATE PROCEDURE sp_ModificarIncidencia
(
    @ID INT,
    @Titulo VARCHAR(150),
    @Descripcion VARCHAR(500),
    @IDCliente INT,
    @IDEmpleado INT,
    @IDCategoria INT,
    @IDPrioridad INT
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verificar que la incidencia exista
        IF NOT EXISTS (SELECT 1 FROM Incidencias WHERE ID = @ID)
        BEGIN
            RAISERROR('La incidencia no existe.',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        DECLARE @IDEstadoAnalisis INT;

        SELECT @IDEstadoAnalisis = ID
        FROM Estados
        WHERE Nombre = 'En Análisis';

        UPDATE Incidencias
        SET
            Titulo = @Titulo,
            Descripcion = @Descripcion,
            IDCliente = @IDCliente,
            IDEmpleado = @IDEmpleado,
            IDCategoria = @IDCategoria,
            IDPrioridad = @IDPrioridad,
            IDEstado = @IDEstadoAnalisis,
            FechaModificacion = GETDATE()
        WHERE ID = @ID;

        COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;

    END CATCH
END
GO