-- =============================================
-- Author:		Jessica Gutierrez
-- Create date: 12/06/13
-- Description:	Extract Information of [dbo].[ToolOnlineQueues]
-- =============================================
CREATE PROCEDURE [Get_ToolOnlineQueues]
AS
BEGIN
	Select [Queue],[PCC],[Description],[PicCode]
	from [dbo].[ToolOnlineQueues]
END
