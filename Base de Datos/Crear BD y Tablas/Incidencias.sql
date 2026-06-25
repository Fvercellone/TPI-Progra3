INSERT INTO Estados (Nombre)
VALUES
('Abierto'),
('Asignado'),
('En Análisis'),
('Resuelto'),
('Cerrado'),
('Reabierto');

INSERT INTO Prioridades (Nombre)
VALUES
('Baja'),
('Media'),
('Alta'),
('Crítica');

INSERT INTO Categorias (Nombre)
VALUES
('Sistema'),
('Facturación'),
('Soporte técnico'),
('Consulta general');

INSERT INTO Incidencias
(
    Titulo,
    Descripcion,
    IDCliente,
    IDEmpleado,
    IDEstado,
    IDCategoria,
    IDPrioridad,
    Comentario,
    ComentarioCierre,
    FechaAlta,
    FechaModificacion,
    FechaResolucion,
    FechaCierre
)
VALUES
(
    'Problema de acceso al sistema',
    'El cliente indica que no puede iniciar sesión con su usuario y contraseña.',
    4,
    2,
    1,
    1,
    2,
    'Se registra el reclamo para revisión inicial.',
    NULL,
    GETDATE(),
    NULL,
    NULL,
    NULL
),
(
    'Error en facturación',
    'El cliente informa que recibió una factura con un importe incorrecto.',
    5,
    2,
    3,
    2,
    3,
    'Se está analizando la diferencia informada por el cliente.',
    NULL,
    DATEADD(DAY, -2, GETDATE()),
    GETDATE(),
    NULL,
    NULL
),
(
    'Solicitud de soporte técnico',
    'El cliente reporta lentitud en la aplicación durante la carga de datos.',
    4,
    3,
    2,
    3,
    2,
    'Incidencia reasignada al área técnica.',
    NULL,
    DATEADD(DAY, -3, GETDATE()),
    DATEADD(DAY, -1, GETDATE()),
    NULL,
    NULL
),
(
    'Consulta general sobre el servicio',
    'El cliente solicita información sobre el estado de su cuenta.',
    5,
    2,
    4,
    4,
    1,
    'Se brindó respuesta satisfactoria al cliente.',
    NULL,
    DATEADD(DAY, -5, GETDATE()),
    DATEADD(DAY, -4, GETDATE()),
    DATEADD(DAY, -4, GETDATE()),
    NULL
),
(
    'Reclamo cerrado sin resolución',
    'El cliente inició un reclamo pero luego no respondió a los intentos de contacto.',
    4,
    3,
    5,
    1,
    2,
    'Se intentó contactar al cliente en varias oportunidades.',
    'Se cierra la incidencia por falta de respuesta del cliente.',
    DATEADD(DAY, -10, GETDATE()),
    DATEADD(DAY, -7, GETDATE()),
    NULL,
    DATEADD(DAY, -6, GETDATE())
);