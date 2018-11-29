

Create Procedure SP_VentaReporte
@fechaInicial datetime = '',
@fechaFin datetime = '',
@tipoProducto int =0,
@producto int = 0
as
begin
  select p.Nombre_producto,SUM(cantidad) Cantidad, sum(d.Precio) Venta_Total
   from Detalle_Factura d  
    join Producto p on   p.id  = d.IdProducto
	
  

	where (@fechaInicial = '' or @fechaInicial is null or @fechaInicial >=d.fecha)
	    and (@fechaFin = '' or @fechaFin is null or @fechaFin <=d.fecha)
		and (@tipoProducto = 0 or @tipoProducto is null or p.id = @tipoProducto)
		and (@producto = 0 or @producto is null or d.IdProducto= @producto )
	  group by Nombre_producto
	end