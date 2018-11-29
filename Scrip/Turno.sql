

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

if (@solicitud='C')
begin
set @numero = ( select Count(id) from Factura_Chimi) 
set @numero = @numero + 1

set @turno1 = @solicitud + '0' + convert(varchar, @numero) 
select @turno1
end;

if (@solicitud='B')
begin
set @numero = ( select count(id) from Factura_Burrito) 
set @numero = @numero + 1
set @turno1 = @solicitud + '0' + convert(varchar, @numero)
select @turno1 
end

end



