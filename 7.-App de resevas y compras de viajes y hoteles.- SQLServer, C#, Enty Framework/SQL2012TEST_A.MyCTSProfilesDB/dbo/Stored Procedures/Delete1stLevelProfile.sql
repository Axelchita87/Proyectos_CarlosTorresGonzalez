
-- =============================================
-- Author:		<Ivan Martínez>
-- Create date: <07/Septiembre/2011>
-- Description:	<Procedure that delete a 1st Level Profile and 2nd Level Profiles>
-- =============================================
CREATE PROCEDURE [dbo].[Delete1stLevelProfile]
@1stLevelName AS VARCHAR (50),
@Pcc AS VARCHAR (4)
AS
BEGIN
DECLARE @id AS INT
DECLARE @value AS VARCHAR(50)

--ELIMINA REGISTRO DEL CATÁLOGO PRINCIPAL

DELETE FROM dbo.CatStarsFirstLevel
WHERE Pccid=@Pcc and Star1Name=@1stLevelName

--ELIMINA INFORMACIÓN Y PERFILES DE SEGUNDO NIVEL
SELECT Id, [Value] FROM dbo.Stars
WHERE [Value]=@1stLevelName order by Id

DELETE FROM dbo.Stars
WHERE Id=@id

DELETE FROM dbo.Star1
WHERE Pccid=@Pcc and Level1=@1stLevelName

DELETE FROM dbo.CatStarsSecondLevel
WHERE Star1id=@1stLevelName

END

-----------------------------------------------------------------------------------------------


/****** Object:  StoredProcedure [dbo].[Delete2ndLevelProfile]    Script Date: 11/04/2011 18:11:35 ******/
SET ANSI_NULLS ON
