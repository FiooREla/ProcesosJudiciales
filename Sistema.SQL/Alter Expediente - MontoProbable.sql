ALTER TABLE [Judicial].[Expediente]

ADD MontoProbable decimal(18,2) null;
go

select * from Judicial.Expediente
