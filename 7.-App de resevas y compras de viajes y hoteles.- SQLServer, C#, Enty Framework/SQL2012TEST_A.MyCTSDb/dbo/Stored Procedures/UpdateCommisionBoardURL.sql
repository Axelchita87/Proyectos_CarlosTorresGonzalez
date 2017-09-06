-- =============================================
-- Author:		Marcos Q. Ramírez
-- Create date: 14-11-2012
-- Description:	Procedure that update url commision board
-- =============================================
create Procedure [dbo].[UpdateCommisionBoardURL]
 @parameterName as varchar(500),
 @url as varchar(500)
AS

Begin
	Update dbo.Parameter
	Set [values] = @url
	where [ParameterName]=@parameterName
End