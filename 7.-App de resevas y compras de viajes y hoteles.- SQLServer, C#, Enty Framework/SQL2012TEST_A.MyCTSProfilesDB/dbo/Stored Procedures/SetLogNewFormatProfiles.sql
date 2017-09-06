



-- =============================================
-- Author:		<Ivan Martinez Guerrero>
-- Create date: <27/Enero/2010>
-- Description:	<Inserta Log>
-- =============================================
CREATE PROCEDURE [dbo].[SetLogNewFormatProfiles] 
	-- Add the parameters for the stored procedure here
	@Pccid nvarchar(10),
	@userName nvarchar(50), 
	@Star1Name nvarchar(50),
    @Star2Name nvarchar(50),
	@date datetime
    
	
AS
BEGIN
    -- Insert statements for procedure here
	INSERT INTO  dbo.LogNewFormatProfiles(Pcc, UserName, StarLevel1, StarLevel2, ModifiedDate)
	VALUES(@Pccid, @userName, @Star1Name, @Star2Name, @date )

END