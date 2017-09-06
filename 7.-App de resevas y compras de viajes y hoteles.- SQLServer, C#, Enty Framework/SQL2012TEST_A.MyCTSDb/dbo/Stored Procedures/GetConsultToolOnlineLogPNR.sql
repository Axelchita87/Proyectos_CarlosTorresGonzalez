-- =============================================
-- Author:	Jessica Gutierrez
-- Create date: 05/09/2013
-- Description:	Get All [dbo].[ToolOnlineLog]
-- =============================================
CREATE PROCEDURE  GetConsultToolOnlineLogPNR
@PNR as varchar(10)
AS
BEGIN
	Select [PNR],[DK],[Attribute1],[FormatSendQueue],[Supervisor],[Consultores]
	from [dbo].[ToolOnlineLog]
	where [PNR]=@PNR
END
