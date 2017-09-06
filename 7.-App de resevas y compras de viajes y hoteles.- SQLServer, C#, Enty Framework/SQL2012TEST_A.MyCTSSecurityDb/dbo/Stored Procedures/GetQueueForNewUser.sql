-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 6 de Abril de 2012
-- Description:	Procedure that gets a Queue not asigned
-- =============================================
CREATE Procedure [dbo].[GetQueueForNewUser]
AS
Begin
	Select Top(1) * From QueueCatalog
	Where asigned=0
End

/****** Objeto:  StoredProcedure [dbo].[GetTAForNewUser]    Fecha de la secuencia de comandos: 05/04/2012 07:14:32 ******/
SET ANSI_NULLS ON
