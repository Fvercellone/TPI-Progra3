CREATE PROCEDURE sp_ModificarUsuarioPorDNI
    @ID INT,
    @DNI VARCHAR(20),
    @IDRol INT,
    @Usuario VARCHAR(50),
    @Contrasenia VARCHAR(100),
    @Activo BIT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @IDPersona INT;

        SELECT @IDPersona = ID
        FROM Personas
        WHERE DNI = @DNI;

        IF @IDPersona IS NULL
        BEGIN
            RAISERROR('No existe una persona con ese DNI.', 16, 1);
        END

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
            WHERE IDPersona = @IDPersona
              AND ID <> @ID
        )
        BEGIN
            RAISERROR('Esa persona ya tiene otro usuario asignado.', 16, 1);
        END

        UPDATE Usuarios
        SET
            IDPersona = @IDPersona,
            IDRol = @IDRol,
            Usuario = @Usuario,
            Contrasenia = @Contrasenia,
            Activo = @Activo
        WHERE ID = @ID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO