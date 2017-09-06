-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 6 de Abril de 2012
-- Description:	Procedure that deletes a IATA
-- =============================================
CREATE Procedure [dbo].[DeleteIATA]
	@IATA as varchar(50)
AS
Begin
	Delete From	IATACatalog
	Where IATA=@IATA
End

/****** Objeto:  StoredProcedure [dbo].[DeleteTA]    Fecha de la secuencia de comandos: 05/04/2012 07:18:19 ******/
SET ANSI_NULLS ON
