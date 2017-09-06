-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 6 de Abril de 2012
-- Description:	Procedure that gets an Agent not asigned
-- =============================================
CREATE Procedure [dbo].[GetAgentForNewUser]
AS
Begin
	Select Top(1) * From AgentCatalog
	Where asigned=0
End

/****** Objeto:  StoredProcedure [dbo].[GetFirmForNewUser]    Fecha de la secuencia de comandos: 05/04/2012 07:15:50 ******/
SET ANSI_NULLS ON
