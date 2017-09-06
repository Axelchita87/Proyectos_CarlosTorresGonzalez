-- =============================================
-- Author:		Emmanuel Flores
-- Create date: 19/05/2011
-- Description:	busca y debuelve los resultados de los email
--				de los pasajeros
-- =============================================
CREATE PROCEDURE [dbo].[GetStar2ProfileByEmail] 
	-- Add the parameters for the stored procedure here
	 @vEmail varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Pccid, Level1, Level2, [Type], [Text], Date, Purged
	from Star2 where Email like 'PE‡'+@vEmail+'%'
END
