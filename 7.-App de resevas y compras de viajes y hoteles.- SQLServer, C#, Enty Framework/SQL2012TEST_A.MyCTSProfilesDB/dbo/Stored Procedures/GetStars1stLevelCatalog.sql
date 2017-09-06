
-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <22/Enero/2010>
-- Description:	<Obtiene el catalogo de estrellas de primer nivel por pseudo>
-- =============================================
CREATE PROCEDURE [dbo].[GetStars1stLevelCatalog] 
	-- Add the parameters for the stored procedure here
--	@Pccid nvarchar(10)
@OrgId int
	
AS
BEGIN
    -- Select statements for procedure here
	declare @ApplicationId as uniqueidentifier 
	select  @ApplicationId =ApplicationId from MyCTSSecurityDb.dbo.Applications where OrgId=@OrgId

	select Pccid, Star1Name, StarL2Exist from dbo.CatStarsFirstLevel S
	inner join MyCTSDb.dbo.CatPccs CP on S.Pccid=CP.CatPccId 
	where ApplicationId=@ApplicationId and IsNew='True'

	--WHERE Pccid = @Pccid

END









