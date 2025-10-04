USE master
GO

CREATE DATABASE PruebaTecnica2025
GO

USE PruebaTecnica2025
GO

CREATE TABLE Empleado
(
IdEmpleado INT IDENTITY(1,1) PRIMARY KEY,
Nombre VARCHAR(500),
Apellido VARCHAR(500),
FechaIngreso DATETIME,
NombrePuesto VARCHAR(500),
IdTipoIdentificacion INT,
NumeroIdentificacion VARCHAR(50)
)
GO

CREATE TABLE TipoIdentificacion
(
IdTipoIdentificacion INT IDENTITY(1,1) PRIMARY KEY,
Codigo VARCHAR(20),
Descripcion VARCHAR(100)
)
GO

ALTER TABLE Empleado ADD CONSTRAINT FK_Empleado_TipoIdentificacion FOREIGN KEY (IdTipoIdentificacion) REFERENCES TipoIdentificacion(IdTipoIdentificacion)

INSERT INTO TipoIdentificacion(Codigo,Descripcion)
VALUES ('CED','Cedula')

INSERT INTO TipoIdentificacion(Codigo,Descripcion)
VALUES ('PAS','Pasaporte')