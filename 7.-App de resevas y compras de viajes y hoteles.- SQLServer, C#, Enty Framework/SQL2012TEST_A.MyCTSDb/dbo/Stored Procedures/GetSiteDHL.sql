

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 07-07-2009
-- Description:	Procedure that gets a DHL collection
-- =============================================
CREATE Procedure [dbo].[GetSiteDHL]
AS
Begin
	  Begin
		SELECT DISTINCT Code AS Site
		FROM dbo.ClientsCatalogs
		WHERE [CorporativeID]='DHL' AND [RemarkLabelID] = 'C34'
	  End
 End


