create table Factura_Chimi(
id int identity primary key
,Producto nvarchar(50)
,Cantidad int 
,Precio int
,Ticket nvarchar(50)
,nombre nvarchar(20)
,fecha datetime
)


select * from Factura_Chimi

create table Factura_Burrito(
id int identity primary key
,Producto nvarchar(50)
,Cantidad int 
,Precio int
,Ticket nvarchar(50)
,nombre nvarchar(20)
,fecha datetime
)

select * from Factura_Chimi