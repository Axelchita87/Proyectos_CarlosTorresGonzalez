-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 15-05-2009
-- Description:	Procedure that gets the ITTourCodes Collection
-- =============================================
Create Procedure [dbo].[GetITTourCodes]
AS
	Select 
		[CommandIT],
		[Description]
	From
		dbo.ITTourCodes

