-- =============================================
-- Author:		Pedro Tomas Solis 
-- Create date: 12-10-2009,10-02-2010--*
-- Modify by Angel Trejo / 27-10-2009 / 03-02-2010
-- Description:	Procedure that gets the Fees Rules of a Corporative
-- =============================================
CREATE Procedure [dbo].[GetCorporativeFeesRules]
 @Location_DKToSearch varchar(6),
 @Attribute1 varchar(10),
 @Quantity Money,
 @TE1 varchar(50),		--Origin
 @TE2 varchar(50),		--Destination
 @TE3 varchar(50),		--TravelDate
 @TE4 varchar(50),		--CustomerID
 @TE5 varchar(50),		--TravelerType
 @TE6 varchar(50),		--ServiceType
 @TE7 varchar(50),		--GDSIndicator
 @TE8 varchar(50),		--DayTime
 @TE9 varchar(50),		--AdvancedPurchase
 @TE10 varchar(50),		--WeekDay
 @TE11 varchar(50),		--TicketType
 @TE12 varchar(50),		--TicketIssuer
 @TE13 varchar(50),		--DistributionChannel
 @TE14 varchar(50),		--FareType
 @TE15 varchar(50),		--FareBasisCode
 @TE16 varchar(50),		--SupplierCode
 @TE17 varchar(50),		--FareAmount
 @TE18 varchar(50),		--FormOfPayment
 @TE19 varchar(50),		--SegmentCount
 @TE20 varchar(50),		--MarketingAirline
 @TE21 varchar(50),		--PseudoCityCode
 @TE23 varchar(50)		--BussinesUnit
AS
Begin --Procedure
	Declare
	--Variables
	@RuleNumber int,@RuleNumberAux int,@TimeRange varchar(50),@BaseFare varchar(50),@DefaultFee float,
	@DefaultMount money,@index int,@SQL varchar(1000),
	----------------------
	@RuleId int,@IDTE int,@ValueTE varchar(50),@CompletedRule int,
	@RuleValue varchar(50),@CursorRulesFetch int,@CursorTEFetch int,@Prueba int

	Declare @Rules Table(RuleNumber int, DefaultFee float, DefaultMount money)
	--Check If there is a DKApplicable
	--Searching the FeesRules that corresponds to @IDCorporative
	Insert Into @Rules(RuleNumber,DefaultFee,DefaultMount) 
	Select RuleNumber, DefaultFee,DefaultMount
	From dbo.CorporativeFeesRules
	Where [Attribute1]=@Attribute1
	Order By Priority
	--*Cursor for Rules
	Declare CursorRules Cursor for
			Select RuleNumber From @Rules --order By RuleNumber DESC
	Open CursorRules
	Fetch Next From CursorRules Into @RuleId
	Set @CursorRulesFetch=@@FETCH_STATUS
	Set @CompletedRule=0
	While @CursorRulesFetch=0
	Begin  --CursorRules
		Set @CompletedRule=@RuleID
		Declare CursorTE Cursor for
				Select [IDTE],[Value] From dbo.TargetElementsRules 
				Where RuleNumber=@RuleId
		Open CursorTE
		Fetch Next From CursorTE Into @IDTE,@ValueTE --Obtiene el primer registro para CursorTE 
		Set @CursorTEFetch=@@FETCH_STATUS
		While @CursorTEFetch=0
		Begin
			if @IDTE=1
			Begin 
				if((@TE1 is not null and @TE1<>'')and(@TE1<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE1 is null or @TE1='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=2
			Begin 
				if((@TE2 is not null and @TE2<>'')and(@TE2<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE2 is null or @TE2='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=3
			Begin 
				if((@TE3 is not null and @TE3<>'')and(@TE3<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE3 is null or @TE3='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=4
			Begin 
				if((@TE4 is not null and @TE4<>'')and(@TE4<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE4 is null or @TE4='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=5
			Begin 
				if((@TE5 is not null and @TE5<>'')and(@TE5<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE5 is null or @TE5='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=6
			Begin 
				if((@TE6 is not null and @TE6<>'')and(@TE6<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE6 is null or @TE6='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=7
			Begin 
				if((@TE7 is not null and @TE7<>'')and(@TE7<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE7 is null or @TE7='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=8
			Begin 
				if((@TE8 is not null and @TE8<>'')and(@TE8<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE8 is null or @TE8='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=9
			Begin 
				if((@TE9 is not null and @TE9<>'')and(@TE9<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE9 is null or @TE9='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=10
			Begin 
				if((@TE10 is not null and @TE10<>'')and(@TE10<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE10 is null or @TE10='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=11
			Begin 
				if((@TE11 is not null and @TE11<>'')and(@TE11<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE11 is null or @TE11='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=12
			Begin 
				if((@TE12 is not null and @TE12<>'')and(@TE12<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE12 is null or @TE12='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=13
			Begin 
				if((@TE13 is not null and @TE13<>'')and(@TE13<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE13 is null or @TE13='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=14
			Begin 
				if((@TE14 is not null and @TE14<>'')and(@TE14<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE14 is null or @TE14='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=15
			Begin 
				if((@TE15 is not null and @TE15<>'')and(@TE15<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE15 is null or @TE15='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=16
			Begin 
				if((@TE16 is not null and @TE16<>'')and(@TE16<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE16 is null or @TE16='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
--			if @IDTE=17
--			Begin 
--				if((@TE17 is not null and @TE17<>'')and(@TE17<>@ValueTE))
--				Begin	
--						Set @CompletedRule=0
--						Break
--				End
--				if((@TE17 is null or @TE17='')and(@ValueTE is not null and @ValueTE<>''))
--				Begin
--					Set @CompletedRule=0
--					Break	
--				End
--			End
			if @IDTE=18
			Begin 
				if((@TE18 is not null and @TE18<>'')and(@TE18<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE18 is null or @TE18='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=19
			Begin 
				if((@TE19 is not null and @TE19<>'')and(@TE19<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE19 is null or @TE19='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=20
			Begin 
				if((@TE20 is not null and @TE20<>'')and(@TE20<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE20 is null or @TE20='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=21
			Begin 
				if((@TE21 is not null and @TE21<>'')and(@TE21<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE21 is null or @TE21='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			if @IDTE=23
			Begin 
				if((@TE23 is not null and @TE23<>'')and(@TE23<>@ValueTE))
				Begin	
						Set @CompletedRule=0
						Break
				End
				if((@TE23 is null or @TE23='')and(@ValueTE is not null and @ValueTE<>''))
				Begin
					Set @CompletedRule=0
					Break	
				End
			End
			Fetch Next From CursorTE Into @IDTE,@ValueTE --obtiene el siguiente registro de CursorTE
			Set @CursorTEFetch=@@FETCH_STATUS
		End
		Close CursorTE
		Deallocate CursorTE
		if @CompletedRule=0
		Begin		
			Print 'Regla:'+Cast(@RuleId as varchar(2))+' No aplica'
		End
		else
		Begin
			if not exists(select RuleNumber, LocationDK
						  from dbo.RuleNumberNotEnableForLocation
						  where RuleNumber=@RuleId and LocationDK=@Location_DKToSearch)
			begin
				
				select @TimeRange=[Value]
			    from dbo.TargetElementsRules
				where RuleNumber=@RuleId and IDTE = 22
				select @BaseFare=[Value]
				from dbo.TargetElementsRules
				where RuleNumber=@RuleId and IDTE = 17
				Select (@Quantity*(DefaultFee/100))+DefaultMount as 'Cantidad Calculada', [RuleNumber],[Priority],[ExtendedDescription],
						[Mandatory],ActivationState,StartDate,ExpirationDate,@TimeRange as TimeRange, @BaseFare as BaseFare
				From dbo.CorporativeFeesRules 
				Where [Attribute1]=@Attribute1 and RuleNumber=@CompletedRule
				set @TimeRange = null
				set @BaseFare = null
			end
		End
		Fetch Next From CursorRules Into @RuleId --obtiene el siguiente registro de CursorRules
		Set @CursorRulesFetch=@@FETCH_STATUS
	End --CursorRules
	Close CursorRules
	Deallocate CursorRules
End --Procedure


