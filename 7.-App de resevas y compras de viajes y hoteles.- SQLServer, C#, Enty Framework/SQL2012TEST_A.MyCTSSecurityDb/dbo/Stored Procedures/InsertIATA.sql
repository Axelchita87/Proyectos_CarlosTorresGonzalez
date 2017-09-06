-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 22 de Marzo de 2012
-- Description:	Procedure that inserts a IATA in IATACatalog
-- =============================================
CREATE Procedure [dbo].[InsertIATA]
	@Iata as varchar(50),
	@Office as varchar(50),
	@Pcc as varchar(50)
AS
Begin
	Insert Into	IATACatalog(Iata, Office, Pcc)
	Values(@Iata, @Office, @Pcc)
End

/****** Objeto:  StoredProcedure [dbo].[InsertTA]    Fecha de la secuencia de comandos: 05/04/2012 07:13:15 ******/
SET ANSI_NULLS ON
