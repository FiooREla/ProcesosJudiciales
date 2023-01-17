ALTER TABLE [Judicial].[Expediente]

ADD IdEstadoActual int NULL constraint fk_Expediente_TEstadoActual foreign key references  [Judicial].[TipoContenido];
	
go

select * from Judicial.Expediente