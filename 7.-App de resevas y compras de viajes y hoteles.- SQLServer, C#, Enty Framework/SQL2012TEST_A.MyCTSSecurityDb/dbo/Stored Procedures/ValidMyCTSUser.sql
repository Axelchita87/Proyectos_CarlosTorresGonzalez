


-- =============================================
-- Author:		Marcos Ramirez Luna
-- Create date: 10-05-2012
-- Modify Date  
-- Description:	Procedure that validate an active user 
-- =============================================
create  PROCEDURE [dbo].[ValidMyCTSUser] (
	@Firma nvarchar(50), 
	@PCC nvarchar(50)
)
AS

SELECT TOP 1 FIRM AS ROW
	FROM [Users] U
WHERE
	[Firm] = @Firma
AND [PCC] = @PCC
AND [UPGRADESTATUS] = '2'



