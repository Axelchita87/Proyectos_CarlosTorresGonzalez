

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 07-07-2009
-- Description:	Procedure that gets a DHL collection
-- =============================================
CREATE Procedure [dbo].[GetActDHL]
AS
Begin
	  Begin
		SELECT DISTINCT Code AS Act
		FROM dbo.ClientsCatalogs
		WHERE [CorporativeID]='DHL' AND [RemarkLabelID] = 'C37'
	  End
 End

