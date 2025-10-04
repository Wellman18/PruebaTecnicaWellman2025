USE master
GO

CREATE DATABASE PruebaTecnica2025
GO

USE PruebaTecnica2025
GO

CREATE TABLE Empleado
(
IdEmpleado INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(500) NOT NULL,
Apellido VARCHAR(500) NOT NULL,
FechaIngreso DATETIME NOT NULL,
NombrePuesto VARCHAR(500) NOT NULL,
IdTipoIdentificacion INT NOT NULL,
NumeroIdentificacion VARCHAR(50) NOT NULL
)
GO

CREATE TABLE TipoIdentificacion
(
IdTipoIdentificacion INT IDENTITY(1,1) PRIMARY KEY,
Codigo VARCHAR(20) NOT NULL,
Descripcion VARCHAR(100) NOT NULL
)
GO

ALTER TABLE Empleado ADD CONSTRAINT FK_Empleado_TipoIdentificacion FOREIGN KEY (IdTipoIdentificacion) REFERENCES TipoIdentificacion(IdTipoIdentificacion)

INSERT INTO TipoIdentificacion(Codigo,Descripcion)
VALUES ('CED','Cedula')

INSERT INTO TipoIdentificacion(Codigo,Descripcion)
VALUES ('PAS','Pasaporte')