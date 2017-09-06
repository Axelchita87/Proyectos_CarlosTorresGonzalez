-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 28 de Marzo de 2012
-- Description:	Procedure that gets a IATA
-- =============================================
CREATE Procedure [dbo].[GetIATA]
	@Iata as varchar(50)
AS
Begin
	Select Iata, Office, Pcc from IATACatalog
	where Iata=@Iata
End

/****** Objeto:  StoredProcedure [dbo].[GetQueue]    Fecha de la secuencia de comandos: 05/04/2012 07:17:39 ******/
SET ANSI_NULLS ON
