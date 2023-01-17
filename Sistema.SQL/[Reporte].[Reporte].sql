USE [SIG-PJ]
GO

create schema Reporte

GO

CREATE TABLE [Reporte].[Reporte](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Orden] [varchar](50) NOT NULL,
	[Codigo] [varchar](100) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Query] [varchar](max) NULL,
	[ConfXml1] [varbinary](max) NULL,
	[ConfXml2] [varbinary](max) NULL,
	[Filtro] [bit] NOT NULL,
	[FormFiltro] [varchar](500) NULL,
	[MostrarPivot] [bit] NOT NULL,
	[FiltroFecha] [bit] NOT NULL,
	[ColumnFecha] [varchar](100) NULL,
 CONSTRAINT [pkLugar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [Reporte].[Reporte] ADD  DEFAULT ((0)) FOR [Filtro]
GO

ALTER TABLE [Reporte].[Reporte] ADD  DEFAULT ((0)) FOR [MostrarPivot]
GO

ALTER TABLE [Reporte].[Reporte] ADD  DEFAULT ((0)) FOR [FiltroFecha]
GO


