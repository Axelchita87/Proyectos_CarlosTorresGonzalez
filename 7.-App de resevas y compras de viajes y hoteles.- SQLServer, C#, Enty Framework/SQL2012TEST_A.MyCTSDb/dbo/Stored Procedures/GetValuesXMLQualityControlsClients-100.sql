

-- =============================================
-- Author:		Marcos Q. Ramirez
-- Create date: 12-04-10
-- Description:	Procedure that gets all custom remark by client
-- =============================================
create Procedure [dbo].[GetValuesXMLQualityControlsClients-100]
	--Parameters
	@Attribute1 varchar(10),
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
    @Index int,
    @IndexState int, 
--variable para el nuevo esquema de remarks para quality controls
    @XMLSabreCommand varchar(10),
	@XMLInitialLabel varchar(10),
	@XMLFinalLabel varchar(10),
    @XMLIdentyfier varchar(10),
    @XMLPaxIdentyfier varchar(10),
    @XMLValueIdentyfier varchar(10),
	@XMLActualLabel varchar(65),
	@XMLFutureLabel varchar(65),
	@Cmd varchar (50),
	@CmdLbl varchar(50)

	--Searching an IDCorporative that corresponds to @Attribute1
--	Select @IDCorporative = CorporativeID 
--	From dbo.DK
--	Where IDDK = @Attribute1

	--Get the XML Labels
	Select @XMLSabreCommand = [RmrkType],
           @XMLInitialLabel = [RmrkInitialLabel],
           @XMLIdentyfier = [RmrkIdentyfier],
           @XMLPaxIdentyfier = [RmrkPaxIdentyfier],
           @XMLValueIdentyfier = [RmrkValueIdentyfier],
		   @XMLFinalLabel = [RmrkFinalLabel]
	From   dbo.QCCustomRemarksClients
	Where  Attribute1 = @Attribute1

    if(@XMLInitialLabel is null)
    begin
           Select @XMLInitialLabel = [RmrkInitialLabel],
                  @XMLIdentyfier = [RmrkIdentyfier],
                  @XMLPaxIdentyfier = [RmrkPaxIdentyfier],
                  @XMLValueIdentyfier = [RmrkValueIdentyfier],
		          @XMLFinalLabel = [RmrkFinalLabel]
	       From   [dbo].[QCCustomRemarksClients] 
	       Where  Attribute1 = 'MYCTS1'
    end

	--Search the type of Status for the construction of the Label	
	Select @Status = [Status] From dbo.QualityControls Where [Attribute1] = @Attribute1

	--If Corporative Status is ERP
	if(@Status = 2 or @Status = 3)--***Para Remarks del Futuro
	Begin
		--Get the commands for xmlC1 label
		If (rtrim(@C1)<>'')
		Begin
			Select @CmdLbl = isnull([C1],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C1<>'' and @CmdLbl is not null)
            Begin
			    Set @Index = charindex('|', @CmdLbl)
                set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC1 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C1 + @XMLFinalLabel
                end
            End    
		End
		--Get the commands for xmlC2 label
		If (rtrim(@C2)<>'')
		Begin
			Select @CmdLbl = isnull([C2],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C2<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
                set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC2 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C2 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC3 label
		If (rtrim(@C3)<>'')
		Begin
			Select @CmdLbl = isnull([C3],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C3<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC3 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C3 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC4 label
		If (rtrim(@C4)<>'')
		Begin
			Select @CmdLbl = isnull([C4],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C4<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
                set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC4 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C4 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC5 label
		If (rtrim(@C5)<>'')
		Begin
			Select @CmdLbl = isnull([C5],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C5<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC5 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C5 + @XMLFinalLabel
				end
		End
--*************************************************************
		--Get the commands for xmlC6 label
		If (rtrim(@C6)<>'')
		Begin
			Select @CmdLbl = isnull([C6],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C6<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC6 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C6 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC7 label
		If (rtrim(@C7)<>'')
		Begin
			Select @CmdLbl = isnull([C7],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C7<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC7 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C7 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC8 label
		If (rtrim(@C8)<>'')
		Begin
			Select @CmdLbl = isnull([C8],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C8<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC8 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C8 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC9 label
		If (rtrim(@C9)<>'')
		Begin
			Select @CmdLbl = isnull([C9],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C9<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC9 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C9 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC10 label
		If (rtrim(@C10)<>'')
		Begin
			Select @CmdLbl = isnull([C10],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C10<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC10 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C10 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC11 label
		If (rtrim(@C11)<>'')
		Begin
			Select @CmdLbl = isnull([C11],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C11<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC11 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C11 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC12 label
		If (rtrim(@C12)<>'')
		Begin
			Select @CmdLbl = isnull([C12],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C12<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC12 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C12 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC13 label
		If (rtrim(@C13)<>'')
		Begin
			Select @CmdLbl = isnull([C13],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C13<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC13 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C13 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC14 label
		If (rtrim(@C14)<>'')
		Begin
			Select @CmdLbl = isnull([C14],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C14<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC14 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C14 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC15 label
		If (rtrim(@C15)<>'')
		Begin
			Select @CmdLbl = isnull([C15],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C15<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC15 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C15 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC16 label
		If (rtrim(@C16)<>'')
		Begin
			Select @CmdLbl = isnull([C16],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C16<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC16 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C16 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC17 label
		If (rtrim(@C17)<>'')
		Begin
			Select @CmdLbl = isnull([C17],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C17<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC17 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C17 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC18 label
		If (rtrim(@C18)<>'')
		Begin
			Select @CmdLbl = isnull([C18],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C18<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC18 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C18 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC19 label
		If (rtrim(@C19)<>'')
		Begin
			Select @CmdLbl = isnull([C19],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C19<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC19 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C19 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC20 label
		If (rtrim(@C20)<>'')
		Begin
			Select @CmdLbl = isnull([C20],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C20<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC20 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C20 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC21 label
		If (rtrim(@C21)<>'')
		Begin
			Select @CmdLbl = isnull([C21],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C21<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC21 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C21 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC22 label
		If (rtrim(@C22)<>'')
		Begin
			Select @CmdLbl = isnull([C22],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C22<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC22 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C22 + @XMLFinalLabel
				end
		End
--*************************************************************
		--Get the commands for xmlC23 label
		If (rtrim(@C23)<>'')
		Begin
			Select @CmdLbl = isnull([C23],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C23<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC23 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C23 + @XMLFinalLabel
				end
		End
		
		--Get the commands for xmlC24 label
		If (rtrim(@C24)<>'')
		Begin
			Select @CmdLbl = isnull([C24],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C24<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC24 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C24 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC25 label
		If (rtrim(@C25)<>'')
		Begin
			Select @CmdLbl = isnull([C25],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C25<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC25 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C25 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC26 label
		If (rtrim(@C26)<>'')
		Begin
			Select @CmdLbl = isnull([C26],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C26<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC26 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C26 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC27 label
		If (rtrim(@C27)<>'')
		Begin
			Select @CmdLbl = isnull([C27],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C27<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC27 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C27 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC28 label
		If (rtrim(@C28)<>'')
		Begin
			Select @CmdLbl = isnull([C28],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C28<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC28 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C28 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC29 label
		If (rtrim(@C29)<>'')
		Begin
			Select @CmdLbl = isnull([C29],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C29<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC29 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLValueIdentyfier + @C29 + @XMLFinalLabel
				end
--		Set @xmlC29 = @C29
		End
		--Get the commands for xmlC30 label
		If (rtrim(@C30)<>'')
		Begin
			Select @CmdLbl = isnull([C30],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C30<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC30 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C30 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC31 label
		If (rtrim(@C31)<>'')
			Begin
			Select @CmdLbl = isnull([C31],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C31<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC31 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C31 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC32 label
		If (rtrim(@C32)<>'')
		Begin
			Select @CmdLbl = isnull([C32],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C32<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC32 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C32 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC33 label
		If (rtrim(@C33)<>'')
		Begin
			Select @CmdLbl = isnull([C33],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C33<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC33 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C33 + @XMLFinalLabel
				end
		end		
		--Get the commands for xmlC34 label
		If (rtrim(@C34)<>'')
		Begin
			Select @CmdLbl = isnull([C34],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C34<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC34 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C34 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC35 label
		If (rtrim(@C35)<>'')
		Begin
			Select @CmdLbl = isnull([C35],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C35<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC35 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C35 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC36 label
		If (rtrim(@C36)<>'')
		Begin
			Select @CmdLbl = isnull([C36],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C36<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC36 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C36 + @XMLFinalLabel
				end
		End
		--Get the commands for xmlC37 label
		If (rtrim(@C37)<>'')
		Begin
			Select @CmdLbl = isnull([C37],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C37<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC37 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C37 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC38 label
		If (rtrim(@C38)<>'')
		Begin
			Select @CmdLbl = isnull([C38],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C38<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC38 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C38 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC39 label
		If (rtrim(@C39)<>'')
		Begin
			Select @CmdLbl = isnull([C39],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C39<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC39 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C39 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC40 label
		If (rtrim(@C40)<>'')
		Begin
			Select @CmdLbl = isnull([C40],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C40<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC40 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C40 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC41 label
		If (rtrim(@C41)<>'')
		Begin
			Select @CmdLbl = isnull([C41],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C41<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC41 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C41 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC42 label
		If (rtrim(@C42)<>'')
		Begin
			Select @CmdLbl = isnull([C42],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C42<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC42 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C42 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC43 label
		If (rtrim(@C43)<>'')
		Begin
			Select @CmdLbl = isnull([C43],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C43<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC43 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C43 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC44 label
		If (rtrim(@C44)<>'')
		Begin
			Select @CmdLbl = isnull([C44],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C44<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC44 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLValueIdentyfier + @C44 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC45 label
		If (rtrim(@C45)<>'')
		Begin
			Select @CmdLbl = isnull([C45],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C45<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC45 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C45 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC46 label
		If (rtrim(@C46)<>'')
		Begin
			Select @CmdLbl = isnull([C46],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C46<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC46 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C46 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC47 label
		If (rtrim(@C47)<>'')
		Begin
			Select @CmdLbl = isnull([C47],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C47<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC47 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C47 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC48 label
		If (rtrim(@C48)<>'')
		Begin
			Select @CmdLbl = isnull([C48],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C48<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC48 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C48 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC49 label
		If (rtrim(@C49)<>'')
		Begin
			Select @CmdLbl = isnull([C49],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C49<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC49 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C49 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC50 label
		If (rtrim(@C50)<>'')
		Begin
			Select @CmdLbl = isnull([C50],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C50<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC50 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C50 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC51 label
		If (rtrim(@C51)<>'')
		Begin
			Select @CmdLbl = isnull([C51],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C51<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC51 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C51 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC52 label
		If (rtrim(@C52)<>'')
		Begin
			Select @CmdLbl = isnull([C52],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C52<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC52 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C52 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC53 label
		If (rtrim(@C53)<>'')
		Begin
			Select @CmdLbl = isnull([C53],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C53<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC53 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C53 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC54 label
		If (rtrim(@C54)<>'')
		Begin
			Select @CmdLbl = isnull([C54],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C54<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC54 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C54 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC55 label
		If (rtrim(@C55)<>'')
		Begin
			Select @CmdLbl = isnull([C55],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C55<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC55 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C55 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC56 label
		If (rtrim(@C56)<>'')
		Begin
			Select @CmdLbl = isnull([C56],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C56<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC56 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C56 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC57 label
		If (rtrim(@C57)<>'')
		Begin
			Select @CmdLbl = isnull([C57],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C57<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC57 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C57 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC58 label
		If (rtrim(@C58)<>'')
		Begin
			Select @CmdLbl = isnull([C58],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C58<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC58 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C58 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC59 label
		If (rtrim(@C59)<>'')
		Begin
			Select @CmdLbl = isnull([C59],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C59<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC59 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C59 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC60 label
		If (rtrim(@C60)<>'')
		Begin
			Select @CmdLbl = isnull([C60],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C60<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC60 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C60 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC61 label
		If (rtrim(@C61)<>'')
		Begin
			Select @CmdLbl = isnull([C61],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C61<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC61 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C61 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC62 label
		If (rtrim(@C62)<>'')
		Begin
			Select @CmdLbl = isnull([C62],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C62<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC62 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C62 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC63 label
		If (rtrim(@C63)<>'')
		Begin
			Select @CmdLbl = isnull([C63],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C63<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC63 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C63 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC64 label
		If (rtrim(@C64)<>'')
		Begin
			Select @CmdLbl = isnull([C64],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C64<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC64 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C64 + @XMLFinalLabel
				end
		End	
		--Get the commands for xmlC65 label
		If (rtrim(@C65)<>'')
		Begin
			Select @CmdLbl = isnull([C65],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C65<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC65 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C65 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC66 label
		If (rtrim(@C66)<>'')
		Begin
			Select @CmdLbl = isnull([C66],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C66<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC66 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C66 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC67 label
		If (rtrim(@C67)<>'')
		Begin
			Select @CmdLbl = isnull([C67],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C67<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC67 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C67 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC68 label
		If (rtrim(@C68)<>'')
		Begin
			Select @CmdLbl = isnull([C68],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C68<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC68 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C68 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC69 label
		If (rtrim(@C69)<>'')
		Begin
			Select @CmdLbl = isnull([C69],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C69<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC69 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C69 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC70 label
		If (rtrim(@C70)<>'')
		Begin
			Select @CmdLbl = isnull([C70],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C70<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC70 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C70 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC71 label
		If (rtrim(@C71)<>'')
		Begin
			Select @CmdLbl = isnull([C71],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C71<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC71 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C71 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC72 label
		If (rtrim(@C72)<>'')
		Begin
			Select @CmdLbl = isnull([C72],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C72<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
                set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC72 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C72 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC73 label
		If (rtrim(@C73)<>'')
		Begin
			Select @CmdLbl = isnull([C73],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C73<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC73 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C73 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC74 label
		If (rtrim(@C74)<>'')
		Begin
			Select @CmdLbl = isnull([C74],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C74<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC74 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C74 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC75 label
		If (rtrim(@C75)<>'')
		Begin
			Select @CmdLbl = isnull([C75],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C75<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC75 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C75 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC76 label
		If (rtrim(@C76)<>'')
		Begin
			Select @CmdLbl = isnull([C76],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C76<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC76 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C76 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC77 label
		If (rtrim(@C77)<>'')
		Begin
			Select @CmdLbl = isnull([C77],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C77<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC77 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C77 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC78 label
		If (rtrim(@C78)<>'')
		Begin
			Select @CmdLbl = isnull([C78],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C78<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC78 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C78 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC79 label
		If (rtrim(@C79)<>'')
		Begin
			Select @CmdLbl = isnull([C79],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C79<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC79 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C79 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC80 label
		If (rtrim(@C80)<>'')
		Begin
			Select @CmdLbl = isnull([C80],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C80<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC80 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C80 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC81 label
		If (rtrim(@C81)<>'')
		Begin
			Select @CmdLbl = isnull([C81],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C81<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC81 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C81 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC82 label
		If (rtrim(@C82)<>'')
		Begin
			Select @CmdLbl = isnull([C82],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C82<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC82 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C82 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC83 label
		If (rtrim(@C83)<>'')
		Begin
			Select @CmdLbl = isnull([C83],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C83<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC83 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C83 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC84 label
		If (rtrim(@C84)<>'')
		Begin
			Select @CmdLbl = isnull([C84],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C84<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC84 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C84 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC85 label
		If (rtrim(@C85)<>'')
		Begin
			Select @CmdLbl = isnull([C85],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C85<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC85 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C85 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC86 label
		If (rtrim(@C86)<>'')
		Begin
			Select @CmdLbl = isnull([C86],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C86<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC86 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C86 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC87 label
		If (rtrim(@C87)<>'')
		Begin
			Select @CmdLbl = isnull([C87],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C87<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC87 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C87 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC88 label
		If (rtrim(@C88)<>'')
		Begin
			Select @CmdLbl = isnull([C88],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C88<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC88 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C88 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC89 label
		If (rtrim(@C89)<>'')
		Begin
			Select @CmdLbl = isnull([C89],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C89<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC89 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C89 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC90 label
		If (rtrim(@C90)<>'')
		Begin
			Select @CmdLbl = isnull([C90],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C90<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC90 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C90 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC91 label
		If (rtrim(@C91)<>'')
		Begin
			Select @CmdLbl = isnull([C91],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C91<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC91 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C91 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC92 label
		If (rtrim(@C92)<>'')
		Begin
			Select @CmdLbl = isnull([C92],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C92<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC92 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C92 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC93 label
		If (rtrim(@C93)<>'')
		Begin
			Select @CmdLbl = isnull([C93],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C93<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC93 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C93 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC94 label
		If (rtrim(@C94)<>'')
		Begin
			Select @CmdLbl = isnull([C94],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C94<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC94 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C94 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC95 label
		If (rtrim(@C95)<>'')
		Begin
			Select @CmdLbl = isnull([C95],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C95<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC95 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C95 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC96 label
		If (rtrim(@C96)<>'')
		Begin
			Select @CmdLbl = isnull([C96],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C96<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC96 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C96 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC97 label
		If (rtrim(@C97)<>'')
		Begin
			Select @CmdLbl = isnull([C97],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C97<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC97 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C97 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC98 label
		If (rtrim(@C98)<>'')
		Begin
			Select @CmdLbl = isnull([C98],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C98<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC98 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C98 + @XMLFinalLabel	
				end
		End		
		--Get the commands for xmlC99 label
		If (rtrim(@C99)<>'')
		Begin
			Select @CmdLbl = isnull([C99],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C99<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC99 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C99 + @XMLFinalLabel
				end
		End		
		--Get the commands for xmlC100 label
		If (rtrim(@C100)<>'')
		Begin
			Select @CmdLbl = isnull([C100],'') 
			From [dbo].[QualityControlsClients] 
			Where [Attribute1] = @Attribute1
			if(@C100<>'' and @CmdLbl is not null)
                Set @Index = charindex('|', @CmdLbl)
				set @IndexState = len(@CmdLbl)
                if(substring(@CmdLbl, @Index + 1, @IndexState - @Index) like 'A%')
                begin
					Set @xmlC100 = @XMLSabreCommand + @XMLInitialLabel + @XMLIdentyfier + substring(@CmdLbl, 0, @Index) + @XMLPaxIdentyfier + @PaxNumber + @XMLValueIdentyfier + @C100 + @XMLFinalLabel
				end
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
		    @xmlC70 as C70,@xmlC71 as C71,
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


