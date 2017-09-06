


-- =============================================
-- Author:		Marcos Q. Ramirez
-- Create date: 19-04-2010
-- Description:	Procedure that gets remark client structure by Attribute1
-- =============================================
create Procedure [dbo].[GetQCCustomRemarks]
 @Attribute1 as varchar(10)
AS
Begin
	--Get remark structure by Attribute1
	Select RmrkType, RmrkInitialLabel, RmrkIdentyfier, RmrkPaxIdentyfier, RmrkValueIdentyfier, RmrkFinalLabel
	From dbo.QCCustomRemarksClients
	Where Attribute1 = @Attribute1
End


