

-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Creation date: <26-09-2011>
-- Description:	<Insert an AuthCode in AuthCCPending>
-- =============================================

CREATE PROCEDURE [dbo].[SetAuthCode] 
-- Input variables
@pnr as varchar(6),
@authCode as varchar(6),
@cardType as varchar(2),
@amount as varchar(50),
@bank as varchar(50),
@ticket as varchar (max),
@date as datetime,
@commandWP as varchar (50)



AS
BEGIN
    -- Insert statements for procedure 
    INSERT INTO dbo.LogAuthCCPending(PNR,AuthCode,CardType, Amount, Bank, Ticket, Date, CommandWP)
	VALUES(@pnr,@authCode,@cardType,@amount,@bank, @ticket, @date, @commandWP)
END