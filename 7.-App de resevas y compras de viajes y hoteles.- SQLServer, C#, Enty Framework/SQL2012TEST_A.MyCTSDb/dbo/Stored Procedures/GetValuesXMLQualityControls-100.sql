-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 30-06-09
-- Description:	Procedure that gets all Corporative Quality Controls collection for XML Remarks
-- =============================================
CREATE Procedure [dbo].[GetValuesXMLQualityControls-100]
	--Parameters
	@DKToSearch varchar(10),
	@PaxNumber varchar(3),
	@C1 varchar(60),
	@C2 varchar(60),
	@C3 varchar(60),
	@C4 varchar(60),
	@C5 varchar(60),
	@C6 varchar(300),
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
	@C32 varchar(60),
	@C33 varchar(60),
	@C34 varchar(60),
	@C35 varchar(60),
	@C36 varchar(60),
	@C37 varchar(60),
	@C38 varchar(60),
	@C39 varchar(60),
	@C40 varchar(60),
	@C41 varchar(60),
	@C42 varchar(60),
	@C43 varchar(60),
	@C44 varchar(60),
	@C45 varchar(60),
	@C46 varchar(60),
	@C47 varchar(60),
	@C48 varchar(60),
	@C49 varchar(60),
	@C50 varchar(60),
	@C51 varchar(60),
	@C52 varchar(60),
	@C53 varchar(60),
	@C54 varchar(60),
	@C55 varchar(60),
	@C56 varchar(60),
	@C57 varchar(60),
	@C58 varchar(60),
	@C59 varchar(60),
	@C60 varchar(60),
	@C61 varchar(60),
	@C62 varchar(60),
	@C63 varchar(60),
	@C64 varchar(60),
	@C65 varchar(60),
	@C66 varchar(60),
	@C67 varchar(60),
	@C68 varchar(60),
	@C69 varchar(60),
	@C70 varchar(60),
	@C71 varchar(60),
	@C72 varchar(60),
	@C73 varchar(60),
	@C74 varchar(60),
	@C75 varchar(60),
	@C76 varchar(60),
	@C77 varchar(60),
	@C78 varchar(60),
	@C79 varchar(60),
	@C80 varchar(60),
	@C81 varchar(60),
	@C82 varchar(60),
	@C83 varchar(60),
	@C84 varchar(60),
	@C85 varchar(60),
	@C86 varchar(60),
	@C87 varchar(60),
	@C88 varchar(60),
	@C89 varchar(60),
	@C90 varchar(60),
	@C91 varchar(60),
	@C92 varchar(60),
	@C93 varchar(60),
	@C94 varchar(60),
	@C95 varchar(60),
	@C96 varchar(60),
	@C97 varchar(60),
	@C98 varchar(60),
	@C99 varchar(60),
	@C100 varchar(60)
