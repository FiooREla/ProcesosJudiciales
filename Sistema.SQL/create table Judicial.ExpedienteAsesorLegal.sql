use [SIG-PJ]
go
create table Judicial.ExpedienteAsesorLegal(
ID int not null constraint pkExpedienteAsesorLegal primary key identity(1,1),
IdExpediente int null constraint fk_ExpedienteAsesorLegal_Expediente foreign key references [Judicial].[Expediente],
IdAsesorLegalEstudio int null constraint fk_ExpedienteAsesorLegal_EstudioAbogado_PersonaEmpresa foreign key references[Judicial].[PersonaEmpresa] ,
IdAsesorLegalAbogado int null constraint fk_ExpedienteAsesorLegal_AbogadoEngargado_PersonaEmpresa foreign key references[Judicial].[PersonaEmpresa] ,
FechaInicio datetime null,
FechaFIn datetime null,
Observaciones varchar(5000) null)
go