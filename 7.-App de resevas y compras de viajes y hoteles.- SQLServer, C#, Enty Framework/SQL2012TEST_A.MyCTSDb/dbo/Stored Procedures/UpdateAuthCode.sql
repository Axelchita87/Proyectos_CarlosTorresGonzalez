

-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: <26-09-2011>
-- Description:	<Update an AuthCode in AuthCCPending>
-- =============================================

CREATE PROCEDURE [dbo].[UpdateAuthCode] 
-- Input variables
@pnr as varchar(6),
@authCode as varchar(6),
@ticket as varchar(max)

AS
BEGIN
    -- Update statements for procedure 
    UPDATE dbo.LogAuthCCPending
	SET Ticket=@ticket
	WHERE PNR=@pnr and AuthCode=@authCode
END