

-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: <26-09-2011>
-- Description:	<Gets an AuthCode in AuthCCPending>
-- =============================================

CREATE PROCEDURE [dbo].[GetAuthCode] 
-- Input variables
@pnr as varchar(6)

AS
BEGIN
    -- Insert statements for procedure 
    SELECT PNR,AuthCode,CardType, Amount, Bank, Ticket, Date, CommandWP FROM dbo.LogAuthCCPending
	WHERE PNR=@pnr 
	--and Ticket is NULL
END