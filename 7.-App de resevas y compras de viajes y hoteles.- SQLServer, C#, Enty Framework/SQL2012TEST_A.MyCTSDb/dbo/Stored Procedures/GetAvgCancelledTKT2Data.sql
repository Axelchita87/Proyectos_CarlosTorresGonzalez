-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 06-03-2010
-- Description:	Procedure that gets a CFE records collection
-- =============================================
CREATE Procedure [dbo].[GetAvgCancelledTKT2Data]
 @Color varchar(20)
AS
Begin
	Select Distinct PNR from dbo.CFE 
	Where upper(Color)='YELLOW' And
	(
		charindex('1',PNR)=0 Or
		charindex('2',PNR)=0 Or
		charindex('3',PNR)=0 Or
		charindex('4',PNR)=0 Or
		charindex('5',PNR)=0 Or
		charindex('6',PNR)=0 Or
		charindex('7',PNR)=0 Or
		charindex('8',PNR)=0 Or
		charindex('9',PNR)=0 Or
		charindex('0',PNR)=0
	)
	Order By PNR
End
