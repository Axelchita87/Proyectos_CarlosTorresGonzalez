-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 11-05-2009
-- Description:	Procedure that gets a Remarks-Authorization collection
-- =============================================
Create Procedure [dbo].[GetRemarksAuthorization]
 @IDCorporativeToSearch as varchar(50)
AS
Begin
	Select 
		RemarkContableAuthorization
	From
		dbo.QualityControls
	Where ( CorporativeID = @IDCorporativeToSearch)
End




