-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Modify:		Luis Felipe Segura Velasco
-- Create date: <05/Febrero/2010>
-- Modify date: 11 de Mayo de 2012
-- Description:	<Obtiene el catalogo de todas las estrellas de primer y segundo nivel>
-- =============================================
CREATE PROCEDURE [dbo].[GetProfiles2LevelByFirstLevel] 
	@OrgId int,
	@Level1 varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @ApplicationId UNIQUEIDENTIFIER

	SELECT 
		@ApplicationId = ApplicationId
	FROM   
		MyCTSSecurityDb.dbo.Applications
	WHERE  
		OrgId=@OrgId

	SELECT 
		DISTINCT CatPccId
	INTO
		#tblCatPccId
	FROM 
		MyCTSDb.dbo.CatPccs CP
	WHERE	
		cp.ApplicationId = @ApplicationId

	SELECT CS.Pccid,
		   CS.Star2Name,
		   '2' as [Level],
		   CS.Star1id as Star1Ref,
		   CS.Active,
		   CS.IsNew,
		   s2.Email,
		   NULL as DK
	FROM   dbo.CatStarsSecondLevel CS
		   LEFT OUTER JOIN tblCorreos s2
		   ON     s2.pccId  = cs.Pccid
		   AND    s2.Level2 = CS.Star2Name
		   AND    s2.level1 = cs.Star1Id
		   LEFT OUTER JOIN #tblCatPccId CP
		   ON     CS.Pccid=CP.CatPccId
	WHERE	s2.level1 LIKE @Level1 + '%'

	DROP TABLE #tblCatPccId
END
-- =============================================
-- EXEC GetProfiles2LevelByFirstLevel 85, 'cfe101'
-- =============================================