Alter VIEW vw_IncidenciasDetalle
AS
SELECT
    I.ID,
    I.Titulo,
    I.Descripcion,

    I.IDCliente,
    UC.Usuario AS Cliente,

    I.IDEmpleado,
    UE.Usuario AS Empleado,

    I.IDEstado,
    E.Nombre AS Estado,

    I.IDCategoria,
    C.Nombre AS Categoria,

    I.IDPrioridad,
    PR.Nombre AS Prioridad,

    I.ComentarioCierre,
    I.FechaAlta,
    I.FechaModificacion,
    I.FechaResolucion,
    I.FechaCierre
FROM Incidencias AS I
INNER JOIN Usuarios AS UC ON I.IDCliente = UC.ID
INNER JOIN Personas AS PC ON UC.IDPersona = PC.ID
INNER JOIN Usuarios AS UE ON I.IDEmpleado = UE.ID
INNER JOIN Personas AS PE ON UE.IDPersona = PE.ID
INNER JOIN Estados AS E ON I.IDEstado = E.ID
INNER JOIN Categorias AS C ON I.IDCategoria = C.ID
INNER JOIN Prioridades AS PR ON I.IDPrioridad = PR.ID;