-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 29-09-2009
-- Description:	Procedure that gets the fetures of a corporative
-- =============================================
CREATE Procedure [dbo].[GetCorporativeFeatures]
 @Attribute1 as Varchar(10)
AS
Begin
	select C21,C22 from dbo.CorporativesFeatures
	where Attribute1 = @Attribute1
End

