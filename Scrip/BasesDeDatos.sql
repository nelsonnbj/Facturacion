USE [Facturacion]
GO
/****** Object:  StoredProcedure [dbo].[SP_Generar_Turno]    Script Date: 14/9/18 5:06:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_Generar_Turno]
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

GO
/****** Object:  StoredProcedure [dbo].[SP_LimpiarTabla]    Script Date: 14/9/18 5:06:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_LimpiarTabla]
as 
begin

insert into  Detalle_Factura select IdProducto,Cantidad, Precio, comenatrio, Ticket, fecha, Estado from Detalle_Factura_T
insert into Gastos select Descripcion,Precio,Fecha, Nombre from Gastos_Diario

DELETE FROM Detalle_Factura_T;
DBCC CHECKIDENT ('Detalle_Factura_T', RESEED, 0);

DELETE FROM Gastos_Diario;
DBCC CHECKIDENT ('Gastos_Diario', RESEED, 0);
end;
GO
/****** Object:  Table [dbo].[Detalle_Factura]    Script Date: 14/9/18 5:06:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Factura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Precio] [int] NULL,
	[comenatrio] [nvarchar](100) NULL,
	[Ticket] [nvarchar](50) NULL,
	[fecha] [datetime] NULL,
	[Estado] [nvarchar](20) NULL,
 CONSTRAINT [PK__Factura___3213E83F0BC6C43E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Detalle_Factura_T]    Script Date: 14/9/18 5:06:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Factura_T](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [int] NOT NULL,
	[comenatrio] [nvarchar](100) NULL,
	[Ticket] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](20) NULL,
	[fecha] [datetime] NULL,
	[telefono] [nvarchar](12) NULL,
	[Estado] [nvarchar](20) NULL,
	[TipoProducto] [int] NULL,
	[TipoServicio] [nvarchar](20) NULL,
 CONSTRAINT [PK__Factura___3213E83F0F975522] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gastos]    Script Date: 14/9/18 5:06:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gastos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Precio] [int] NULL,
	[Fecha] [datetime] NULL,
	[Nombre] [nvarchar](20) NULL,
 CONSTRAINT [PK_Gastos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gastos_Diario]    Script Date: 14/9/18 5:06:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gastos_Diario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Precio] [int] NULL,
	[Fecha] [datetime] NULL,
	[Nombre] [nvarchar](20) NULL,
 CONSTRAINT [PK_Gastos_Diario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invetario]    Script Date: 14/9/18 5:06:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invetario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](20) NULL,
	[Cantidad] [int] NULL,
	[Fecha] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NombreCliente]    Script Date: 14/9/18 5:06:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NombreCliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [nvarchar](20) NULL,
	[IdTelefono] [int] NULL,
 CONSTRAINT [PK_NombreCliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 14/9/18 5:06:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_producto] [nvarchar](20) NULL,
	[Precio] [int] NULL,
	[TipoProducto] [int] NOT NULL,
	[UrlImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductoChimi] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 14/9/18 5:06:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefono](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Telefono] [nvarchar](12) NULL,
 CONSTRAINT [PK_Telefono] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 14/9/18 5:06:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Detalle_Factura] ON 

INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (1, 1, 1, 125, N'F', N'C01', NULL, N'Facturado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (2, 1, 1, 125, NULL, N'C01', CAST(N'2018-08-08 11:40:46.993' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (3, 1, 1, 125, NULL, N'C02', CAST(N'2018-08-08 12:23:42.337' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (4, 5, 1, 225, N'Sin Mayonesa / ', N'C02', CAST(N'2018-08-08 12:29:00.323' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (5, 4, 1, 225, NULL, N'C03', CAST(N'2018-08-08 12:33:25.517' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (6, 23, 1, 200, N'Sin Picante / ', N'B01', CAST(N'2018-08-08 12:34:12.917' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (7, 23, 1, 200, NULL, N'B02', CAST(N'2018-08-08 12:35:39.790' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (8, 13, 1, 250, N'Sin Picante / ', N'B03', CAST(N'2018-08-14 15:09:52.637' AS DateTime), N'Facturado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (9, 2, 3, 525, N'Sin Cebolla / ', N'C04', CAST(N'2018-08-14 15:10:16.990' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (10, 5, 1, 225, N'Sin Picante / ', N'C05', CAST(N'2018-08-14 15:13:41.290' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (11, 1, 1, 125, N'saf', N'C06', CAST(N'2018-08-14 15:16:19.170' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (12, 14, 1, 250, NULL, N'B04', CAST(N'2018-08-14 15:16:30.993' AS DateTime), N'Facturado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (13, 17, 1, 75, NULL, N'B05', CAST(N'2018-08-14 15:17:30.073' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (14, 22, 1, 200, NULL, N'B06', CAST(N'2018-08-14 15:17:46.817' AS DateTime), N'Facturado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (15, 13, 1, 250, N'viernes', N'B07', CAST(N'2018-08-17 12:21:43.680' AS DateTime), N'Facturado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (16, 15, 1, 300, NULL, N'B08', CAST(N'2018-08-20 12:01:45.863' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (17, 3, 1, 175, N'asf', N'C07', CAST(N'2018-08-21 13:25:44.503' AS DateTime), N'Cancelado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (18, 6, 2, 300, N'Sin Mayonesa / ', N'C07', CAST(N'2018-08-21 13:25:44.503' AS DateTime), N'Cancelado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (19, 10, 3, 450, N'Sin Picante / ', N'C07', CAST(N'2018-08-21 13:25:44.503' AS DateTime), N'Despachado')
INSERT [dbo].[Detalle_Factura] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [fecha], [Estado]) VALUES (20, 4, 1, 225, NULL, N'C08', CAST(N'2018-08-22 12:19:31.730' AS DateTime), N'Facturado')
SET IDENTITY_INSERT [dbo].[Detalle_Factura] OFF
SET IDENTITY_INSERT [dbo].[Detalle_Factura_T] ON 

INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (1, 1, 1, 125, NULL, N'C01', NULL, CAST(N'2018-08-08 11:40:46.993' AS DateTime), NULL, N'Despachado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (2, 1, 1, 125, NULL, N'C02', NULL, CAST(N'2018-08-08 12:23:42.337' AS DateTime), NULL, N'Despachado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (3, 5, 1, 225, N'Sin Mayonesa / ', N'C02', NULL, CAST(N'2018-08-08 12:29:00.323' AS DateTime), NULL, N'Despachado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (4, 4, 1, 225, NULL, N'C03', NULL, CAST(N'2018-08-08 12:33:25.517' AS DateTime), NULL, N'Despachado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (5, 23, 1, 200, N'Sin Picante / ', N'B01', NULL, CAST(N'2018-08-08 12:34:12.917' AS DateTime), NULL, N'Despachado', 2, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (6, 23, 1, 200, NULL, N'B02', NULL, CAST(N'2018-08-08 12:35:39.790' AS DateTime), NULL, N'Despachado', 2, N'Empacar')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (7, 13, 1, 250, N'Sin Picante / ', N'B03', NULL, CAST(N'2018-08-14 15:09:52.637' AS DateTime), NULL, N'Despachado', 2, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (8, 2, 3, 525, N'Sin Cebolla / ', N'C04', NULL, CAST(N'2018-08-14 15:10:16.990' AS DateTime), NULL, N'Despachado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (9, 5, 1, 225, N'Sin Picante / ', N'C05', NULL, CAST(N'2018-08-14 15:13:41.290' AS DateTime), NULL, N'Despachado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (10, 1, 1, 125, N'saf', N'C06', NULL, CAST(N'2018-08-14 15:16:19.170' AS DateTime), NULL, N'Despachado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (11, 14, 1, 250, NULL, N'B04', NULL, CAST(N'2018-08-14 15:16:30.993' AS DateTime), NULL, N'Despachado', 2, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (12, 17, 1, 75, NULL, N'B05', NULL, CAST(N'2018-08-14 15:17:30.073' AS DateTime), NULL, N'Despachado', 2, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (13, 22, 1, 200, NULL, N'B06', NULL, CAST(N'2018-08-14 15:17:46.817' AS DateTime), NULL, N'Facturado', 2, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (14, 13, 1, 250, N'viernes', N'B07', NULL, CAST(N'2018-08-17 12:21:43.680' AS DateTime), NULL, N'Facturado', 2, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (15, 15, 1, 300, NULL, N'B08', NULL, CAST(N'2018-08-20 12:01:45.863' AS DateTime), NULL, N'Despachado', 2, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (16, 3, 1, 175, N'asf', N'C07', NULL, CAST(N'2018-08-21 13:25:44.503' AS DateTime), NULL, N'Cancelado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (17, 6, 2, 300, N'Sin Mayonesa / ', N'C07', NULL, CAST(N'2018-08-21 13:25:44.503' AS DateTime), NULL, N'Cancelado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (18, 10, 3, 450, N'Sin Picante / ', N'C07', NULL, CAST(N'2018-08-21 13:25:44.503' AS DateTime), NULL, N'Despachado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (19, 4, 1, 225, NULL, N'C08', NULL, CAST(N'2018-08-22 12:19:31.730' AS DateTime), NULL, N'Facturado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (20, 17, 1, 75, NULL, N'B09', NULL, CAST(N'2018-09-07 12:48:15.023' AS DateTime), NULL, N'Facturado', 2, N'Empacar')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (21, 1, 1, 125, NULL, N'C09', NULL, CAST(N'2018-09-13 09:52:15.723' AS DateTime), NULL, N'Facturado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (22, 16, 1, 75, NULL, N'B010', NULL, CAST(N'2018-09-13 09:52:43.347' AS DateTime), NULL, N'Facturado', 2, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (23, 17, 1, 75, NULL, N'B011', NULL, CAST(N'2018-09-13 09:53:06.100' AS DateTime), NULL, N'Facturado', 2, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (24, 11, 1, 175, NULL, N'C010', NULL, CAST(N'2018-09-13 09:53:33.173' AS DateTime), NULL, N'Facturado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (25, 9, 1, 125, NULL, N'C011', NULL, CAST(N'2018-09-13 09:54:14.703' AS DateTime), NULL, N'Facturado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (26, 9, 1, 125, NULL, N'C012', NULL, CAST(N'2018-09-13 09:54:54.697' AS DateTime), NULL, N'Facturado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (27, 1, 1, 125, NULL, N'C013', NULL, CAST(N'2018-09-13 09:59:06.180' AS DateTime), NULL, N'Facturado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (28, 10, 1, 150, NULL, N'C014', NULL, CAST(N'2018-09-13 10:01:10.223' AS DateTime), NULL, N'Facturado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (29, 10, 1, 150, NULL, N'C015', NULL, CAST(N'2018-09-13 10:01:22.330' AS DateTime), NULL, N'Facturado', 1, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (30, 13, 1, 250, NULL, N'B012', NULL, CAST(N'2018-09-13 10:01:30.150' AS DateTime), NULL, N'Facturado', 2, N'Comer Aqui')
INSERT [dbo].[Detalle_Factura_T] ([id], [IdProducto], [Cantidad], [Precio], [comenatrio], [Ticket], [nombre], [fecha], [telefono], [Estado], [TipoProducto], [TipoServicio]) VALUES (31, 7, 1, 175, NULL, N'C016', NULL, CAST(N'2018-09-13 10:45:35.627' AS DateTime), NULL, N'Facturado', 1, N'Comer Aqui')
SET IDENTITY_INSERT [dbo].[Detalle_Factura_T] OFF
SET IDENTITY_INSERT [dbo].[Gastos] ON 

INSERT [dbo].[Gastos] ([id], [Descripcion], [Precio], [Fecha], [Nombre]) VALUES (1, N'refresco', 50, CAST(N'2018-08-16 00:00:00.000' AS DateTime), N'nelson')
INSERT [dbo].[Gastos] ([id], [Descripcion], [Precio], [Fecha], [Nombre]) VALUES (2, NULL, NULL, NULL, NULL)
INSERT [dbo].[Gastos] ([id], [Descripcion], [Precio], [Fecha], [Nombre]) VALUES (3, NULL, NULL, NULL, NULL)
INSERT [dbo].[Gastos] ([id], [Descripcion], [Precio], [Fecha], [Nombre]) VALUES (4, NULL, NULL, NULL, NULL)
INSERT [dbo].[Gastos] ([id], [Descripcion], [Precio], [Fecha], [Nombre]) VALUES (5, N'prueba', 50, CAST(N'2018-08-02 00:00:00.000' AS DateTime), N'nelson')
SET IDENTITY_INSERT [dbo].[Gastos] OFF
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (1, N'Chimi', 125, 1, N'~/Content/Product/1.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (2, N'Chimi Pierna', 175, 1, N'~/Content/Product/2.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (3, N'Bacon Cheese', 175, 1, N'~/Content/Product/3.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (4, N'Chimi Pablo', 225, 1, N'~/Content/Product/4.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (5, N'Rubio Burger', 225, 1, N'~/Content/Product/5.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (6, N'Chimi Pechuga', 150, 1, N'~/Content/Product/6.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (7, N'Chimi Doble Carne', 175, 1, N'~/Content/Product/7.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (8, N'Pechuga Empanizada', 150, 1, N'~/Content/Product/8.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (9, N'Hamburger Res', 125, 1, N'~/Content/Product/28.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (10, N'Hamburger Pechuga', 150, 1, N'~/Content/Product/10.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (11, N'Hamburger Pierna', 175, 1, N'~/Content/Product/11.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (12, N'Mofongo Res', 250, 2, N'~/Content/Product/28.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (13, N'Mofongo Cerdo', 250, 2, N'~/Content/Product/28.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (14, N'Mofongo Longaniza', 250, 2, N'~/Content/Product/28.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (15, N'Mofongo Grande', 300, 2, N'~/Content/Product/28.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (16, N'Tacos Pollo', 75, 2, N'~/Content/Product/16.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (17, N'Tacos Res', 75, 2, N'~/Content/Product/28.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (18, N'Burrito  Pollo', 150, 2, N'~/Content/Product/28.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (19, N'Burrito  Res', 150, 2, N'~/Content/Product/28.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (20, N'Burrito Grande', 200, 2, N'~/Content/Product/20.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (21, N'Burrito Mixto', 200, 2, N'~/Content/Product/28.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (22, N'Quezadilla Pollo', 200, 2, N'~/Content/Product/28.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (23, N'Quezadilla Res', 200, 2, N'~/Content/Product/28.jpg')
INSERT [dbo].[Producto] ([id], [Nombre_producto], [Precio], [TipoProducto], [UrlImage]) VALUES (24, N'Ensalada Pello', 200, 2, N'~/Content/Product/28.jpg')
SET IDENTITY_INSERT [dbo].[Producto] OFF
SET IDENTITY_INSERT [dbo].[TipoProducto] ON 

INSERT [dbo].[TipoProducto] ([Id], [Descripcion]) VALUES (1, N'Chimi')
INSERT [dbo].[TipoProducto] ([Id], [Descripcion]) VALUES (2, N'Burrito')
SET IDENTITY_INSERT [dbo].[TipoProducto] OFF
ALTER TABLE [dbo].[Detalle_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Factura_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([id])
GO
ALTER TABLE [dbo].[Detalle_Factura] CHECK CONSTRAINT [FK_Detalle_Factura_Producto]
GO
ALTER TABLE [dbo].[Detalle_Factura_T]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Factura_T_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([id])
GO
ALTER TABLE [dbo].[Detalle_Factura_T] CHECK CONSTRAINT [FK_Detalle_Factura_T_Producto]
GO
ALTER TABLE [dbo].[Detalle_Factura_T]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Factura_T_TipoProducto] FOREIGN KEY([TipoProducto])
REFERENCES [dbo].[TipoProducto] ([Id])
GO
ALTER TABLE [dbo].[Detalle_Factura_T] CHECK CONSTRAINT [FK_Detalle_Factura_T_TipoProducto]
GO
ALTER TABLE [dbo].[NombreCliente]  WITH CHECK ADD  CONSTRAINT [FK_NombreCliente_Telefono] FOREIGN KEY([IdTelefono])
REFERENCES [dbo].[Telefono] ([id])
GO
ALTER TABLE [dbo].[NombreCliente] CHECK CONSTRAINT [FK_NombreCliente_Telefono]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_TipoProducto] FOREIGN KEY([TipoProducto])
REFERENCES [dbo].[TipoProducto] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_TipoProducto]
GO
