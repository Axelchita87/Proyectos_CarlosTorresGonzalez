
CREATE Procedure [dbo].[InsertPcc]
  @CatPccId as varchar(9),
 @CatPccName as varchar(50),
 @ApplicationId as varchar(50),
 @Type as varchar(50),
 @Tool as varchar(50),
 @GDS as varchar(50)
AS

Begin
	Insert Into dbo.CatPccs(CatPccId,CatPccName,[Status],ApplicationId,[Type],Tool,GDS,ActiveDate)
	Values(@CatPccId,@CatPccName,'A',@ApplicationId,@Type,@Tool,@GDS,getdate())
End
-- =============================================
-- 
-- =============================================
