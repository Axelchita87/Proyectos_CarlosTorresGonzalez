-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Modify:		Luis Felipe Segura Velasco
-- Create date: <06/Febrero/2010>
-- Modify date: 9 de Julio de 2012
-- Description:	<Obtiene informacion de estrella de primer nivel>
-- =============================================
CREATE PROCEDURE [dbo].[GetStar1stLevelInfo] 
	@Pccid nvarchar(10),
    @Level1 nvarchar(50)
AS
BEGIN
	SELECT S1.Pccid,
	  S1.Level1,
	  S1.[Type],
	  S1.[Text],
	  S1.Date,
	  isnull(S1.Purged,0) Purged,
	  CPL.[ORDER]
	FROM dbo.Star1 S1
	INNER JOIN dbo.CatProfileLines CPL
	ON S1.[Type]   =CPL.[Type]
	WHERE S1.Pccid = @Pccid
	AND S1.Level1  = @Level1
	ORDER BY CPL.[ORDER]
END
-- =============================================
-- EXEC dbo.GetStar1stLevelInfo '3L64','BMA100'
-- =============================================