-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 6 de Abril de 2012
-- Description:	Procedure that gets a Firm not asigned
-- =============================================
CREATE Procedure [dbo].[GetFirmForNewUser]
AS
Begin
	Select Top(1) * From FirmCatalog
	Where asigned=0
End

/****** Objeto:  StoredProcedure [dbo].[GetQueueForNewUser]    Fecha de la secuencia de comandos: 05/04/2012 07:14:35 ******/
SET ANSI_NULLS ON
