-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 22 de Marzo de 2012
-- Description:	Procedure that updates a IATA in IATACatalog
-- =============================================
CREATE Procedure [dbo].[UpdateIATA]
	@Iata as varchar(50),
	@Office as varchar(50),
	@Pcc as varchar(50)
AS
Begin
	Update	IATACatalog
	Set Office = @Office, Pcc = @Pcc
	Where Iata= @Iata
End

/****** Objeto:  StoredProcedure [dbo].[UpdateStatusTA]    Fecha de la secuencia de comandos: 05/04/2012 07:10:55 ******/
SET ANSI_NULLS ON
