ALTER TABLE [Judicial].[Expediente]

ADD IdNotificacionTipoContenido int NULL constraint fk_Expediente_TipoContenidoNotificacion foreign key references  [Judicial].[TipoContenido];

go

select * from Judicial.Expediente