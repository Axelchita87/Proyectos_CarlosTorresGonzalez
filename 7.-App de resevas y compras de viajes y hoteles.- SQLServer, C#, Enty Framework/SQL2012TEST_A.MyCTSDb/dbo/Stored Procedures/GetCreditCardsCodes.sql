-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 16-04-2009
-- Description:	Procedure that gets a CreditCardsCodes collection
-- =============================================
CREATE Procedure [dbo].[GetCreditCardsCodes]
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
-- If (@StrToSearch = 'All')
--	Begin
--		Select Distinct CatCreCarCodCode, CatCreCarCodName
--		From dbo.CatCreditCardCodes
--		Order By CatCreCarCodName
--	End
 if(@LenStrToSearch < 3)--@LenStrToSearch = 1 or @LenStrToSearch = 2)
	  --Searching by Code, two chars
	  Begin
		Select Distinct CatCreCarCodCode, CatCreCarCodName
		From dbo.CatCreditCardCodes
		Where CatCreCarCodCode like @StrToSearch + '%'
	  End
 else --if(@LenStrToSearch > 2 and @StrToSearch <> 'All')
	  -- Searching By Name, > two chars
	  Begin
		Select Distinct CatCreCarCodCode, CatCreCarCodName
		From dbo.CatCreditCardCodes
		Where CatCreCarCodName like @StrToSearch + '%'
		Order By CatCreCarCodName
	  End
 End





