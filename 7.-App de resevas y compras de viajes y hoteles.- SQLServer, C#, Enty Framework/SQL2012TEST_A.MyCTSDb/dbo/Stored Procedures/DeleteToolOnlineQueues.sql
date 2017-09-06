

-- =============================================
-- Author:		Jessica Gutiérrez Becerril
-- Create date: 20/06/2013 
-- Description:	Procedure that delete a [dbo].[ToolOnlineQueues]
-- =============================================
CREATE Procedure [dbo].[DeleteToolOnlineQueues]
@StrToSearch as varchar(50)
AS

Begin
	delete [dbo].[ToolOnlineQueues]
	where  [Description] like '%'+ @StrToSearch + '%'
End