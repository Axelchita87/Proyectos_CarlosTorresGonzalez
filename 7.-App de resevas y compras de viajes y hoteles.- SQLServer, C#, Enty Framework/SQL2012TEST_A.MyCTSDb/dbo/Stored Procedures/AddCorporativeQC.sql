-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 20-07-2009
-- Description:	Procedure that insert Quality Controls for a new corporative
-- =============================================
CREATE Procedure [dbo].[AddCorporativeQC]
@CorporativeID as varchar(50)
AS
Begin
	Declare
	@NumCorp int
	
	--Actual number of Corporatives
	select @NumCorp=count(*) from MyCTSDb.dbo.QualityControls
	Set @NumCorp = @NumCorp+1
	--Adding a new row to QualityControls
	Insert into MyCTSDb.dbo.QualityControls
	values (@CorporativeID,'I','A','A','A','A','A','Y','A','K','A','J','A','C','D','A','A','I','A','A','I','I','I','A','I','I','I','I','I',
		'I','I','I','I','I','I','I','I','I','A2',			--C1  al C10
		'A2','A2','A2','A2','A2','A2','A2','A2','A2','A2',	--C11 al C20
		'A2','A2','A1','I','I','I','I','A','A','A',			--C21 al C30
		'I','I','I','I','I','I','I','I','I','I',			--C31 al C40
		'I','I','I','I','I','I','I','I','I','I',			--C41 al C50
		'I','I','I','I','I','I','I','I','I','I',			--C51 al C60
		'I','I','I','I','I','I','I','I','I','I',			--C61 al C70
		'I','I','I','I','I','I','I','I','I','I',			--C71 al C80
		'I','I','I','I','I','I','I','I','I','I',			--C81 al C90
		'I','I','I','I','I','I','I','I','I','I',			--C91 al C100
		'I','3')
End
