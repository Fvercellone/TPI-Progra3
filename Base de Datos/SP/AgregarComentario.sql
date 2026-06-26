ALTER PROCEDURE sp_AgregarComentarioIncidencia
    @IDIncidencia INT,
    @IDUsuario INT,
    @Comentario VARCHAR(1000)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @IDEstadoActual INT;
        DECLARE @IDEstadoAbierto INT;
        DECLARE @IDEstadoAnalisis INT;

        IF NOT EXISTS (
            SELECT 1 
            FROM Incidencias 
            WHERE ID = @IDIncidencia
        )
        BEGIN
            RAISERROR('La incidencia no existe.',16,1);
        END

        IF NOT EXISTS (
            SELECT 1 
            FROM Usuarios 
            WHERE ID = @IDUsuario
        )
        BEGIN
            RAISERROR('El usuario no existe.',16,1);
        END

        SELECT @IDEstadoActual = IDEstado
        FROM Incidencias
        WHERE ID = @IDIncidencia;

        SELECT @IDEstadoAbierto = ID
        FROM Estados
        WHERE Nombre = 'Abierto';

        SELECT @IDEstadoAnalisis = ID
        FROM Estados
        WHERE Nombre = 'En Análisis';

        IF @IDEstadoAbierto IS NULL
        BEGIN
            RAISERROR('No existe el estado Abierto.',16,1);
        END

        IF @IDEstadoAnalisis IS NULL
        BEGIN
            RAISERROR('No existe el estado En Análisis.',16,1);
        END

        INSERT INTO ComentariosIncidencia
        (
            IDIncidencia,
            IDUsuario,
            Mensaje
        )
        VALUES
        (
            @IDIncidencia,
            @IDUsuario,
            @Comentario
        );

        IF @IDEstadoActual = @IDEstadoAbierto
        BEGIN
            UPDATE Incidencias
            SET 
                IDEstado = @IDEstadoAnalisis,
                FechaModificacion = GETDATE()
            WHERE ID = @IDIncidencia;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO