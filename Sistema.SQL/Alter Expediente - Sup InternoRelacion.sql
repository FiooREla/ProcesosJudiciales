ALTER TABLE [Judicial].[Expediente]

ADD IdSupervisorINternoRela int NULL constraint fk_Expediente_SupervisorInternoPersonaEmpresa foreign key references [Judicial].[PersonaEmpresa] ;
	
go

select * from Judicial.Expediente