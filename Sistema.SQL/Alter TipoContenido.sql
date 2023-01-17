ALTER TABLE [Judicial].[TipoContenido]

ADD Titulo varchar(500) null,
	NroDias int null,
	TipoInterno varchar(50);

go

select * from Judicial.TipoContenido