

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 07-07-2009
-- Description:	Procedure that gets a DHL collection
-- =============================================
CREATE Procedure [dbo].[GetCteDHL]
AS
Begin
	  Begin
		SELECT DISTINCT Code AS Cte
		FROM dbo.ClientsCatalogs
		WHERE [CorporativeID]='DHL' AND [RemarkLabelID] = 'C35'
	  End
 End


