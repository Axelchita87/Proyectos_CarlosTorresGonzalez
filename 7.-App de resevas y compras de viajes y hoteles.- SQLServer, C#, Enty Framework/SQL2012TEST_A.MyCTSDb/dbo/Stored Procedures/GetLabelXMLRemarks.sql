-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 12-06-2009, Modified: 03-02-2010
-- Description:	Procedure that gets the Label XML Remarks of a corporative
-- =============================================
CREATE Procedure [dbo].[GetLabelXMLRemarks]
 --Parameters
 @Attribute1 as varchar(10),
 @IDProcess as varchar(50),
 --@TicketPosition AS VARCHAR(3),
 @RemarkValue as varchar(200)
AS
Declare
  --Variables
  --@IDCorporative varchar(50),
  @XMLInitialLabel varchar(10),
  @XMLFinalLabel varchar(10),
  @XMLActualLabel varchar(65),
  @XMLFutureLabel varchar(65),
  @Cmd varchar (50),
  @CmdLbl varchar(50),
  @CancellationStatus varchar(1),
  @Status int

  --Search for IDCorporative that corresponds to @Attribute1
--  Select @IDCorporative = CorporativeID
--  From dbo.DK
--  Where IDDK = @Attribute1
  --Search for Cancellation Status of IDCorporative
  Select @CancellationStatus = Cancellation 
  From dbo.QualityControls
  Where Attribute1 = @Attribute1
  --If Cancellation Status for @Attribute1 is Active
  If(@CancellationStatus = 'A')	
  Begin
	--Get the XML Labels
	Select @XMLInitialLabel = [CommandERP],
		   @XMLFinalLabel = [LabelCommandERP] 
	From [dbo].[LabelsRemarks] 
	Where [IDRemarkLabel] = 'XMLLabel'
	--Search the type of Status for the construction of the Label	
	Select @Status = [Status] From dbo.QualityControls Where [Attribute1] = @Attribute1
	--If Corporative Status is normal
	if(@Status = 1)
	Begin
		--Get the Commands for a normal label
		Select	@Cmd = [Command],
				@CmdLbl = [LabelCommand] 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = @IDProcess 
		Set @XMLActualLabel = @Cmd + @XMLInitialLabel + @CmdLbl + @RemarkValue + @XMLFinalLabel
		Select @XMLActualLabel as XMLActualLabel, @XMLFutureLabel as XMLFutureLabel
	End
	--If Corporative Status is both: Normal + ERP
	if(@Status = 2)
	Begin
		--Get the commands for a normal label
		Select	@Cmd = [Command],
				@CmdLbl = [LabelCommand] 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = @IDProcess
		--Set @XMLActualLabel = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @TicketPosition + '*' + @RemarkValue + @XMLFinalLabel
		Set @XMLActualLabel = @Cmd + @XMLInitialLabel + @CmdLbl + '*' + @RemarkValue + @XMLFinalLabel
		--Get the commands for an ERP label
		Select	@Cmd = [CommandERP],
				@CmdLbl = [LabelCommandERP] 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = @IDProcess 
		--@Cmd + @XMLInitialLabel + @CmdLbl + @RemarkValue + @XMLFinalLabel
		If @IdProcess = 'GroupCode'
			Set @XMLFutureLabel = @Cmd + @XMLInitialLabel + @CmdLbl + '*' + @RemarkValue + @XMLFinalLabel	
		Else
			--Set @XMLFutureLabel = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @TicketPosition + '*' + @RemarkValue + @XMLFinalLabel	
			Set @XMLFutureLabel = @Cmd + @XMLInitialLabel + @CmdLbl + '*' + @RemarkValue + @XMLFinalLabel	
		Select @XMLActualLabel as XMLActualLabel, @XMLFutureLabel as XMLFutureLabel
	End
	--If Corporative Status is ERP
	if(@Status = 3)
	Begin
		--Get the commands for an ERP label
		Select	@Cmd = [CommandERP],
				@CmdLbl = [LabelCommandERP] 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = @IDProcess 
		--@Cmd + @XMLInitialLabel + @CmdLbl + @RemarkValue + @XMLFinalLabel
		If @IdProcess = 'GroupCode'
			Set @XMLFutureLabel = @Cmd + @XMLInitialLabel + @CmdLbl + '*' + @RemarkValue + @XMLFinalLabel	
		Else
			Set @XMLFutureLabel = @Cmd + @XMLInitialLabel + @CmdLbl + '*' + @RemarkValue + @XMLFinalLabel	
			--Set @XMLFutureLabel = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @TicketPosition + '*' + @RemarkValue + @XMLFinalLabel	
		Select @XMLActualLabel as XMLActualLabel, @XMLFutureLabel as XMLFutureLabel
	End
  End
  Else--If(@CancellationStatus = 'I')	
  Begin
		Set @XMLActualLabel = Null
		Set @XMLFutureLabel = Null
		Select @XMLActualLabel as XMLActualLabel, @XMLFutureLabel as XMLFutureLabel
  End
