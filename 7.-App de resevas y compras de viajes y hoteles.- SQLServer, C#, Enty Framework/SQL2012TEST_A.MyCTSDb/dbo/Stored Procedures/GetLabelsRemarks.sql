-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 21-05-2009
-- Description:	Procedure that gets a LabelsRemarks collection
-- =============================================
Create Procedure [dbo].[GetLabelsRemarks]
 @StrToSearch as varchar(50)
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
 Begin
	Select Command
	From dbo.LabelsRemarks
	Where ( IDRemarkLabel = @StrToSearch ) 
 End
