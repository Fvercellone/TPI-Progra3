Alter PROCEDURE sp_BajaLogicaUsuarioPorID
    @ID int
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE ID = @ID)
        BEGIN
            RAISERROR('No existe una usuario con ese ID.', 16, 1);
        END

        IF EXISTS (
            SELECT 1
            FROM Usuarios
            WHERE ID = @ID
            AND Activo = 0
        )
        BEGIN
            RAISERROR('El usuario ya se encuentra dada de baja.', 16, 2);
        END

        UPDATE Usuarios
        SET Activo = 0
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