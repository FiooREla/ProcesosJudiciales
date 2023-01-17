ALTER TABLE [Judicial].[Expediente]

ADD TipoNotificacion Varchar (50) null,
	NroCasillaNotificacion varchar(50) null;

go

select * from Judicial.Expediente