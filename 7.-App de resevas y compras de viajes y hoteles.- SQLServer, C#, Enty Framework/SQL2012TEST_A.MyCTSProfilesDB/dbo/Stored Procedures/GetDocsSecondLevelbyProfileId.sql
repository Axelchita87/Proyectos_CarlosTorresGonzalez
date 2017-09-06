-- =============================================
-- Author:		<orihuela Ulises>
-- Create date: <02/DICIEMBRE/2010>
-- Description:	<OBTIENE DOCUMENTOS DEL PERFIL POR PROFILE ID E IMAGEID>
-- =============================================
CREATE PROCEDURE [dbo].[GetDocsSecondLevelbyProfileId] 
	-- Add the parameters for the stored procedure here
		   @ProfileId bigint
	
AS
BEGIN
    -- Insert statements for procedure here
	SELECT [ImageId]
      ,[ProfileId]
      ,[Name]
      ,[Image]
      ,[InsertDate]
      ,[UpdateDate]
      ,[DeleteDate]
      ,[Enable],
	  [DocName]
  FROM [dbo].[DocsSecondLevel]
  	where [ProfileId] = @ProfileId and [Enable] = 1;

END

