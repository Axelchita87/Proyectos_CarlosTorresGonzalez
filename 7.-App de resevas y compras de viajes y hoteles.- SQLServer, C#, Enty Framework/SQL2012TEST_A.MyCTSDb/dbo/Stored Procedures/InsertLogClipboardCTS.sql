
-- =============================================
-- Author:		José Ricardo Brito Ortega
-- Create date: 09/10/2014
-- Description:	Inserta registro de transacciones en el modulo de clipboard de MyCTS v2
-- =============================================
CREATE PROCEDURE [dbo].[InsertLogClipboardCTS]
	-- Add the parameters for the stored procedure here
	@date DATETIME,
	@agent VARCHAR(2),
	@optionUsed TINYINT,
	@pnr VARCHAR(6)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRY
		BEGIN TRAN LogClipboardCTS
			INSERT INTO LogClipboardCTS ([Date], Agent, OptionUsed, PNR) VALUES(@date, @agent, @optionUsed, @pnr)
		
		COMMIT TRAN LogClipboardCTS		
		SELECT @@IDENTITY AS ID;
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN LogClipboardCTS
		SELECT '-1' AS ID
	END CATCH
END

