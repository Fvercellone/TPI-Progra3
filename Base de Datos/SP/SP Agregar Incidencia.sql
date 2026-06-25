CREATE PROCEDURE sp_AgregarIncidencia
    @Titulo VARCHAR(150),
    @Descripcion VARCHAR(500),
    @IDCliente INT,
    @IDEmpleado INT,
    @IDCategoria INT,
    @IDPrioridad INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IDEstadoAbierto INT;

    SELECT @IDEstadoAbierto = ID
    FROM Estados
    WHERE Nombre = 'Abierto';

    INSERT INTO Incidencias
    (
        Titulo,
        Descripcion,
        IDCliente,
        IDEmpleado,
        IDEstado,
        IDCategoria,
        IDPrioridad,
        FechaAlta
    )
    VALUES
    (
        @Titulo,
        @Descripcion,
        @IDCliente,
        @IDEmpleado,
        @IDEstadoAbierto,
        @IDCategoria,
        @IDPrioridad,
        GETDATE()
    );
END;

exec sp_ListarClientes

exec sp_ListarEmpleados