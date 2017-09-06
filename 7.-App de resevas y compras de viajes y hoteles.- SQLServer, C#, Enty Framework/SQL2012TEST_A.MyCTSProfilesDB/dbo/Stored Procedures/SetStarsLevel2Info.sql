





-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <22/Enero/2010>
-- Description:	<Inserta los datos de estrellas de primer nivel>
-- =============================================
CREATE PROCEDURE [dbo].[SetStarsLevel2Info] 
	-- Add the parameters for the stored procedure here
	@Pccid varchar(10), 
    @Level1 nvarchar(50),
    @Level2 nvarchar(50),
    @Type varchar(1),
    @Text varchar(100),
    @Date datetime,
    @Purged bit
	
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO dbo.Star2(Pccid, Level1, Level2, [Type], [Text], Date, Purged)
	VALUES(@Pccid, @Level1, @Level2, @Type, @Text, @Date, @Purged)

END









