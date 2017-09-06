
-- =============================================
-- Author:		<Ivan Martínez>
-- Create date: <07/Septiembre/2011>
-- Description:	<Procedure that delete a 2nd Level Profile>
-- =============================================
CREATE PROCEDURE [dbo].[Delete2ndLevelProfile]
@2ndLevelName as varchar (50)
AS
BEGIN
	declare @id as int
	SELECT @id=id FROM dbo.Stars
	WHERE [Value]=@2ndLevelName

	DELETE FROM dbo.Stars
	WHERE Id=@id

	DELETE FROM dbo.CatStarsSecondLevel
	WHERE Star2Name=@2ndLevelName

	DELETE FROM dbo.Star2
	WHERE Level2=@2ndLevelName
END



-----------------------------------------------------------------------------------------------

/****** Object:  StoredProcedure [dbo].[Get2StarEmail]    Script Date: 11/04/2011 18:10:17 ******/
SET ANSI_NULLS ON
