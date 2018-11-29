create procedure SP_Cuadre
as
begin
declare @gastos int= (select sum(Precio) from Gastos_Diario);

declare @venta int = (select sum(Precio) from Detalle_Factura_T)


declare @total int = @venta - @gastos;

select @total;
end;