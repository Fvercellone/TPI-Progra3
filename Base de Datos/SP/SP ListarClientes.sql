alter PROCEDURE sp_ListarClientes
AS
BEGIN
    SELECT
        U.ID,
        U.IDPersona,
        P.Nombre,
        P.Apellido,
        P.Nombre + ' ' + P.Apellido AS NombreCompleto,
        P.DNI,
        P.Email,
        P.Telefono,
        R.Nombre AS Rol,
        U.Usuario,
        U.Activo
    FROM Usuarios U
    INNER JOIN Personas P
        ON U.IDPersona = P.ID
    INNER JOIN Roles R
        ON U.IDRol = R.ID
    WHERE R.Nombre = 'Cliente'
      AND U.Activo = 1
      AND P.Activo = 1
    ORDER BY P.Apellido, P.Nombre;
END;
GO

EXEC sp_ListarClientes;