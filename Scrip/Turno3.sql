USE [Facturacion]
GO
/****** Object:  StoredProcedure [dbo].[SP_Generar_Turno]    Script Date: 13/9/18 9:44:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[SP_Generar_Turno]
 @servicio varchar(30)
 as
 begin
declare @solicitud varchar(10)
,@turno1 varchar(10)
,@numero int

 set @solicitud = case @servicio 
when 'C'
    then '1'
when 'B'
    then '2'
end

------------Generar numero del turno----------



set @numero = ( select Count(distinct(Ticket)) from Detalle_Factura_T where TipoProducto= Convert(int, @solicitud)) 
set @numero = @numero + 1

set @turno1 = @servicio + '0' + convert(varchar, @numero) 
select @turno1


end
