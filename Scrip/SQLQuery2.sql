

create procedure SP_Generar_Turno
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

if @solicitud='C'
set @numero = ( select Count(id) from Factura_Chimi where fecha =Convert(int,GETDATE())) 
set @numero = @numero + 1

set @turno1 = @solicitud + '00' + convert(varchar, @numero) 

end;

if @solicitud='B'
set @numero = ( select count(id) from Factura_Burrito where fecha = Convert(int,GETDATE())) 
set @numero = @numero + 1
set @turno1 = @solicitud + '00' + convert(varchar, @numero) 

select @turno1


drop procedure SP_Generar_Turno

exec SP_Generar_Turno 'Chimi'

declare @f datetime
set @f = Convert(int,GETDATE())

select @f