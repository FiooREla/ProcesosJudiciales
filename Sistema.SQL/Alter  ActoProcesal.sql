ALTER TABLE [Judicial].[ActoProcesal]

ADD IdNotificacionTipoContenido int NULL constraint fk_ActoProcesal_TipoContenidoNotificacion foreign key references  [Judicial].[TipoContenido];


go

select * from [Judicial].[ActoProcesal]