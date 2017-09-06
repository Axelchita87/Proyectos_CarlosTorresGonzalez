-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 30-06-09
-- Description:	Procedure that gets all Corporative Quality Controls collection for XML Remarks
-- =============================================
CREATE Procedure [dbo].[GetValuesXMLQualityControls]
	--Parameters
	@DKToSearch varchar(10),
	@C1 varchar(60),
	@C2 varchar(60),
	@C3 varchar(60),
	@C4 varchar(60),
	@C5 varchar(60),
	@C6 varchar(60),
	@C7 varchar(60),
	@C8 varchar(60),
	@C9 varchar(60),
	@C10 varchar(60),
	@C11 varchar(60),
	@C12 varchar(60),
	@C13 varchar(60),
	@C14 varchar(60),
	@C15 varchar(60),
	@C16 varchar(60),
	@C17 varchar(60),
	@C18 varchar(60),
	@C19 varchar(60),
	@C20 varchar(60),
	@C21 varchar(60),
	@C22 varchar(60),
	@C23 varchar(300),
	@C24 varchar(60),
	@C25 varchar(60),
	@C26 varchar(60),
	@C27 varchar(60),
	@C28 varchar(60),
	@C29 varchar(60),
	@C30 varchar(60),
	@C31 varchar(60),
	@C32 varchar(60)
