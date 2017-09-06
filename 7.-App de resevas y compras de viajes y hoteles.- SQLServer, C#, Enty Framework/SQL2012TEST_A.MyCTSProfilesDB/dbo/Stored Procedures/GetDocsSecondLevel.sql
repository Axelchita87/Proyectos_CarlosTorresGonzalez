-- =============================================
-- Author:		<orihuela Ulises>
-- Create date: <02/DICIEMBRE/2010>
-- Description:	<OBTIENE DOCUMENTOS DEL PERFIL POR PROFILE ID E IMAGEID>
-- =============================================
CREATE PROCEDURE [dbo].[GetDocsSecondLevel] 
	-- Add the parameters for the stored procedure here
		   @ProfileId bigint,
           @imageId int
	
AS
BEGIN
    -- Insert statements for procedure here
	SELECT TOP 1000 [ImageId]
      ,[ProfileId]
      ,[Name]
      ,[Image]
      ,[InsertDate]
      ,[UpdateDate]
      ,[DeleteDate]
      ,[Enable],
	  [DocName]
  FROM [dbo].[DocsSecondLevel]
  	where [ProfileId] = @ProfileId and ImageId = @imageId 

END

