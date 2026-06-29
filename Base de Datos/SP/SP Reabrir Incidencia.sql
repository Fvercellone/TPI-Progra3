USE [TPI_Progra3]
GO
/****** Objeto: StoredProcedure [dbo].[sp_ReabrirIncidencia] Fecha de script: 29/6/2026 09:58:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   PROCEDURE [dbo].[sp_ReabrirIncidencia]
    @IDIncidencia INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @IDEstadoActual INT;
        DECLARE @NombreEstadoActual VARCHAR(50);
        DECLARE @IDEstadoReabierto INT;

        SELECT 
            @IDEstadoActual = I.IDEstado,
            @NombreEstadoActual = E.Nombre
        FROM Incidencias I
        INNER JOIN Estados E ON I.IDEstado = E.ID
        WHERE I.ID = @IDIncidencia;

        IF @IDEstadoActual IS NULL
        BEGIN
            RAISERROR('No existe una incidencia con ese ID.', 16, 1);
        END

        IF @NombreEstadoActual <> 'Cerrado'
        BEGIN
            RAISERROR('Solo se pueden reabrir incidencias que estén cerradas.', 16, 1);
        END

        SELECT @IDEstadoReabierto = ID
        FROM Estados
        WHERE Nombre = 'Reabierto';

        IF @IDEstadoReabierto IS NULL
        BEGIN
            RAISERROR('No existe el estado Reabierto en la tabla Estados.', 16, 1);
        END

        UPDATE Incidencias
        SET IDEstado = @IDEstadoReabierto
        WHERE ID = @IDIncidencia;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;