CREATE PROCEDURE sp_EliminarComentarioIncidencia
    @IDComentario INT
AS
BEGIN
    UPDATE ComentariosIncidencia
    SET Activo = 0
    WHERE ID = @IDComentario;
END;