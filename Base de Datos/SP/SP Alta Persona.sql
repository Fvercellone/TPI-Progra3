ALTER PROCEDURE sp_AltaLogicaUsuarioPorDNI
    @DNI VARCHAR(20)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (
            SELECT 1
            FROM Personas
            WHERE DNI = @DNI
        )
        BEGIN
            RAISERROR('No existe una persona con ese DNI.', 16, 1);
        END

        UPDATE Personas
        SET Activo = 1
        WHERE DNI = @DNI;

        UPDATE Usuarios
        SET Activo = 1
        WHERE IDPersona IN (
            SELECT ID
            FROM Personas
            WHERE DNI = @DNI
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO