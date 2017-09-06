

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 07-07-2009
-- Description:	Procedure that gets a DHL collection
-- =============================================
CREATE Procedure [dbo].[GetCtaDHL]
AS
Begin
	  Begin
		SELECT DISTINCT Code AS Cta
		FROM dbo.ClientsCatalogs
		WHERE [CorporativeID]='DHL' AND [RemarkLabelID] = 'C36'
	  End
 End


