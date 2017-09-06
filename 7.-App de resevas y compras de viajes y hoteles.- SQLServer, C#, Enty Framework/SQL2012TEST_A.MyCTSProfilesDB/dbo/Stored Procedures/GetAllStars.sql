-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Modify:		Luis Felipe Segura Velasco
-- Create date: <05/Febrero/2010>
-- Modify date: 11 de Mayo de 2012
-- Description:	<Obtiene el catalogo de todas las estrellas de primer y segundo nivel>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllStars] 
	@OrgId int,
	@Name varchar(50) = '%',
	@TipoBusqueda varchar(10) = '%'
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @ApplicationId UNIQUEIDENTIFIER

	SELECT 
		@ApplicationId = ApplicationId
	FROM   
		MyCTSSecurityDb.dbo.Applications WITH(NOLOCK)
	WHERE  
		OrgId=@OrgId
	
	SELECT 
		DISTINCT CatPccId
	INTO
		#tblCatPccId
	FROM 
		MyCTSDb.dbo.CatPccs CP WITH(NOLOCK)
	WHERE	
		cp.ApplicationId = @ApplicationId

	IF @TipoBusqueda = 'DK'
	BEGIN
		SELECT CF.Pccid 'PccId',
			   CF.Star1Name 'StarName',
			   '1' 'Level',
			   NULL 'Star1Ref',
			   CF.Active,
			   CF.IsNew,
			   NULL 'Email',
			   CF.DK
		FROM   dbo.CatStarsFirstLevel CF WITH(NOLOCK)
			   LEFT JOIN #tblCatPccId CP
			   ON     CF.Pccid=CP.CatPccId
		WHERE	CF.Star1Name LIKE @Name + '%'
	END
	ELSE
	BEGIN
		SELECT * FROM 
		(
			SELECT CF.Pccid 'PccId',
				   CF.Star1Name 'StarName',
				   '1' 'Level',
				   NULL 'Star1Ref',
				   CF.Active,
				   CF.IsNew,
				   NULL 'Email',
				   CF.DK
			FROM   dbo.CatStarsFirstLevel CF WITH(NOLOCK)
				   LEFT JOIN #tblCatPccId CP
				   ON     CF.Pccid=CP.CatPccId
			WHERE	CF.Star1Name LIKE @Name + '%'
			AND		CF.Active = 1		
			UNION ALL
			SELECT CS.Pccid,
				   CS.Star2Name,
				   '2',
				   CS.Star1id,
				   CS.Active,
				   CS.IsNew,
				   s2.Email,
				   NULL
			FROM   dbo.CatStarsSecondLevel CS WITH(NOLOCK)
				   LEFT OUTER JOIN tblCorreos s2 WITH(NOLOCK)
				   ON     s2.pccId  = cs.Pccid
				   AND    s2.Level2 = CS.Star2Name
				   AND    s2.level1 = cs.Star1Id
				   LEFT OUTER JOIN #tblCatPccId CP
				   ON     CS.Pccid=CP.CatPccId
			WHERE	CS.Star2Name LIKE @Name + '%'
			AND		CS.Active = 1
		) AS TB
		ORDER BY [Level], StarName
	END
	DROP TABLE #tblCatPccId
END
-- =============================================
-- EXEC [GetAllStars] 85, 'alfo',''
-- EXEC [GetAllStars] 85, 'PNU','dk'
-- =============================================



