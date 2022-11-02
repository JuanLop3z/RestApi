create database Empleado
GO
USE Empleado
GO

CREATE TABLE  empleado(
IdEmpleado  int identity(1,1),
Nombre nvarchar(50),
Apellido nvarchar(50),
)
GO