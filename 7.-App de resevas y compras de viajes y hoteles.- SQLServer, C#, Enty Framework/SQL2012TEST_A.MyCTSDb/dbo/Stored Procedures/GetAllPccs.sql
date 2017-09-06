


-- =============================================
-- Author:		Jessica Gutiérrez Becerril
-- Create date: 04-05-2010
-- Description:	Procedure that get a Pcc 
-- =============================================
CREATE Procedure [dbo].[GetAllPccs]
 @StrToSearch as varchar(10),
 @OrgId int
AS

Begin
	Select CatPccId,CatPccName,Status,StandardClass,SpecificClass,Confirmation,
			BusinessClass1,BusinessClass2,BusinessClass3,BusinessClass4
	from dbo.CatPccs P inner join MyCTSSecurityDb.dbo.Applications A on A.ApplicationId=P.ApplicationId
	where CatPccId=@StrToSearch and OrgId=@OrgId
End

