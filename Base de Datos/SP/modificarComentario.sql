CREATE PROCEDURE sp_ModificarComentarioIncidencia
    @IDComentario INT,
    @Comentario VARCHAR(1000)
AS
BEGIN
    UPDATE ComentariosIncidencia
    SET Mensaje = @Comentario
    WHERE ID = @IDComentario
      AND Activo = 1;
END;