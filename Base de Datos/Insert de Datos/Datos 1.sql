USE TPI_Progra3;
GO

INSERT INTO Roles (Nombre)
VALUES
('Cliente'),
('Telefonista'),
('Supervisor'),
('Administrador');
GO

INSERT INTO Permisos (Nombre, Descripcion, Nivel, Activo)
VALUES
('Ver mis incidencias', 'Puede visualizar únicamente sus incidencias', 0, 1),
('Enviar mensajes', 'Puede responder mensajes en incidencias propias', 0, 1),
('Administrar clientes', 'Alta, baja y modificación de clientes', 1, 1),
('Administrar incidencias', 'Crear y modificar incidencias', 1, 1),
('Ver todas las incidencias', 'Puede visualizar todas las incidencias', 2, 1),
('Reasignar incidencias', 'Puede cambiar el responsable de una incidencia', 3, 1),
('Administrar usuarios', 'Puede crear, modificar y desactivar usuarios', 3, 1);
GO

INSERT INTO RolesPermisos (IDRol, IDPermiso)
VALUES
(1, 1),
(1, 2),

(2, 3),
(2, 4),

(3, 3),
(3, 4),
(3, 5),
(3, 6),

(4, 1),
(4, 2),
(4, 3),
(4, 4),
(4, 5),
(4, 6),
(4, 7);
GO

INSERT INTO Personas
(Nombre, Apellido, Email, Telefono, DNI, Activo)
VALUES
('Juan', 'Perez', 'juan.perez@gmail.com', '1122334455', '30111222', 1),
('Maria', 'Gomez', 'maria.gomez@gmail.com', '1133445566', '32555444', 1),
('Carlos', 'Lopez', 'carlos.lopez@empresa.com', '1144556677', '28999111', 1),
('Lucia', 'Fernandez', 'lucia.fernandez@empresa.com', '1155667788', '34123456', 1),
('Santiago', 'Martinez', 'santiago.martinez@empresa.com', '1166778899', '35777888', 1),
('Ana', 'Suarez', 'ana.suarez@empresa.com', '1177889900', '29888777', 1),
('Martin', 'Diaz', 'martin.diaz@empresa.com', '1188990011', '31222333', 1);
GO

INSERT INTO Usuarios
(IDPersona, IDRol, Usuario, Contrasenia, Activo)
VALUES
(1, 1, 'jperez', '1234', 1),
(2, 1, 'mgomez', '1234', 1),
(3, 2, 'clopez', '1234', 1),
(4, 2, 'lfernandez', '1234', 1),
(5, 3, 'smartinez', '1234', 1),
(6, 4, 'asuarez', '1234', 1),
(7, 4, 'mdiaz', '1234', 1);
GO