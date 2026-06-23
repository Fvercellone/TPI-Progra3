CREATE PROCEDURE sp_CrearUsuarioPorDNI
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

        IF EXISTS (
            SELECT 1
            FROM Usuarios
            WHERE IDPersona = @IDPersona
        )
        BEGIN
            RAISERROR('La persona ya tiene un usuario creado.', 16, 1);
        END

        IF NOT EXISTS (
            SELECT 1
            FROM Roles
            WHERE ID = @IDRol
        )
        BEGIN
            RAISERROR('No existe un rol con ese ID.', 16, 1);
        END

        INSERT INTO Usuarios
        (
            IDPersona,
            IDRol,
            Usuario,
            Contrasenia,
            Activo
        )
        VALUES
        (
            @IDPersona,
            @IDRol,
            @Usuario,
            @Contrasenia,
            @Activo
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;