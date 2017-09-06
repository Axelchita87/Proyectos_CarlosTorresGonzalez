-- =============================================
-- Author:		Ivan Martínez Guerrero
-- Create date: 15-09-2011
-- Description:	Procedure that gets a Banks collection
-- =============================================
CREATE Procedure [dbo].[GetAllBanks]
 
AS
Begin
	select Id, Bank from dbo.CatBanks
End