
-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <10/Marzo/2010>
-- Description:	<Inserta datos acerca de modificaciones en estrellas de 1er y 2do nivel>
-- =============================================
CREATE PROCEDURE [dbo].[SetProfileChanges] 
	-- Add the parameters for the stored procedure here
	@Pccid nvarchar(10), 
    @Agent nvarchar(10),
	@StarLevel1 nvarchar(50),
    @StarLevel2 nvarchar(50),
    @ModifiedDate datetime
	
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO  dbo.ProfilesChanges_log(Pcc, Agent, StarLevel1, StarLevel2, ModifiedDate)
	VALUES(@Pccid, @Agent, @StarLevel1, @StarLevel2, @ModifiedDate)

END



