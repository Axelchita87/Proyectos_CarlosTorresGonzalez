-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 09-06-2009
-- Description:	Procedure that gets a value of a Parameter
-- =============================================
CREATE Procedure [dbo].[GetParameterValue]
 @ParameterName as nvarchar(100)
AS
Begin
	set nocount on;

	Select	[Values]
	From	[dbo].[Parameter] with(nolock)
	Where	[ParameterName] = @ParameterName
End