AS
Declare --Variables
	@xmlC1 varchar(60),
	@xmlC2 varchar(60),
	@xmlC3 varchar(60),
	@xmlC4 varchar(60),
	@xmlC5 varchar(60),
	@xmlC6 varchar(60),
	@xmlC7 varchar(60),
	@xmlC8 varchar(60),
	@xmlC9 varchar(60),
	@xmlC10 varchar(60),
	@xmlC11 varchar(60),
	@xmlC12 varchar(60),
	@xmlC13 varchar(60),
	@xmlC14 varchar(60),
	@xmlC15 varchar(60),
	@xmlC16 varchar(60),
	@xmlC17 varchar(60),
	@xmlC18 varchar(60),
	@xmlC19 varchar(60),
	@xmlC20 varchar(60),
	@xmlC21 varchar(60),
	@xmlC22 varchar(60),
	@xmlC23 varchar(300),
	@xmlC24 varchar(60),
	@xmlC25 varchar(60),
	@xmlC26 varchar(60),
	@xmlC27 varchar(60),
	@xmlC28 varchar(60),
	@xmlC29 varchar(60),
	@xmlC30 varchar(60),
	@xmlC31 varchar(60),
	@xmlC32 varchar(60),
	@IDCorporative varchar(50),
	@Status int,
	@XMLInitialLabel varchar(10),
	@XMLFinalLabel varchar(10),
	@XMLActualLabel varchar(65),
	@XMLFutureLabel varchar(65),
	@Cmd varchar (50),
	@CmdLbl varchar(50)

	--Searching an IDCorporative that corresponds to @DKToSearch
	Select @IDCorporative = CorporativeID 
	From MyCTSDb.dbo.DK
	Where IDDK = @DKToSearch

	--Get the XML Labels
	Select @XMLInitialLabel = [CommandERP],
			@XMLFinalLabel = [LabelCommandERP] 
	From [dbo].[LabelsRemarks] 
	Where [IDRemarkLabel] = 'XMLLabel'

	--Search the type of Status for the construction of the Label	
	Select @Status = [Status] From dbo.QualityControls Where [CorporativeID] = @IDCorporative

	--If Corporative Status is ERP
	if(@Status = 2 or @Status = 3)--***Para Remarks del Futuro
	Begin
		--Get the commands for xmlC1 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C1'
		if(@C1<>'')
			Set @xmlC1 = @Cmd + @XMLInitialLabel + @CmdLbl + @C1 + @XMLFinalLabel
		--Get the commands for xmlC2 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C2'
		if(@C2<>'')
			Set @xmlC2 = @Cmd + @XMLInitialLabel + @CmdLbl + @C2 + @XMLFinalLabel
		--Get the commands for xmlC3 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C3'
		if(@C3<>'')
			Set @xmlC3 = @Cmd + @XMLInitialLabel + @CmdLbl + @C3 + @XMLFinalLabel
		--Get the commands for xmlC4 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C4'
		if(@C4<>'')
			Set @xmlC4 = @Cmd + @XMLInitialLabel + @CmdLbl + @C4 + @XMLFinalLabel
		--Get the commands for xmlC5 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C5'
		if(@C5<>'')
			Set @xmlC5 = @Cmd + @XMLInitialLabel + @CmdLbl + @C5 + @XMLFinalLabel
		--Get the commands for xmlC6 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C6'
		if(@C6<>'')
			Set @xmlC6 = @Cmd + @XMLInitialLabel + @CmdLbl + @C6 + @XMLFinalLabel
		--Get the commands for xmlC7 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C7'
		if(@C7<>'')
			Set @xmlC7 = @Cmd + @XMLInitialLabel + @CmdLbl + @C7 + @XMLFinalLabel
		--Get the commands for xmlC8 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C8'
		if(@C8<>'')
			Set @xmlC8 = @Cmd + @XMLInitialLabel + @CmdLbl + @C8 + @XMLFinalLabel
		--Get the commands for xmlC9 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C9'
		if(@C9<>'')
			Set @xmlC9 = @Cmd + @XMLInitialLabel + @CmdLbl + @C9 + @XMLFinalLabel
		--Get the commands for xmlC10 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C10'
		if(@C10<>'')
			Set @xmlC10 = @Cmd + @XMLInitialLabel + @CmdLbl + @C10 + @XMLFinalLabel
		--Get the commands for xmlC11 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C11'
		if(@C11<>'')
			Set @xmlC11 = @Cmd + @XMLInitialLabel + @CmdLbl + @C11 + @XMLFinalLabel
		--Get the commands for xmlC12 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C12'
		if(@C12<>'')
			Set @xmlC12 = @Cmd + @XMLInitialLabel + @CmdLbl + @C12 + @XMLFinalLabel
		--Get the commands for xmlC13 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C13'
		if(@C13<>'')
			Set @xmlC13 = @Cmd + @XMLInitialLabel + @CmdLbl + @C13 + @XMLFinalLabel
		--Get the commands for xmlC14 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C14'
		if(@C14<>'')
			Set @xmlC14 = @Cmd + @XMLInitialLabel + @CmdLbl + @C14 + @XMLFinalLabel
		--Get the commands for xmlC15 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C15'
		if(@C15<>'')
			Set @xmlC15 = @Cmd + @XMLInitialLabel + @CmdLbl + @C15 + @XMLFinalLabel
		--Get the commands for xmlC16 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C16'
		if(@C16<>'')
			Set @xmlC16 = @Cmd + @XMLInitialLabel + @CmdLbl + @C16 + @XMLFinalLabel
		--Get the commands for xmlC17 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C17'
		if(@C17<>'')
			Set @xmlC17 = @Cmd + @XMLInitialLabel + @CmdLbl + @C17 + @XMLFinalLabel
		--Get the commands for xmlC18 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C18'
		if(@C18<>'')
			Set @xmlC18 = @Cmd + @XMLInitialLabel + @CmdLbl + @C18 + @XMLFinalLabel
		--Get the commands for xmlC19 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C19'
		if(@C19<>'')
			Set @xmlC19 = @Cmd + @XMLInitialLabel + @CmdLbl + @C19 + @XMLFinalLabel
		--Get the commands for xmlC20 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C20'
		if(@C20<>'')
			Set @xmlC20 = @Cmd + @XMLInitialLabel + @CmdLbl + @C20 + @XMLFinalLabel
		--Get the commands for xmlC21 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C21'
		if(@C21<>'')
			Set @xmlC21 = @Cmd + @XMLInitialLabel + @CmdLbl + @C21 + @XMLFinalLabel
		--Get the commands for xmlC22 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C22'
		if(@C22<>'')
			Set @xmlC22 = @Cmd + @XMLInitialLabel + @CmdLbl + @C22 + @XMLFinalLabel
		--Get the commands for xmlC23 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C23'
		--Searching the values for Charge per service
		Declare 
			@Pattern varchar(5),
			@LocPattern int
		Set @Pattern = '%+%'
		Set	@xmlC23 = ''
		Set	@LocPattern = 1
		if(len(@C23) = 0) 
			if(@C23<>'')
				Set @xmlC23 = @Cmd + @XMLInitialLabel + @CmdLbl + @C23 + @XMLFinalLabel
		while (len(@C23) > 0) 
		Begin
			set @LocPattern = Patindex(@Pattern, @C23)
			if(@LocPattern > 0)
			Begin
				if(@C1<>'')
					set @xmlC23 = @xmlC23 + @XMLInitialLabel+ @CmdLbl + Substring(@C23,1,@LocPattern-1) + @XMLFinalLabel + '+'
				set @C23 = Substring(@C23,@LocPattern+1,len(@C23))
				set @LocPattern = 1
			End
			Else if(len(@C23) > 0)
				Begin
					set @xmlC23 = @xmlC23 + @XMLInitialLabel + @CmdLbl + @C23 +@XMLFinalLabel
					set @C23 = ''
				End
		End
		--Get the commands for xmlC24 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C24'
		if(@C24<>'')
			Set @xmlC24 = @Cmd + @XMLInitialLabel + @CmdLbl + @C24 + @XMLFinalLabel
		--Get the commands for xmlC25 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C25'
		if(@C25<>'')
			Set @xmlC25 = @Cmd + @XMLInitialLabel + @CmdLbl + @C25 + @XMLFinalLabel
		--Get the commands for xmlC26 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C26'
		if(@C26<>'')
			Set @xmlC26 = @Cmd + @XMLInitialLabel + @CmdLbl + @C26 + @XMLFinalLabel
		--Get the commands for xmlC27 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C27'
		if(@C27<>'')
			Set @xmlC27 = @Cmd + @XMLInitialLabel + @CmdLbl + @C27 + @XMLFinalLabel
		--Get the commands for xmlC28 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C28'
		if(@C28<>'')
			Set @xmlC28 = @Cmd + @XMLInitialLabel + @CmdLbl + @C28 + @XMLFinalLabel
		--Get the commands for xmlC29 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C29'
		if(@C29<>'')
			Set @xmlC29 = @Cmd + @XMLInitialLabel + @CmdLbl + @C29 + @XMLFinalLabel
		--Get the commands for xmlC30 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C30'
		if(@C30<>'')
			Set @xmlC30 = @Cmd + @XMLInitialLabel + @CmdLbl + @C30 + @XMLFinalLabel
		--Get the commands for xmlC31 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C31'
		if(@C31<>'')
			Set @xmlC31 = @Cmd + @XMLInitialLabel + @CmdLbl + @C31 + @XMLFinalLabel
		--Get the commands for xmlC32 label
		Select	@Cmd = isnull([CommandERP],''),
				@CmdLbl = isnull([LabelCommandERP],'') 
		From [dbo].[LabelsRemarks] 
		Where [IDRemarkLabel] = 'C32'
		if(@C32<>'')
			Set @xmlC32 = @Cmd + @XMLInitialLabel + @CmdLbl + @C32 + @XMLFinalLabel

		Select  
			@xmlC1 as C1,@xmlC2 as C2,@xmlC3 as C3,
			@xmlC4 as C4,@xmlC5 as C5,@xmlC6 as C6,
			@xmlC7 as C7,@xmlC8 as C8,@xmlC9 as C9,
			@xmlC10 as C10,@xmlC11 as C11,@xmlC12 as C12,
			@xmlC13 as C13,@xmlC14 as C14,@xmlC15 as C15,
			@xmlC16 as C16,@xmlC17 as C17,@xmlC18 as C18,
			@xmlC19 as C19,@xmlC20 as C20,@xmlC21 as C21,
			@xmlC22 as C22,@xmlC23 as C23,@xmlC24 as C24,
			@xmlC25 as C25,@xmlC26 as C26,@xmlC27 as C27,
			@xmlC28 as C28,@xmlC29 as C29,@xmlC30 as C30,
			@xmlC31 as C31,@xmlC32 as C32
	End

