-- =============================================
-- Author:		Denisse Cestelos R.
-- Modify:		Denisse Cestelos R.
-- Create date: 26 de abril de 2013
-- Modify date: 26 de abril de 2013
-- Description:	
-- =============================================
CREATE PROCEDURE GetConsultingFirm
	@FirmtoSearch as nvarchar(50)
	
AS
BEGIN
	SET NOCOUNT ON;
	
	Select 
		Firm,
		Password,
		FamilyName,
		UserName,
		UserMail,
		AgentMail,
		Agent,
		[Queue],
		PCC,
		TA,
		MyCTSVersion,
		IsMySabreBlocked,
		StatusFirm
	from
		dbo.Users
	where
		Firm=@FirmtoSearch
END
-- =============================================
-- EXEC GetConsultingFirm '','','','','','','','','','','','',''
-- =============================================
