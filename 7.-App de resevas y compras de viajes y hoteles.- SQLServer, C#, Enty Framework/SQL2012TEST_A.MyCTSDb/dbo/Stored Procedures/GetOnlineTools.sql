-- =============================================
-- Author:		<Jessica Gutierrez>
-- Create date: <07/06/13>
-- Description:	<Get CatOnlineTools>
-- =============================================
CREATE PROCEDURE [dbo].[GetOnlineTools]
	
AS
BEGIN
	
	SELECT [ToolName]
	From [dbo].[CatOnlineTools]
END