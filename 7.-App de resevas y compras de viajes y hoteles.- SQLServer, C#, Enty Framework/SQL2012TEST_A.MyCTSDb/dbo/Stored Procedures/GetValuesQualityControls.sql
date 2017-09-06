-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 30-06-09
-- Description:	Procedure that gets all Corporative Quality Controls collection for XML Remarks
-- =============================================
CREATE Procedure [dbo].[GetValuesQualityControls]
 @DKToSearch as varchar(10),
 @Firm as varchar(50),
 @PCC as varchar(50)
AS
Declare
	--Variables
	@C1 varchar(3),
	@C2 varchar(3),
	@C3 varchar(3),
	@C4 varchar(3),
	@C5 varchar(3),
	@C6 varchar(3),
	@C7 varchar(3),
	@C8 varchar(3),
	@C9 varchar(3),
	@C10 varchar(3),
	@C11 varchar(3),
	@C12 varchar(3),
	@C13 varchar(3),
	@C14 varchar(3),
	@C15 varchar(3),
	@C16 varchar(3),
	@C17 varchar(3),
	@C18 varchar(3),
	@C19 varchar(3),
	@C20 varchar(3),
	@C21 varchar(3),
	@C22 varchar(3),
	@C23 varchar(3),
	@C24 varchar(3),
	@C25 varchar(3),
	@C26 varchar(3),
	@C27 varchar(3),
	@C28 varchar(3),
	@C29 varchar(50),
	@C30 varchar(3),
	@C31 varchar(3),
	@C32 varchar(3),
	@IDCorporative varchar(50)

	--Searching an IDCorporative that corresponds to @DKToSearch
	Select @IDCorporative = CorporativeID 
	From MyCTSDb.dbo.DK
	Where IDDK = @DKToSearch
	
	--Searching the email that corresponds to @Firm and @PCC
	Select @C29 = UserMail
	From MyCTSSecurityDb.dbo.Users
	Where ( Firm = @Firm and PCC = @PCC )

	-- Selecting Values for Remarks Variables 
	Select 
		@C1 = C1,
		@C2 = C2,
		@C3 = C3,
		@C4 = C4,
		@C5 = C5,
		@C6 = C6,
		@C7 = C7,
		@C8 = C8,
		@C9 = C9,
		@C10 = C10,
		@C11 = C11,
		@C12 = C12,
		@C13 = C13,
		@C14 = C14,
		@C15 = C15,
		@C16 = C16,
		@C17 = C17,
		@C18 = C18,
		@C19 = C19,
		@C20 = C20,
		@C21 = C21,
		@C22 = C22,
		@C23 = C23,
/*		@C10 = FareJustification,
		@C11 = ComparativeMoreEconomicFareAvailable,
		@C12 = ComparativeMoreEconomicFareNotAvailable,
		@C13 = ComparativeBusinessFare,
		@C14 = ComparativeSpecificFare,
		@C15 = ComparativeStandardFare,
		@C16 = ComparativeMoreEconomicFareAvailable,
		@C17 = ComparativeMoreEconomicFareNotAvailable,
		@C18 = ComparativeBusinessFare,
		@C19 = ComparativeSpecificFare,
		@C20 = ComparativeStandardFare,
		@C21 = C21,
		@C22 = C22,
		@C23 = ChargePerService,
*/
		@C24 = C24,
		@C25 = C25,
		@C26 = C26,
		@C27 = C27,
		@C28 = C28,
		@C29 = @C29,
		@C30 = C30,
		@C31 = C31,
		@C32 = C32
	From MyCTSDb.dbo.QualityControls
	Where ( CorporativeID = @IDCorporative )
	--Establishing Alias
	Select
		@C1 As C1,
		@C2 As C2,
		@C3 As C3,
		@C4 As C4,
		@C5 As C5,
		@C6 As C6,
		@C7 As C7,
		@C8 As C8,
		@C9 As C9,
		@C10 As C10,
		@C11 As C11,
		@C12 As C12,
		@C13 As C13,
		@C14 As C14,
		@C15 As C15,
		@C16 As C16,
		@C17 As C17,
		@C18 As C18,
		@C19 As C19,
		@C20 As C20,
		@C21 As C21,
		@C22 As C22,
		@C23 As C23,
		@C24 As C24,
		@C25 As C25,
		@C26 As C26,
		@C27 As C27,
		@C28 As C28,
		@C29 As C29,
		@C30 As C30,
		@C31 As C31,
		@C32 As C32



