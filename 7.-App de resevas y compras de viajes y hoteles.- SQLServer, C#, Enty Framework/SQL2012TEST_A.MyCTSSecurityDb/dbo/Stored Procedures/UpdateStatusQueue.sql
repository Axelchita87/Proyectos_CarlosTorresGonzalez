-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 10 de Abril de 2012
-- Description:	Procedure that updates a Queue
-- =============================================
CREATE Procedure [dbo].[UpdateStatusQueue]
	@Queue as varchar(50)
AS
Begin
	Update	QueueCatalog
	Set Asigned=1
	Where [Queue]=@Queue
End

/****** Objeto:  StoredProcedure [dbo].[UpdateStatusFirm]    Fecha de la secuencia de comandos: 05/04/2012 07:10:30 ******/
SET ANSI_NULLS ON
