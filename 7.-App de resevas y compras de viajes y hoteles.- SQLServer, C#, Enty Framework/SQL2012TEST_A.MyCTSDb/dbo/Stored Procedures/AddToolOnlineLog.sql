-- =============================================
-- Author:	Jessica Gutierrez Becerril
-- Create date: 18/06/13
-- Description:	Inseret Information in [dbo].[ToolOnlineLog]
-- =============================================
CREATE PROCEDURE [dbo].[AddToolOnlineLog]
@DateLog datetime,
@PNR as varchar(6),
@DK as varchar(6),
@Attribute1 as varchar(6),
@FormatSendQueue as varchar(max),
@Supervisor varchar(4),
@Consultores varchar(30)

AS
BEGIN
Declare @LogID as varchar (50)
if (CONVERT(varchar, Convert(int, (Select isnull(MAX(Convert(int,[LogID])),0) from [dbo].[ToolOnlineLog]))) >=1)
	Set @LogID= CONVERT(varchar, Convert(int, (Select isnull(MAX(Convert(int,[LogID])),0) from [dbo].[ToolOnlineLog])) + 1)
else
	Set @LogID=1

	Insert into [dbo].[ToolOnlineLog] (LogID,DateLog,PNR,DK,Attribute1,FormatSendQueue, Supervisor, Consultores)
	values (@LogID,@DateLog,@PNR,@DK,@Attribute1,@FormatSendQueue,@Supervisor,@Consultores)
END