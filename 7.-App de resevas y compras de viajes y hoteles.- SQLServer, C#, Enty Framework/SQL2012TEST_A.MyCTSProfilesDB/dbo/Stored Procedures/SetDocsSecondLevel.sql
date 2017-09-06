-- =============================================
-- Author:		<orihuela Ulises>
-- Create date: <22/Enero/2010>
-- Description:	<Inserta DOCUMENTOS EN LA SECCION PERFILES>
-- =============================================
CREATE PROCEDURE [dbo].[SetDocsSecondLevel] 
	-- Add the parameters for the stored procedure here
	@ProfileId bigint,
           @Name nvarchar(50),
		   @DocName nvarchar(50),
           @Image varbinary(max),
           @Enable int  
	
AS
BEGIN
    -- Insert statements for procedure here
INSERT INTO [dbo].[DocsSecondLevel]
           ([ProfileId]
		   ,[DocName]
           ,[Name]
           ,[Image]
           ,[InsertDate]
           ,[UpdateDate]
           ,[DeleteDate]
           ,[Enable])
     VALUES
           (@ProfileId
		   ,@DocName
           ,@Name
           ,@Image
           ,getdate()
           ,null
           ,null
           ,@Enable)
		  
END

