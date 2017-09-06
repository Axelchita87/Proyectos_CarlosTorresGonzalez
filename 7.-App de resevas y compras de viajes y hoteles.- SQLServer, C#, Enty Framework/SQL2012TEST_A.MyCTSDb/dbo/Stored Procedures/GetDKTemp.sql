-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 08-05-2009
-- Modify Date  27-10-09 by Marcos Q. Ramirez, 14-01-2010 Pedro Tomas Solis
-- Description:	Procedure that gets a DK-Corporative-Justification collection
-- =============================================
CREATE Procedure [dbo].[GetDKTemp]
 @Attribute1 as varchar(50),
 @ProcessType as bit
AS
Declare
	@SendEmision bit,
	@SendReservation bit
If @ProcessType  = 0
Begin
	If Upper(substring(@Attribute1,1,3))='BSS'
		SET @Attribute1='BSS100'
	Select @SendReservation=Reservation From dbo.Attributes Where Attribute1=@Attribute1
	if @SendReservation = 1
	Begin 
		Select Distinct
			A.[NameMyCTS], A.[Class], A.[Queue], A.[Queue2], J.[Code], upper(J.[Description])as [Description]
		From [dbo].[Attributes] A 
		Left Outer Join
			[dbo].[Justifications] J ON J.[Attribute1] = A.[Attribute1] 
		Where A.[Attribute1] = @Attribute1 
	End
	Else
	Begin
		Select Distinct
			A.[NameMyCTS], A.[Class], Null as [Queue], Null as [Queue2], J.[Code], upper(J.[Description])as [Description]
		From
			[dbo].[Attributes] A 
		Left Outer Join
			[dbo].[Justifications] J ON J.[Attribute1] = A.[Attribute1]   
		Where A.[Attribute1] = @Attribute1 
	End
End
Else
Begin
	Select @SendEmision=Emision From dbo.Attributes Where Attribute1=@Attribute1
	if @SendEmision = 1
	Begin 
		Select Distinct
			A.[NameMyCTS], A.[Class], A.[Queue], A.[Queue2], J.[Code], upper(J.[Description])as [Description]
		From
			[dbo].[Attributes] A 
		Left Outer Join
			[dbo].[Justifications] J ON J.[Attribute1] = A.[Attribute1] 
		Where A.[Attribute1] = @Attribute1 
	End
	Else
	Begin
		Select Distinct
			A.[NameMyCTS],A.[Class], Null as [Queue], Null as [Queue2], J.[Code], upper(J.[Description])as [Description]
		From
			[dbo].[Attributes] A 
		Left Outer Join
			[dbo].[Justifications] J ON J.[Attribute1] = A.[Attribute1]
		Where A.[Attribute1] = @Attribute1 
	End
End

