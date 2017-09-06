-- =============================================
-- Author:	Jessica Gutierrez Becerril
-- Create date: 12/06/13
-- Description:	AddNew [dbo].[ToolOnlineQueues]
-- =============================================
CREATE PROCEDURE [AddToolOnlineQueues]
@Queue int,
@PCC varchar(4),
@PicCode int,
@Description varchar(30)

AS
BEGIN
	Insert into [dbo].[ToolOnlineQueues]
	([Queue],[PCC],[PicCode],[Description])
	values (@Queue,@PCC,@PicCode,@Description)
END
