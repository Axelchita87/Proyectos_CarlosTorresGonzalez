
-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <06/Febrero/2010>
-- Description:	<Obtiene informacion de estrella de segundo nivel>
-- =============================================
CREATE PROCEDURE [dbo].[GetStar2ndLevelInfo] 
	-- Add the parameters for the stored procedure here
	@Pccid nvarchar(10),
    @Level1 nvarchar(50),
    @Level2 nvarchar(50)

	
AS
BEGIN
    -- Select statements for procedure here

	SELECT S2.Pccid, S2.Level1, S2.Level2, S2.[Type], S2.[Text], S2.Date, S2.Purged, CPL.[Order] 
	from dbo.Star2 S2 Inner join dbo.CatProfileLines CPL On S2.[Type]=CPL.[Type]
	WHERE S2.Pccid = @Pccid and S2.Level1 = @Level1 and S2.Level2 = @Level2
	ORDER BY CPL.[Order]

	

END












