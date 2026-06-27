CREATE OR ALTER PROCEDURE sp_LoginUsuario
    @Usuario VARCHAR(50),
    @Contrasenia VARCHAR(100)
AS
BEGIN
    BEGIN TRY

        IF NOT EXISTS (
            SELECT 1
            FROM Usuarios
            WHERE Usuario = @Usuario
              AND Contrasenia = @Contrasenia
        )
        BEGIN
            RAISERROR('Usuario o contraseña incorrectos.', 16, 1);
        END

        IF EXISTS (
            SELECT 1
            FROM Usuarios
            WHERE Usuario = @Usuario
              AND Contrasenia = @Contrasenia
              AND Activo = 0
        )
        BEGIN
            RAISERROR('El usuario se encuentra inactivo.', 16, 1);
        END

        SELECT
            U.ID,
            U.IDPersona,
            P.Nombre,
            P.Apellido,
            P.DNI,
            U.IDRol,
            R.Nombre AS Rol,
            U.Usuario,
            U.Activo
        FROM Usuarios U
        INNER JOIN Personas P ON U.IDPersona = P.ID
        INNER JOIN Roles R ON U.IDRol = R.ID
        WHERE U.Usuario = @Usuario
          AND U.Contrasenia = @Contrasenia
          AND U.Activo = 1;

    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

EXEC sp_LoginUsuario
    @Usuario = 'PRaton',
    @Contrasenia = 'asdasd';