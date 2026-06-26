alter PROCEDURE sp_AgregarComentarioIncidencia
    @IDIncidencia INT,
    @IDUsuario INT,
    @Comentario VARCHAR(1000)
AS
BEGIN
    INSERT INTO ComentariosIncidencia
    (
        IDIncidencia,
        IDUsuario,
        Mensaje
    )
    VALUES
    (
        @IDIncidencia,
        @IDUsuario,
        @Comentario
    );
END;