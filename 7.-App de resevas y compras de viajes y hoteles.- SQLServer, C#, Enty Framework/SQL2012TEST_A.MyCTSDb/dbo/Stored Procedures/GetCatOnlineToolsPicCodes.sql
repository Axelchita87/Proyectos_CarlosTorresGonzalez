-- =============================================
-- Author:	Jessica Gutierrez
-- Create date: 20/06/13
-- Description:	Extraer la informacion de [dbo].[CatOnlineToolsPicCodes]
-- =============================================
CREATE PROCEDURE [GetCatOnlineToolsPicCodes]
AS
BEGIN
	Select [PicCode],[Description]
	from [dbo].[CatOnlineToolsPicCodes]
END
