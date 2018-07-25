USE [Facturacion]
GO
/****** Object:  StoredProcedure [dbo].[SP_Generar_Turno]    Script Date: 7/25/2018 1:28:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[SP_Generar_Turno]
 @servicio varchar(30)
 as
 begin
declare @solicitud varchar(20)
,@turno1 varchar(10)
,@numero int

 set @solicitud = case @servicio 
when 'Chimi'
    then 'C'
when 'Burrito'
    then 'B'
end

------------Generar numero del turno----------



set @numero = ( select Count(distinct(Ticket)) from Factura_Chimi_T where TipoProducto= @solicitud) 
set @numero = @numero + 1

set @turno1 = @solicitud + '0' + convert(varchar, @numero) 
select @turno1


end