AS
Declare --Variables
	@xmlC1 varchar(60),
	@xmlC2 varchar(60),
	@xmlC3 varchar(60),
	@xmlC4 varchar(60),
	@xmlC5 varchar(60),
	@xmlC6 varchar(300),
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
	@xmlC33 varchar(60),
	@xmlC34 varchar(60),
	@xmlC35 varchar(60),
	@xmlC36 varchar(60),
	@xmlC37 varchar(60),
	@xmlC38 varchar(60),
	@xmlC39 varchar(60),
	@xmlC40 varchar(60),
	@xmlC41 varchar(60),
	@xmlC42 varchar(60),
	@xmlC43 varchar(60),
	@xmlC44 varchar(60),
	@xmlC45 varchar(60),
	@xmlC46 varchar(60),
	@xmlC47 varchar(60),
	@xmlC48 varchar(60),
	@xmlC49 varchar(60),
	@xmlC50 varchar(60),
	@xmlC51 varchar(60),
	@xmlC52 varchar(60),
	@xmlC53 varchar(60),
	@xmlC54 varchar(60),
	@xmlC55 varchar(60),
	@xmlC56 varchar(60),
	@xmlC57 varchar(60),
	@xmlC58 varchar(60),
	@xmlC59 varchar(60),
	@xmlC60 varchar(60),
	@xmlC61 varchar(60),
	@xmlC62 varchar(60),
	@xmlC63 varchar(60),
	@xmlC64 varchar(60),
	@xmlC65 varchar(60),
	@xmlC66 varchar(60),
	@xmlC67 varchar(60),
	@xmlC68 varchar(60),
	@xmlC69 varchar(60),
	@xmlC70 varchar(60),
	@xmlC71 varchar(60),
	@xmlC72 varchar(60),
	@xmlC73 varchar(60),
	@xmlC74 varchar(60),
	@xmlC75 varchar(60),
	@xmlC76 varchar(60),
	@xmlC77 varchar(60),
	@xmlC78 varchar(60),
	@xmlC79 varchar(60),
	@xmlC80 varchar(60),
	@xmlC81 varchar(60),
	@xmlC82 varchar(60),
	@xmlC83 varchar(60),
	@xmlC84 varchar(60),
	@xmlC85 varchar(60),
	@xmlC86 varchar(60),
	@xmlC87 varchar(60),
	@xmlC88 varchar(60),
	@xmlC89 varchar(60),
	@xmlC90 varchar(60),
	@xmlC91 varchar(60),
	@xmlC92 varchar(60),
	@xmlC93 varchar(60),
	@xmlC94 varchar(60),
	@xmlC95 varchar(60),
	@xmlC96 varchar(60),
	@xmlC97 varchar(60),
	@xmlC98 varchar(60),
	@xmlC99 varchar(60),
	@xmlC100 varchar(60),
	@IDCorporative varchar(50),
	@Status int,
	@XMLInitialLabel varchar(10),
	@XMLFinalLabel varchar(10),
	@XMLActualLabel varchar(65),
	@XMLFutureLabel varchar(65),
	@Cmd varchar (50),
	@CmdLbl varchar(50)

	--Searching an IDCorporative that corresponds to @DKToSearch
