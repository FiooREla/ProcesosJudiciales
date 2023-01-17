USE [SIG-PJ]

GO

CREATE TABLE [Reporte].[ReporteDetalle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDReporte] [int] NOT NULL,
	[Numero] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[FieldName] [varchar](100) NULL,
	[Caption] [varchar](100) NOT NULL,
	[TipoInterno] [varchar](20) NOT NULL,
 CONSTRAINT [pkReporteDetalle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Reporte].[ReporteDetalle]  WITH CHECK ADD  CONSTRAINT [fkReporteDetalle_Reporte] FOREIGN KEY([IDReporte])
REFERENCES [Reporte].[Reporte] ([ID])
GO

ALTER TABLE [Reporte].[ReporteDetalle] CHECK CONSTRAINT [fkReporteDetalle_Reporte]
GO


