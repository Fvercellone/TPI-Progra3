CREATE TABLE Categorias (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Prioridades (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Estados (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Incidencias (
    ID INT IDENTITY(1,1) PRIMARY KEY,

    Titulo VARCHAR(150) NOT NULL,
    Descripcion VARCHAR(500) NOT NULL,

    IDCliente INT NOT NULL,
    IDEmpleado INT NOT NULL,
    IDEstado INT NOT NULL,
    IDCategoria INT NOT NULL,
    IDPrioridad INT NOT NULL,

    Comentario VARCHAR(500) NULL,
    ComentarioCierre VARCHAR(500) NULL,

    FechaAlta DATETIME NOT NULL DEFAULT GETDATE(),
    FechaModificacion DATETIME NULL,
    FechaResolucion DATETIME NULL,
    FechaCierre DATETIME NULL,

    CONSTRAINT FK_Incidencias_Cliente
        FOREIGN KEY (IDCliente) REFERENCES Usuarios(ID),

    CONSTRAINT FK_Incidencias_Empleado
        FOREIGN KEY (IDEmpleado) REFERENCES Usuarios(ID),

    CONSTRAINT FK_Incidencias_Estado
        FOREIGN KEY (IDEstado) REFERENCES Estados(ID),

    CONSTRAINT FK_Incidencias_Categoria
        FOREIGN KEY (IDCategoria) REFERENCES Categorias(ID),

    CONSTRAINT FK_Incidencias_Prioridad
        FOREIGN KEY (IDPrioridad) REFERENCES Prioridades(ID)
);