-- =============================================
-- Author:		<orihuela Ulises>
-- Create date: <02/DICIEMBRE/2010>
-- Description:	<ACTUALIZA DOCUMENTOS DEL PERFIL>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateDocsSecondLevel] 
	-- Add the parameters for the stored procedure here
		   @ProfileId bigint,
           @imageId int,
           @Image varbinary(max),
           @UpdateDate smalldatetime,
		   @Enable int,
		   @docName varchar(50),
		   @name varchar(50)
	
AS
BEGIN
    -- Insert statements for procedure here

	Update [DocsSecondLevel]
	set [Image] = @image , [UpdateDate] = @UpdateDate , [Enable] = @Enable , [DocName] = @docName , [Name] =@name
	where [ProfileId] = @ProfileId and ImageId = @imageId 

END

