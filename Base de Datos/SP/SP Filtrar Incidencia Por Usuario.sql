CREATE OR ALTER PROCEDURE sp_FiltrarIncidenciasPorUsuario
    @IDUsuario INT
AS
BEGIN
    BEGIN TRY

        DECLARE @Rol VARCHAR(50);

        SELECT @Rol = R.Nombre
        FROM Usuarios U
        INNER JOIN Roles R ON U.IDRol = R.ID
        WHERE U.ID = @IDUsuario
          AND U.Activo = 1;

        IF @Rol IS NULL
        BEGIN
            RAISERROR('El usuario no existe o se encuentra inactivo.', 16, 1);
        END

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
            P.Nombre AS Prioridad,

            I.FechaAlta,
            I.FechaModificacion
        FROM Incidencias I
        INNER JOIN Estados E 
            ON I.IDEstado = E.ID
        INNER JOIN Categorias C 
            ON I.IDCategoria = C.ID
        INNER JOIN Prioridades P 
            ON I.IDPrioridad = P.ID

        INNER JOIN Usuarios UC 
            ON I.IDCliente = UC.ID

        INNER JOIN Usuarios UE 
            ON I.IDEmpleado = UE.ID

        WHERE
            @Rol IN ('Administrador', 'Supervisor')
            OR (@Rol = 'Telefonista' AND I.IDEmpleado = @IDUsuario)
            OR (@Rol = 'Cliente' AND I.IDCliente = @IDUsuario);

    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO