

-- =============================================
-- Author:		Jessica Gutiérrez Becerril
-- Create date: 06/06/2013 
-- Description:	Procedure that delete a ToolOnlineRules
-- =============================================
CREATE Procedure [dbo].[DeleteToolOnlineRules]
 @StrToSearch as varchar(10)
AS

Begin
	delete [dbo].[ToolOnlineRules]
	where [Attribute1]=@StrToSearch
End