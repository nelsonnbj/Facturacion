USE [Facturacion]
GO

/****** Object:  StoredProcedure [dbo].[SP_Generar_Turno]    Script Date: 7/20/2018 5:06:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[SP_Generar_Turno]
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

if (@solicitud='C')
begin
set @numero = ( select Count(distinct(Ticket)) from Factura_Chimi_T) 
set @numero = @numero + 1

set @turno1 = @solicitud + '0' + convert(varchar, @numero) 
select @turno1
end;

if (@solicitud='B')
begin
set @numero = ( select  Count(distinct(Ticket)) from Factura_Burrito_T) 
set @numero = @numero + 1
set @turno1 = @solicitud + '0' + convert(varchar, @numero)
select @turno1 
end

end

GO


