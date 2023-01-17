ALTER TABLE [Judicial].[ExpedienteInstancia]

ADD IdPersonaContrato int NULL constraint fk_ExpedienteIntancia_PersonaEmpresaContrato foreign key references [Judicial].[PersonaEmpresa],
Automisorio varchar(max) null,
TasacionInstancia decimal(18,2) null,
Apelacion varchar(max) null,
Comentarios varchar(max) null;


go

select * from [Judicial].[ExpedienteInstancia]