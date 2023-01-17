ALTER TABLE [Judicial].[PersonaEmpresa]

ADD Descripcion Varchar(5000) null,
	FechaIncio datetime null,
	FechaFin datetime null ;

go

select * from Judicial.PersonaEmpresa