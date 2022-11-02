use Empleado
go


--En este proceso guardamos al empleado solo con nombre y apellido
create proc emp_Guardar(
@Nombre nvarchar(50),
@apellido nvarchar(50)
)
as
begin insert into Empleado(Nombre,Apellido) values(@Nombre,@Apellido)
end 
go


--En este proceso modificamos al empleado en el nombre y apellido donde este el id
create proc emp_Modificar(
@IdEmpleado int,
@Nombre nvarchar(50),
@apellido nvarchar(50)
)
as
begin update Empleado set Nombre=@Nombre, Apellido = @Apellido where IdEmpleado = @IdEmpleado
end
go


--En este proceso eliminamos al empleado con el Id--
create proc emp_Eliminar(
@IdEmpleado int
)
as
begin delete from Empleado where IdEmpleado = @IdEmpleado
end 
go


--Proceso para consultar empleados con el id
create proc emp_Consultar(@IdEmpleado int)
as
begin
select * from Empleado where IdEmpleado = @IdEmpleado
end
go
--proceso para listarlos
create proc emp_Listar
as
begin
select * from Empleado
end
go