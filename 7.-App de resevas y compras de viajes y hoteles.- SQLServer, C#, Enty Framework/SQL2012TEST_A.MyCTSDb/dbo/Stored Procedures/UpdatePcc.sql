CREATE Procedure [dbo].[UpdatePcc]
@Pcc as varchar(6),
 @CatPccName as varchar(50),
 @ApplicationId as varchar(50),
 @Type as varchar(50),
 @Tool as varchar(50),
 @GDS as varchar(50)
AS

Begin
	Update dbo.CatPccs
	Set CatPccName=@CatPccName,ApplicationId=@ApplicationId, Type=@Type,Tool=@Tool,GDS=@GDS
	where CatPccId=@Pcc
End