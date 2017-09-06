-- =============================================
-- Author:		Jessica Gutierrez Becerril
-- Modify:		Luis Felipe Segura Velasco
-- Create date: 10-05-2010
-- Modifu date: 23 de mayo de 2013
-- Description:	Enable Disable Firm by Agent
-- =============================================
CREATE PROCEDURE dbo.spEnableDisableFirm 
	@Firm nvarchar (50),
	@PCC nvarchar(50),
	@Active int 
AS
BEGIN
	SET NOCOUNT ON;

	IF (@Active = 1)
	BEGIN
		UPDATE 
			[Users]
		SET 
			[Firm] = SUBSTRING(@Firm,0,5)
		WHERE 
			[Firm] = @Firm
		AND 
			[PCC] = @PCC 
	END
	ELSE
	BEGIN
		UPDATE 
			[Users] 
		SET 
			[StatusFirm] = 'I',			
			[DateOut] = GETDATE()
		WHERE 
			[Firm] = @Firm 
		AND 
			[PCC] = @PCC
	END
END
-- =======================================================
-- EXEC spEnableDisableFirm 
-- =======================================================