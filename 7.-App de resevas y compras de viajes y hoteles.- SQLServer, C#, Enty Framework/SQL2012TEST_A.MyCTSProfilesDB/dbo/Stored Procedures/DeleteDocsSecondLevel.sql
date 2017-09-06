-- =============================================
-- Author:		<orihuela Ulises>
-- Create date: <02/DICIEMBRE/2010>
-- Description:	<DESHABILITA DOCUMENTOS DEL PERFIL>
--exec [DeleteDocsSecondLevel]  116205 , '2014/12/12' , 6
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDocsSecondLevel] 
	-- Add the parameters for the stored procedure here
		   @ProfileId bigint,
		   @DeleteDate smalldatetime,
           @imageId int
	
AS
BEGIN
    -- Insert statements for procedure here

	Update [DocsSecondLevel]
	set [DeleteDate] = @DeleteDate , [Enable]  = 0 
	where [ProfileId] = @ProfileId and ImageId = @imageId 

END

