USE [Facturacion]
GO
/****** Object:  StoredProcedure [dbo].[SP_LimpiarTabla]    Script Date: 22/11/18 4:38:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[SP_LimpiarTabla]
as 
begin

insert into  Detalle_Factura select IdProducto,Cantidad, Precio, comenatrio, Ticket, fecha, Estado from Detalle_Factura_T
insert into Gastos_Diario select Descripcion,Precio,Fecha, Nombre from Gastos

DELETE FROM Detalle_Factura_T;
DBCC CHECKIDENT ('Detalle_Factura_T', RESEED, 0);

DELETE FROM Gastos_Diario;
DBCC CHECKIDENT ('Gastos', RESEED, 0);
end;