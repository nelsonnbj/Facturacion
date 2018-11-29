Create Procedure SP_GastosDiarios
@fechaIni datetime,
@fechaFin datetime,
@Nombre nvarchar(30)=''
as
begin

Select nombre, Descripcion, precio from Gastos_Diario
where (@fechaIni = '' or @fechaIni is null or Fecha >= @fechaIni)
and   (@fechaFin = '' or @fechaFin is null or Fecha <= @fechaFin)
and   (@Nombre = '' or @Nombre is null or @Nombre = Nombre)
end