-- =============================================
-- Author:		José Ricardo Brito Ortega
-- Create date: 14/07/2014
-- Description:	Obtiene las aerolineas de bajo costo
-- =============================================
CREATE PROCEDURE GetLCCAirlines
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Id], [Data] AS Airline FROM fnSplitString((SELECT [Values] FROM Parameter WHERE ParameterName = 'AirlinesLLCClipboard'), '|')
END
