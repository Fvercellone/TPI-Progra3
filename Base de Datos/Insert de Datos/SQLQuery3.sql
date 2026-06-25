
SELECT
    I.ID,
    I.Titulo,
    I.Descripcion,

    PC.Nombre + ' ' + PC.Apellido AS Cliente,
    PE.Nombre + ' ' + PE.Apellido AS Empleado,

    E.Nombre AS Estado,
    C.Nombre AS Categoria,
    PR.Nombre AS Prioridad,

    I.Comentario,
    I.ComentarioCierre,
    I.FechaAlta,
    I.FechaModificacion,
    I.FechaResolucion,
    I.FechaCierre

FROM Incidencias AS I

INNER JOIN Usuarios AS UC
    ON I.IDCliente = UC.ID

INNER JOIN Personas AS PC
    ON UC.IDPersona = PC.ID

INNER JOIN Usuarios AS UE
    ON I.IDEmpleado = UE.ID

INNER JOIN Personas AS PE
    ON UE.IDPersona = PE.ID

INNER JOIN Estados AS E
    ON I.IDEstado = E.ID

INNER JOIN Categorias AS C
    ON I.IDCategoria = C.ID

INNER JOIN Prioridades AS PR
    ON I.IDPrioridad = PR.ID;