Alter PROCEDURE sp_AltaLogicaUsuarioPorID
    @ID int
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (
            SELECT 1
            FROM Usuarios
            WHERE ID = @ID
        )
        BEGIN
            RAISERROR('No existe un usuario con ese ID.', 16, 1);
        END

        IF EXISTS (
            SELECT 1
            FROM Usuarios
            WHERE ID = @ID
            AND Activo = 1
        )
        BEGIN
            RAISERROR('El Usuario ya se encuentra dada de Alta.', 16, 2);
        END

        UPDATE Usuarios
        SET Activo = 1
        WHERE IDPersona =  @ID

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO