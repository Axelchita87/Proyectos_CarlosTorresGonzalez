




-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: <04-06-2010>
-- Description:	<Insert a PCC in CatPccs>
-- =============================================
CREATE PROCEDURE [dbo].[SetPCCs] 
	-- Input variables
	@CatPccId varchar(50), 
	@CatPccName varchar(150),
	@Status varchar(1),
	@StandardClass varchar(1), 
	@SpecificClass varchar(1),
	@Confirmation varchar(1),
	@BusinessClass1 varchar(1), 
	@BusinessClass2 varchar(1),
	@BusinessClass3 varchar(1),
	@BusinessClass4 varchar(1),
	@OrgId int


AS
BEGIN
	DECLARE @ApplicationId AS UNIQUEIDENTIFIER

	SELECT @ApplicationId=ApplicationId FROM MyCTSSecurityDb.dbo.Applications
	WHERE OrgId=@OrgId
    -- Insert statements for procedure 
    INSERT INTO dbo.CatPccs(CatPccId,CatPccName,Status,StandardClass,SpecificClass,
							Confirmation,BusinessClass1,BusinessClass2,BusinessClass3,
							BusinessClass4, ApplicationId)
	VALUES(@CatPccId, @CatPccName,@Status,@StandardClass, @SpecificClass,
		   @Confirmation,@BusinessClass1, @BusinessClass2,@BusinessClass3,
		   @BusinessClass4, @ApplicationId)
END
