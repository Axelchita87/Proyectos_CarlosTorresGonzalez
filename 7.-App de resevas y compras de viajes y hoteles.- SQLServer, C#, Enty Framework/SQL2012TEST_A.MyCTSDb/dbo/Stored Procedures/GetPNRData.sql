-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 06-03-2010
-- Description:	Procedure that gets a CFE records collection
-- =============================================
CREATE Procedure [dbo].[GetPNRData]
 @Color varchar(20)
AS
Begin
	Select Distinct PNR from dbo.CFE 
	Where upper(Color)=@Color And
	(
		charindex('1',PNR)=0 And
		charindex('2',PNR)=0 And
		charindex('3',PNR)=0 And
		charindex('4',PNR)=0 And
		charindex('5',PNR)=0 And
		charindex('6',PNR)=0 And
		charindex('7',PNR)=0 And
		charindex('8',PNR)=0 And
		charindex('9',PNR)=0 And
		charindex('0',PNR)=0
	)
	Order By PNR
End