--	Select @IDCorporative = CorporativeID 
--	From dbo.DK
--	Where IDDK = @DKToSearch

	--Get the XML Labels
	Select @XMLInitialLabel = [CommandERP],
			@XMLFinalLabel = [LabelCommandERP] 
	From [dbo].[LabelsRemarks] 
	Where [IDRemarkLabel] = 'XMLLabel'

	--Search the type of Status for the construction of the Label	
	Select @Status = [Status] From dbo.QualityControls Where [Attribute1] = @DKToSearch

	--If Corporative Status is ERP
	if(@Status = 2 or @Status = 3)--***Para Remarks del Futuro
	Begin
		--Get the commands for xmlC1 label
		If (rtrim(@C1)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C1'
			if(@C1<>'')
				Set @xmlC1 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C1 + @XMLFinalLabel
		End
		--Get the commands for xmlC2 label
		If (rtrim(@C2)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C2'
			if(@C2<>'')
				Set @xmlC2 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C2 + @XMLFinalLabel
		End
		--Get the commands for xmlC3 label
		If (rtrim(@C3)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C3'
			if(@C3<>'')
				Set @xmlC3 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C3 + @XMLFinalLabel
		End
		--Get the commands for xmlC4 label
		If (rtrim(@C4)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C4'
			if(@C4<>'')
				Set @xmlC4 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C4 + @XMLFinalLabel
		End
		--Get the commands for xmlC5 label
		If (rtrim(@C5)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C5'
			if(@C5<>'')
				Set @xmlC5 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C5 + @XMLFinalLabel
		End
--*************************************************************
		--Get the commands for xmlC6 label
		If (rtrim(@C6)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C6'
			if(@C6<>'')
				Set @xmlC6 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C6 + @XMLFinalLabel
		End
--		Select	@Cmd = isnull([CommandERP],''),
--				@CmdLbl = isnull([LabelCommandERP],'') 
--		From [dbo].[LabelsRemarks] 
--		Where [IDRemarkLabel] = 'C6'
--		--Searching the values for Charge per service
--		Declare 
--			@Pattern varchar(5),
--			@LocPattern int
--		Set @Pattern = '%+%'
--		Set	@xmlC6 = ''
--		Set	@LocPattern = 1
--		if(len(@C6) = 0) 
--			if(@C6<>'')
--				Set @xmlC6 = @Cmd + @XMLInitialLabel + @CmdLbl + @C6 + @XMLFinalLabel
--		while (len(@C6) > 0) 
--		Begin
--			set @LocPattern = Patindex(@Pattern, @C6)
--			if(@LocPattern > 0)
--			Begin
--				if(@C6<>'')
--					set @xmlC6 = @xmlC6 + @XMLInitialLabel+ @CmdLbl + Substring(@C6,1,@LocPattern-1) + @XMLFinalLabel + '+'
--				set @C6 = Substring(@C6,@LocPattern+1,len(@C6))
--				set @LocPattern = 1
--			End
--			Else if(len(@C6) > 0)
--				Begin
--					set @xmlC6 = @xmlC6 + @XMLInitialLabel + @CmdLbl + @C6 +@XMLFinalLabel
--					set @C6 = ''
--				End
--		End
--*************************************************************
		--Get the commands for xmlC7 label
		If (rtrim(@C7)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C7'
			if(@C7<>'')
				Set @xmlC7 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C7 + @XMLFinalLabel
		End
		--Get the commands for xmlC8 label
		If (rtrim(@C8)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C8'
			if(@C8<>'')
				Set @xmlC8 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C8 + @XMLFinalLabel
		End
		--Get the commands for xmlC9 label
		If (rtrim(@C9)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C9'
			if(@C9<>'')
				Set @xmlC9 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C9 + @XMLFinalLabel
		End
		--Get the commands for xmlC10 label
		If (rtrim(@C10)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C10'
			if(@C10<>'')
				Set @xmlC10 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C10 + @XMLFinalLabel
		End
		--Get the commands for xmlC11 label
		If (rtrim(@C11)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C11'
			if(@C11<>'')
				Set @xmlC11 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C11 + @XMLFinalLabel
		End
		--Get the commands for xmlC12 label
		If (rtrim(@C12)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C12'
			if(@C12<>'')
				Set @xmlC12 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C12 + @XMLFinalLabel
		End
		--Get the commands for xmlC13 label
		If (rtrim(@C13)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C13'
			if(@C13<>'')
				Set @xmlC13 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C13 + @XMLFinalLabel
		End
		--Get the commands for xmlC14 label
		If (rtrim(@C14)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C14'
			if(@C14<>'')
				Set @xmlC14 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C14 + @XMLFinalLabel
		End
		--Get the commands for xmlC15 label
		If (rtrim(@C15)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C15'
			if(@C15<>'')
				Set @xmlC15 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C15 + @XMLFinalLabel
		End
		--Get the commands for xmlC16 label
		If (rtrim(@C16)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C16'
			if(@C16<>'')
				Set @xmlC16 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C16 + @XMLFinalLabel
		End
		--Get the commands for xmlC17 label
		If (rtrim(@C17)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C17'
			if(@C17<>'')
				Set @xmlC17 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C17 + @XMLFinalLabel
		End
		--Get the commands for xmlC18 label
		If (rtrim(@C18)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C18'
			if(@C18<>'')
				Set @xmlC18 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C18 + @XMLFinalLabel
		End
		--Get the commands for xmlC19 label
		If (rtrim(@C19)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C19'
			if(@C19<>'')
				Set @xmlC19 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C19 + @XMLFinalLabel
		End
		--Get the commands for xmlC20 label
		If (rtrim(@C20)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C20'
			if(@C20<>'')
				Set @xmlC20 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C20 + @XMLFinalLabel
		End
		--Get the commands for xmlC21 label
		If (rtrim(@C21)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C21'
			if(@C21<>'')
				Set @xmlC21 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C21 + @XMLFinalLabel
		End
		--Get the commands for xmlC22 label
		If (rtrim(@C22)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C22'
			if(@C22<>'')
				Set @xmlC22 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C22 + @XMLFinalLabel
		End
--*************************************************************
		--Get the commands for xmlC23 label
		If (rtrim(@C23)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C23'
			if(@C23<>'')
				Set @xmlC23 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C23 + @XMLFinalLabel
		End

--		Select	@Cmd = isnull([CommandERP],''),
--				@CmdLbl = isnull([LabelCommandERP],'') 
--		From [dbo].[LabelsRemarks] 
--		Where [IDRemarkLabel] = 'C23'
--		--Searching the values for Charge per service
--		Set @Pattern = '%+%'
--		Set	@xmlC23 = ''
--		Set	@LocPattern = 1
--		if(len(@C23) = 0) 
--			if(@C23<>'')
--				Set @xmlC23 = @Cmd + @XMLInitialLabel + @CmdLbl + @C23 + @XMLFinalLabel
--		while (len(@C23) > 0) 
--		Begin
--			set @LocPattern = Patindex(@Pattern, @C23)
--			if(@LocPattern > 0)
--			Begin
--				if(@C23<>'')
--					set @xmlC23 = @xmlC23 + @XMLInitialLabel+ @CmdLbl + Substring(@C23,1,@LocPattern-1) + @XMLFinalLabel + '+'
--				set @C23 = Substring(@C23,@LocPattern+1,len(@C23))
--				set @LocPattern = 1
--			End
--			Else if(len(@C23) > 0)
--				Begin
--					set @xmlC23 = @xmlC23 + @XMLInitialLabel + @CmdLbl + @C23 +@XMLFinalLabel
--					set @C23 = ''
--				End
--		End
--*************************************************************
		--Get the commands for xmlC24 label
		If (rtrim(@C24)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C24'
			if(@C24<>'')
				Set @xmlC24 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C24 + @XMLFinalLabel
		End
		--Get the commands for xmlC25 label
		If (rtrim(@C25)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C25'
			if(@C25<>'')
				Set @xmlC25 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C25 + @XMLFinalLabel
		End
		--Get the commands for xmlC26 label
		If (rtrim(@C26)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C26'
			if(@C26<>'')
				Set @xmlC26 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C26 + @XMLFinalLabel
		End
		--Get the commands for xmlC27 label
		If (rtrim(@C27)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C27'
			if(@C27<>'')
				Set @xmlC27 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C27 + @XMLFinalLabel
		End
		--Get the commands for xmlC28 label
		If (rtrim(@C28)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C28'
			if(@C28<>'')
				Set @xmlC28 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C28 + @XMLFinalLabel
		End
		--Get the commands for xmlC29 label
		If (rtrim(@C29)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C29'
			if(@C29<>'')
				Set @xmlC29 = @Cmd + @XMLInitialLabel + @CmdLbl + '*' + @C29 + @XMLFinalLabel
--		Set @xmlC29 = @C29
		End
		--Get the commands for xmlC30 label
		If (rtrim(@C30)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C30'
			if(@C30<>'')
				Set @xmlC30 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C30 + @XMLFinalLabel
		End
		--Get the commands for xmlC31 label
		If (rtrim(@C31)<>'')
			Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C31'
			if(@C31<>'')
				Set @xmlC31 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C31 + @XMLFinalLabel
		End		
		--Get the commands for xmlC32 label
		If (rtrim(@C32)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C32'
			if(@C32<>'')
				Set @xmlC32 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C32 + @XMLFinalLabel
		End		
		--Get the commands for xmlC33 label
		If (rtrim(@C33)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C33'
			if(@C33<>'')
				Set @xmlC33 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C33 + @XMLFinalLabel
		end		
		--Get the commands for xmlC34 label
		If (rtrim(@C34)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C34'
			if(@C34<>'')
				Set @xmlC34 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C34 + @XMLFinalLabel
		End		
		--Get the commands for xmlC35 label
		If (rtrim(@C35)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C35'
			if(@C35<>'')
				Set @xmlC35 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C35 + @XMLFinalLabel
		End		
		--Get the commands for xmlC36 label
		If (rtrim(@C36)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C36'
			if(@C36<>'')
				Set @xmlC36 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C36 + @XMLFinalLabel
		End
		--Get the commands for xmlC37 label
		If (rtrim(@C37)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C37'
			if(@C37<>'')
				Set @xmlC37 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C37 + @XMLFinalLabel
		End		
		--Get the commands for xmlC38 label
		If (rtrim(@C38)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C38'
			if(@C38<>'')
				Set @xmlC38 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C38 + @XMLFinalLabel
		End		
		--Get the commands for xmlC39 label
		If (rtrim(@C39)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C39'
			if(@C39<>'')
				Set @xmlC39 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C39 + @XMLFinalLabel
		End		
		--Get the commands for xmlC40 label
		If (rtrim(@C40)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C40'
			if(@C40<>'')
				Set @xmlC40 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C40 + @XMLFinalLabel
		End		
		--Get the commands for xmlC41 label
		If (rtrim(@C41)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C41'
			if(@C41<>'')
				Set @xmlC41 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C41 + @XMLFinalLabel
		End		
		--Get the commands for xmlC42 label
		If (rtrim(@C42)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C42'
			if(@C42<>'')
				Set @xmlC42 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C42 + @XMLFinalLabel
		End		
		--Get the commands for xmlC43 label
		If (rtrim(@C43)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C43'
			if(@C43<>'')
				Set @xmlC43 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C43 + @XMLFinalLabel
		End		
		--Get the commands for xmlC44 label
		If (rtrim(@C44)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C44'
			if(@C44<>'')
				Set @xmlC44 = @Cmd + @XMLInitialLabel + @CmdLbl + '*' + @C44 + @XMLFinalLabel
		End		
		--Get the commands for xmlC45 label
		If (rtrim(@C45)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C45'
			if(@C45<>'')
				Set @xmlC45 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C45 + @XMLFinalLabel
		End		
		--Get the commands for xmlC46 label
		If (rtrim(@C46)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C46'
			if(@C46<>'')
				Set @xmlC46 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C46 + @XMLFinalLabel
		End		
		--Get the commands for xmlC47 label
		If (rtrim(@C47)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C47'
			if(@C47<>'')
				Set @xmlC47 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C47 + @XMLFinalLabel
		End		
		--Get the commands for xmlC48 label
		If (rtrim(@C48)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C48'
			if(@C48<>'')
				Set @xmlC48 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C48 + @XMLFinalLabel
		End		
		--Get the commands for xmlC49 label
		If (rtrim(@C49)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C49'
			if(@C49<>'')
				Set @xmlC49 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C49 + @XMLFinalLabel
		End		
		--Get the commands for xmlC50 label
		If (rtrim(@C50)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C50'
			if(@C50<>'')
				Set @xmlC50 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C50 + @XMLFinalLabel
		End		
		--Get the commands for xmlC51 label
		If (rtrim(@C51)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C51'
			if(@C51<>'')
				Set @xmlC51 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C51 + @XMLFinalLabel
		End		
		--Get the commands for xmlC52 label
		If (rtrim(@C52)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C52'
			if(@C52<>'')
				Set @xmlC52 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C52 + @XMLFinalLabel
		End		
		--Get the commands for xmlC53 label
		If (rtrim(@C53)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C53'
			if(@C53<>'')
				Set @xmlC53 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C53 + @XMLFinalLabel
		End		
		--Get the commands for xmlC54 label
		If (rtrim(@C54)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C54'
			if(@C54<>'')
				Set @xmlC54 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C54 + @XMLFinalLabel
		End		
		--Get the commands for xmlC55 label
		If (rtrim(@C55)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C55'
			if(@C55<>'')
				Set @xmlC55 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C55 + @XMLFinalLabel
		End		
		--Get the commands for xmlC56 label
		If (rtrim(@C56)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C56'
			if(@C56<>'')
				Set @xmlC56 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C56 + @XMLFinalLabel
		End		
		--Get the commands for xmlC57 label
		If (rtrim(@C57)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C57'
			if(@C57<>'')
				Set @xmlC57 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C57 + @XMLFinalLabel
		End		
		--Get the commands for xmlC58 label
		If (rtrim(@C58)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C58'
			if(@C58<>'')
				Set @xmlC58 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C58 + @XMLFinalLabel
		End		
		--Get the commands for xmlC59 label
		If (rtrim(@C59)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C59'
			if(@C59<>'')
				Set @xmlC59 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C59 + @XMLFinalLabel
		End		
		--Get the commands for xmlC60 label
		If (rtrim(@C60)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C60'
			if(@C60<>'')
				Set @xmlC60 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C60 + @XMLFinalLabel
		End		
		--Get the commands for xmlC61 label
		If (rtrim(@C61)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C61'
			if(@C61<>'')
				Set @xmlC61 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C61 + @XMLFinalLabel
		End		
		--Get the commands for xmlC62 label
		If (rtrim(@C62)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C62'
			if(@C62<>'')
				Set @xmlC62 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C62 + @XMLFinalLabel
		End		
		--Get the commands for xmlC63 label
		If (rtrim(@C63)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C63'
			if(@C63<>'')
				Set @xmlC63 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C63 + @XMLFinalLabel
		End		
		--Get the commands for xmlC64 label
		If (rtrim(@C64)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C64'
			if(@C64<>'')
				Set @xmlC64 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C64 + @XMLFinalLabel
		End	
		--Get the commands for xmlC65 label
		If (rtrim(@C65)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C65'
			if(@C65<>'')
				Set @xmlC65 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C65 + @XMLFinalLabel
		End		
		--Get the commands for xmlC66 label
		If (rtrim(@C66)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C66'
			if(@C66<>'')
				Set @xmlC66 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C66 + @XMLFinalLabel
		End		
		--Get the commands for xmlC67 label
		If (rtrim(@C67)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C67'
			if(@C67<>'')
				Set @xmlC67 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C67 + @XMLFinalLabel
		End		
		--Get the commands for xmlC68 label
		If (rtrim(@C68)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C68'
			if(@C68<>'')
				Set @xmlC68 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C68 + @XMLFinalLabel
		End		
		--Get the commands for xmlC69 label
		If (rtrim(@C69)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C69'
			if(@C69<>'')
				Set @xmlC69 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C69 + @XMLFinalLabel
		End		
		--Get the commands for xmlC70 label
		If (rtrim(@C70)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C70'
			if(@C70<>'')
				Set @xmlC70 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C70 + @XMLFinalLabel
		End		
		--Get the commands for xmlC71 label
		If (rtrim(@C71)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C71'
			if(@C71<>'')
				Set @xmlC71 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C71 + @XMLFinalLabel
		End		
		--Get the commands for xmlC72 label
		If (rtrim(@C72)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C72'
			if(@C72<>'')
				Set @xmlC72 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C72 + @XMLFinalLabel
		End		
		--Get the commands for xmlC73 label
		If (rtrim(@C73)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C73'
			if(@C73<>'')
				Set @xmlC73 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C73 + @XMLFinalLabel
		End		
		--Get the commands for xmlC74 label
		If (rtrim(@C74)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C74'
			if(@C74<>'')
				Set @xmlC74 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C74 + @XMLFinalLabel
		End		
		--Get the commands for xmlC75 label
		If (rtrim(@C75)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C75'
			if(@C75<>'')
				Set @xmlC75 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C75 + @XMLFinalLabel
		End		
		--Get the commands for xmlC76 label
		If (rtrim(@C76)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C76'
			if(@C76<>'')
				Set @xmlC76 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C76 + @XMLFinalLabel
		End		
		--Get the commands for xmlC77 label
		If (rtrim(@C77)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C77'
			if(@C77<>'')
				Set @xmlC77 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C77 + @XMLFinalLabel
		End		
		--Get the commands for xmlC78 label
		If (rtrim(@C78)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C78'
			if(@C78<>'')
				Set @xmlC78 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C78 + @XMLFinalLabel
		End		
		--Get the commands for xmlC79 label
		If (rtrim(@C79)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C79'
			if(@C79<>'')
				Set @xmlC79 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C79 + @XMLFinalLabel
		End		
		--Get the commands for xmlC80 label
		If (rtrim(@C80)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C80'
			if(@C80<>'')
				Set @xmlC80 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C80 + @XMLFinalLabel
		End		
		--Get the commands for xmlC81 label
		If (rtrim(@C81)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C81'
			if(@C81<>'')
				Set @xmlC81 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C81 + @XMLFinalLabel
		End		
		--Get the commands for xmlC82 label
		If (rtrim(@C82)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C82'
			if(@C82<>'')
				Set @xmlC82 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C82 + @XMLFinalLabel
		End		
		--Get the commands for xmlC83 label
		If (rtrim(@C83)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C83'
			if(@C83<>'')
				Set @xmlC83 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C83 + @XMLFinalLabel
		End		
		--Get the commands for xmlC84 label
		If (rtrim(@C84)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C84'
			if(@C84<>'')
				Set @xmlC84 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C84 + @XMLFinalLabel
		End		
		--Get the commands for xmlC85 label
		If (rtrim(@C85)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C85'
			if(@C85<>'')
				Set @xmlC85 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C85 + @XMLFinalLabel
		End		
		--Get the commands for xmlC86 label
		If (rtrim(@C86)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C86'
			if(@C86<>'')
				Set @xmlC86 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C86 + @XMLFinalLabel
		End		
		--Get the commands for xmlC87 label
		If (rtrim(@C87)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C87'
			if(@C87<>'')
				Set @xmlC87 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C87 + @XMLFinalLabel
		End		
		--Get the commands for xmlC88 label
		If (rtrim(@C88)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C88'
			if(@C88<>'')
				Set @xmlC88 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C88 + @XMLFinalLabel
		End		
		--Get the commands for xmlC89 label
		If (rtrim(@C89)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C89'
			if(@C89<>'')
				Set @xmlC89 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C89 + @XMLFinalLabel
		End		
		--Get the commands for xmlC90 label
		If (rtrim(@C90)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C90'
			if(@C90<>'')
				Set @xmlC90 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C90 + @XMLFinalLabel
		End		
		--Get the commands for xmlC91 label
		If (rtrim(@C91)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C91'
			if(@C91<>'')
				Set @xmlC91 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C91 + @XMLFinalLabel
		End		
		--Get the commands for xmlC92 label
		If (rtrim(@C92)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C92'
			if(@C92<>'')
				Set @xmlC92 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C92 + @XMLFinalLabel
		End		
		--Get the commands for xmlC93 label
		If (rtrim(@C93)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C93'
			if(@C93<>'')
				Set @xmlC93 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C93 + @XMLFinalLabel
		End		
		--Get the commands for xmlC94 label
		If (rtrim(@C94)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C94'
			if(@C94<>'')
				Set @xmlC94 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C94 + @XMLFinalLabel
		End		
		--Get the commands for xmlC95 label
		If (rtrim(@C95)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C95'
			if(@C95<>'')
				Set @xmlC95 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C95 + @XMLFinalLabel
		End		
		--Get the commands for xmlC96 label
		If (rtrim(@C96)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C96'
			if(@C96<>'')
				Set @xmlC96 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C96 + @XMLFinalLabel
		End		
		--Get the commands for xmlC97 label
		If (rtrim(@C97)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C97'
			if(@C97<>'')
				Set @xmlC97 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C97 + @XMLFinalLabel
		End		
		--Get the commands for xmlC98 label
		If (rtrim(@C98)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C98'
			if(@C98<>'')
				Set @xmlC98 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C98 + @XMLFinalLabel
		End		
		--Get the commands for xmlC99 label
		If (rtrim(@C99)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C99'
			if(@C99<>'')
				Set @xmlC99 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C99 + @XMLFinalLabel
		End		
		--Get the commands for xmlC100 label
		If (rtrim(@C100)<>'')
		Begin
			Select	@Cmd = isnull([CommandERP],''),
					@CmdLbl = isnull([LabelCommandERP],'') 
			From [dbo].[LabelsRemarks] 
			Where [IDRemarkLabel] = 'C100'
			if(@C100<>'')
				Set @xmlC100 = @Cmd + @XMLInitialLabel + @CmdLbl + '-' + @PaxNumber + '*' + @C100 + @XMLFinalLabel
		End		

		Select @Status as [Status], 
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
			@xmlC31 as C31,@xmlC32 as C32,@xmlC33 as C33,
			@xmlC34 as C34,@xmlC35 as C35,@xmlC36 as C36,
			@xmlC37 as C37,@xmlC38 as C38,@xmlC39 as C39,
			@xmlC40 as C40,@xmlC41 as C41,@xmlC42 as C42,
			@xmlC43 as C43,@xmlC44 as C44,@xmlC45 as C45,
			@xmlC46 as C46,@xmlC47 as C47,@xmlC48 as C48,
			@xmlC49 as C49,@xmlC50 as C50,@xmlC51 as C51,
			@xmlC52 as C52,@xmlC53 as C53,@xmlC54 as C54,
			@xmlC55 as C55,@xmlC56 as C56,@xmlC57 as C57,
			@xmlC58 as C58,@xmlC59 as C59,@xmlC60 as C60,
			@xmlC61 as C61,@xmlC62 as C62,@xmlC63 as C63,
			@xmlC64 as C64,@xmlC65 as C65,@xmlC66 as C66,
			@xmlC67 as C67,@xmlC68 as C68,@xmlC69 as C69,
			@xmlC70 as C70,@xmlC70 as C70,@xmlC71 as C71,
			@xmlC72 as C72,@xmlC73 as C73,@xmlC74 as C74,
			@xmlC75 as C75,@xmlC76 as C76,@xmlC77 as C77,
			@xmlC78 as C78,@xmlC79 as C79,@xmlC80 as C80,
			@xmlC81 as C81,@xmlC82 as C82,@xmlC83 as C83,
			@xmlC84 as C84,@xmlC85 as C85,@xmlC86 as C86,
			@xmlC87 as C87,@xmlC88 as C88,@xmlC89 as C89,
			@xmlC90 as C90,@xmlC91 as C91,@xmlC92 as C92,
			@xmlC93 as C93,@xmlC94 as C94,@xmlC95 as C95,
			@xmlC96 as C96,@xmlC97 as C97,@xmlC98 as C98,
			@xmlC99 as C99,@xmlC100 as C100

	End
