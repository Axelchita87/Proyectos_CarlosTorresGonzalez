-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 10 de Abril de 2012
-- Description:	Procedure that updates a Queue
-- =============================================
CREATE Procedure [dbo].[UpdateUnassignStatusQueue]
	@Queue as varchar(50)
AS
Begin
	Update	QueueCatalog
	Set Asigned=0
	Where [Queue]=@Queue
End

/****** Objeto:  StoredProcedure [dbo].[UpdateUnassignStatusFirm]    Fecha de la secuencia de comandos: 05/04/2012 07:12:49 ******/
SET ANSI_NULLS ON
