


-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 17-04-2009
-- Description:	Procedure that gets a Pccs collection
-- =============================================
CREATE Procedure [dbo].[GetPccs]
 @StrToSearch as varchar(10),
 @OrgId as int
AS
 Declare @LenStrToSearch int
 set @LenStrToSearch = len(@StrToSearch)
Begin
 if(@LenStrToSearch < 5)--@LenStrToSearch >= 1 and @LenStrToSearch <= 4)
	  --Searching by Code, four chars
	  Begin
		Select Distinct CatPccId, CatPccName
		From dbo.CatPccs P inner join MyCTSSecurityDb.dbo.Applications A on A.ApplicationId = P.ApplicationId
		Where CatPccId like @StrToSearch + '%' and OrgId=@OrgId
	  End
 else --if(@LenStrToSearch > 4)
	  -- Searching By Name, > four chars
	  Begin
		Select Distinct CatPccId, CatPccName
		From dbo.CatPccs P inner join MyCTSSecurityDb.dbo.Applications A on A.ApplicationId = P.ApplicationId
		Where CatPccName like @StrToSearch + '%' and OrgId=@OrgId
		Order By CatPccName
	  End
 End





