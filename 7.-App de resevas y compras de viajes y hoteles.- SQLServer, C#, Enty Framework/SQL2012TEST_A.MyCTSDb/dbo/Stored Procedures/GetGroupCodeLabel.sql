-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 18-02-2010
-- Description:	Procedure that gets the Label XML Remarks for a GroupCode
-- =============================================
CREATE Procedure [dbo].[GetGroupCodeLabel]
 @RemarkValue as varchar(200)
AS
Begin
	Declare
	--Variables
	@XMLInitialLabel varchar(10),
	@XMLFinalLabel varchar(10),
	@XMLFutureLabel varchar(65),
	@Cmd varchar (50),
	@CmdLbl varchar(50),
	@Status int
	--Get the XML Labels
	Select @XMLInitialLabel = [CommandERP],
		   @XMLFinalLabel = [LabelCommandERP] 
	From [dbo].[LabelsRemarks] 
	Where [IDRemarkLabel] = 'XMLLabel'
	--Get the commands for an ERP label
	Select	@Cmd = [CommandERP],
			@CmdLbl = [LabelCommandERP] 
	From [dbo].[LabelsRemarks] 
	Where [IDRemarkLabel] = 'GroupCode'
	Set @XMLFutureLabel = @Cmd + @XMLInitialLabel + @CmdLbl + '*' + @RemarkValue + @XMLFinalLabel	
	Select @XMLFutureLabel as XMLFutureLabel
End
