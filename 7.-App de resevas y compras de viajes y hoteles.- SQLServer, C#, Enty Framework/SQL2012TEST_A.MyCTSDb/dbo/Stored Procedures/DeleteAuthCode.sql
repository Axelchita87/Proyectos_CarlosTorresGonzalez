

-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: <26-09-2011>
-- Description:	<Gets an AuthCode in AuthCCPending>
-- =============================================

CREATE PROCEDURE [dbo].[DeleteAuthCode] 
-- Input variables
@pnr as varchar(6)

AS
BEGIN
    -- Insert statements for procedure 
	delete from dbo.AuthCCPending
	where PNR=@pnr
END