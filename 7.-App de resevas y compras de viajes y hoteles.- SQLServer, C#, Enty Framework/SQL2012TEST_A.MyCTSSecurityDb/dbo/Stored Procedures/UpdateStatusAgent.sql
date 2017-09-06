-- =============================================
-- Author:		Ivan Martinez Guerrero
-- Create date: 10 de Abril de 2012
-- Description:	Procedure that updates an Agent
-- =============================================
CREATE Procedure [dbo].[UpdateStatusAgent]
	@Agent as varchar(50)
AS
Begin
	Update	AgentCatalog
	Set Asigned=1
	Where Agent=@Agent
End