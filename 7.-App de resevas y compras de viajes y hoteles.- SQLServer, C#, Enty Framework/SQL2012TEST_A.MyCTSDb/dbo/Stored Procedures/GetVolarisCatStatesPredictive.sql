-- =============================================
-- Author:	Jessica Gutierrez
-- Create date: 16/12/13
-- Description:	Extrae los Estados de Volaris
-- =============================================
CREATE PROCEDURE [dbo].[GetVolarisCatStatesPredictive] 
 @StrToSearch as varchar(10)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
 if(@LenStrToSearch < 4)
	  Begin
		Select Distinct Code, Name
		From dbo.VolarisCatStates
		Where Code like @StrToSearch + '%'
	  End
 else 
	  Begin
		Select Distinct Code, Name
		From dbo.VolarisCatStates
		Where Name like @StrToSearch + '%'
		Order By Name
	  End
 End
