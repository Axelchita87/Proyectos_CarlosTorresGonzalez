
-- =============================================
-- Author:		<Ivan martínez Guerrero>
-- Create date: <16-Feb-2011>
-- Description:	<Procedure that sets a true status for ProductivityMail>
-- =============================================

CREATE PROCEDURE [dbo].[SetProductivityMailStatus] 
@Firm as varchar(10),	@Pcc as varchar(10)
	
AS
BEGIN
    
	UPDATE dbo.Users 
	SET ProductivityMail=1
	WHERE Firm=@Firm and PCC=@Pcc

END
