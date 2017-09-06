-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 18-06-2009
-- Description:	Predictive that confirms that a DK exist
-- =============================================
CREATE Procedure [dbo].[GetConfirmDK]
 @DKToSearch as varchar(50)
AS
Begin
	Select 
		[IDDK], [Name] as DKName
	From
		[dbo].[DK]
	Where ([IDDK] like @DKToSearch + '%' or [Name] like @DKToSearch + '%')
End
