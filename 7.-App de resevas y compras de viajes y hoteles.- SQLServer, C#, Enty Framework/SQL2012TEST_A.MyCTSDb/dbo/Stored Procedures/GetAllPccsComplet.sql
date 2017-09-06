CREATE Procedure [dbo].[GetAllPccsComplet]
@OrgId int
AS

Begin
	Select CatPccId,CatPccName,Status,StandardClass,SpecificClass,Confirmation,
			BusinessClass1,BusinessClass2,BusinessClass3,BusinessClass4, Type, Tool, GDS, ActiveDate
	from dbo.CatPccs P inner join MyCTSSecurityDb.dbo.Applications A on A.ApplicationId=P.ApplicationId
	where OrgId=@OrgId 
	
End

