-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 10 de Abril de 2012
-- Description:	Procedure that updates a TA
-- =============================================
CREATE Procedure [dbo].[UpdateUnassignStatusTA]
	@TA as varchar(50)
AS
Begin
	Update	TACatalog
	Set Asigned=0
	Where TA=@TA
End

/****** Objeto:  StoredProcedure [dbo].[UpdateUnassignStatusQueue]    Fecha de la secuencia de comandos: 05/04/2012 07:12:51 ******/
SET ANSI_NULLS ON
