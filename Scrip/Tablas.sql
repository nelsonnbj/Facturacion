create table Factura_Chimi(
id int identity primary key
,Producto nvarchar(50)
,Cantidad int 
,Precio int
,comenatrio nvarchar (100)
,Ticket nvarchar(50)
,nombre nvarchar(20)
,fecha datetime
,telefono nvarchar(12)  null
)

create table Factura_Burrito(
id int identity primary key
,IdProducto nvarchar(50)
,Cantidad int 
,Precio int
,comenatrio nvarchar (100)
,Ticket nvarchar(50)
,Idnombre nvarchar(20)
,fecha datetime
,Idtelefono nvarchar(12)  null
)

create table NombreCliente(
Id int identity
,NombreCliente  nvarchar(20)
,IdTelefono nvarchar(12)
)



create table Telefono(
id int identity
,Telefono nvarchar(12)
)

create table ProductoChimi(
id int identity
,Nombre_producto nvarchar (20)
,Precio int
)

create table Gastos(
id int identity
,Descripcion nvarchar (100)
,Precio int
,Fecha datetime
,Nombre nvarchar (20)
)

Create table  Invetario(

id int identity primary key
,Producto nvarchar (50)
,Descripcion nvarchar(20) null
,Cantidad int 
,Fecha datetime
)
