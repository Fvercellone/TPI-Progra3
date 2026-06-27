alter PROCEDURE sp_AgregarIncidencia
    @Titulo VARCHAR(150),
    @Descripcion VARCHAR(500),
    @IDCliente INT,
    @IDEmpleado INT,
    @IDCategoria INT,
    @IDPrioridad INT,
    @IDEstado INT
AS
BEGIN
    INSERT INTO Incidencias
    (
        Titulo,
        Descripcion,
        IDCliente,
        IDEmpleado,
        IDCategoria,
        IDPrioridad,
        IDEstado
    )
    VALUES
    (
        @Titulo,
        @Descripcion,
        @IDCliente,
        @IDEmpleado,
        @IDCategoria,
        @IDPrioridad,
        @IDEstado
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END