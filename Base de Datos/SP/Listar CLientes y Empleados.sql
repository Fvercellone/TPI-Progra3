Alter PROCEDURE sp_ListarClientes
AS
BEGIN
    SELECT 
        U.ID,
        P.Nombre + ' ' + P.Apellido AS NombreCompleto
    FROM Usuarios U
    INNER JOIN Personas P ON U.IDPersona = P.ID
    INNER JOIN Roles R ON U.IDRol = R.ID
    WHERE R.Nombre = 'Cliente'
    AND U.Activo = 1
    AND P.Activo = 1;
END;

exec sp_ListarClientes

Alter PROCEDURE sp_ListarEmpleados
AS
BEGIN
    SELECT 
        U.ID,
        P.Nombre + ' ' + P.Apellido AS NombreCompleto
    FROM Usuarios U
    INNER JOIN Personas P ON U.IDPersona = P.ID
    INNER JOIN Roles R ON U.IDRol = R.ID
    WHERE R.Nombre IN ('Telefonista', 'Supervisor')
    AND U.Activo = 1
    AND P.Activo = 1;
END;

exec sp_ListarEmpleados