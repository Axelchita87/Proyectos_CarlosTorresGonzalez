

-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 07-07-2009
-- Description:	Procedure that gets a DHL collection
-- =============================================
CREATE Procedure [dbo].[GetCiaDHL]
AS
Begin
	  Begin
		SELECT DISTINCT Code AS Cia
		FROM dbo.ClientsCatalogs
		WHERE [CorporativeID]='DHL' AND [RemarkLabelID] = 'C33'
	  End
 End


