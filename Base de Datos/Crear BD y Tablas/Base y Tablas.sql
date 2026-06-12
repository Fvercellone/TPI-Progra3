CREATE DATABASE TPI_Progra3;
GO

USE TPI_Progra3;
GO

CREATE TABLE Roles (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Permisos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NOT NULL,
    Nivel INT NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE RolesPermisos (
    IDRol INT NOT NULL,
    IDPermiso INT NOT NULL,

    CONSTRAINT PK_RolesPermisos PRIMARY KEY (IDRol, IDPermiso),

    CONSTRAINT FK_RolesPermisos_Roles
        FOREIGN KEY (IDRol) REFERENCES Roles(ID),

    CONSTRAINT FK_RolesPermisos_Permisos
        FOREIGN KEY (IDPermiso) REFERENCES Permisos(ID)
);
GO

CREATE TABLE Personas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    DNI VARCHAR(20) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,

    CONSTRAINT UQ_Personas_DNI UNIQUE (DNI)
);
GO

CREATE TABLE Usuarios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    IDPersona INT NOT NULL,
    IDRol INT NOT NULL,
    Usuario VARCHAR(50) NOT NULL,
    Contrasenia VARCHAR(100) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,

    CONSTRAINT UQ_Usuarios_Usuario UNIQUE (Usuario),
    CONSTRAINT UQ_Usuarios_IDPersona UNIQUE (IDPersona),

    CONSTRAINT FK_Usuarios_Personas
        FOREIGN KEY (IDPersona) REFERENCES Personas(ID),

    CONSTRAINT FK_Usuarios_Roles
        FOREIGN KEY (IDRol) REFERENCES Roles(ID)
);
GO