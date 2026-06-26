alter PROCEDURE sp_ListarComentariosIncidencia
    @IDIncidencia INT
AS
BEGIN
    SELECT 
        C.ID,
        C.IDIncidencia,
        C.IDUsuario,
        P.Nombre + ' ' + P.Apellido AS Autor,
        R.Nombre AS Rol,
        C.Mensaje,
        C.Fecha,
        C.Activo,
        CASE
            WHEN R.Nombre = 'Cliente' THEN 0
            ELSE 1
        END AS EsEmpleado
    FROM ComentariosIncidencia C
    INNER JOIN Usuarios U ON C.IDUsuario = U.ID
    INNER JOIN Personas P ON U.IDPersona = P.ID
    INNER JOIN Roles R ON U.IDRol = R.ID
    WHERE C.IDIncidencia = @IDIncidencia
      AND C.Activo = 1
    ORDER BY C.Fecha ASC;
END;