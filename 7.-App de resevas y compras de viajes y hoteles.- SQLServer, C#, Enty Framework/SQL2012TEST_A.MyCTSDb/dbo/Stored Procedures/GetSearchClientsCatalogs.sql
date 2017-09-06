-- =============================================
-- Author:		<Pedro Tomas Solis>
-- Creation date: <17/Sep/2009>
-- Description:	<Insert a Nextel record in ClientsCatalogs>
-- =============================================
CREATE Procedure [dbo].[GetSearchClientsCatalogs] 
	-- Input variables
	@Attribute1 nvarchar(10), 
	@RemarkLabelID nvarchar(100),
	@ValueToSearch nvarchar(100)
As
Begin
	Declare @Res as varchar(3)
	set @ValueToSearch = upper(@ValueToSearch)
	If Exists(
		Select Attribute1,RemarkLabelID
		From dbo.ClientsCatalogs
		Where Attribute1=@Attribute1 and RemarkLabelID=@RemarkLabelID and Code=@ValueToSearch
	)	
		Begin
			Set @Res = 1
		End
	Else
		Begin
			Set @Res = -1
		End
	SELECT @Res as Result	
END






