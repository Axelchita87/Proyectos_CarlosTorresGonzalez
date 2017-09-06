-- =============================================
-- Author:		Pedro Tomas Solis
-- MODIFY:	LUIS FELIPE SEGURA VELASCO
-- Create date: 28-04-2009,
-- Modify Date:	15 Agosto de 2012
-- Description:	Procedure that gets a GetQueue collection
-- =============================================
CREATE PROCEDURE [dbo].[GetQueue]
	@QueueToSearch as varchar(50),
	@PCCToSearch as varchar(50)
AS
Begin
	Select	UserName as [Agent], 
			[Queue]=Case When ([Queue] is null or rtrim([Queue])='') then Null
						 Else [PCC]+[Queue]
					End,
			[PCC]
	From	[dbo].[Users] WITH(NOLOCK) 
	Where	[Firm] = @QueueToSearch and [PCC] = @PCCToSearch
End
-- =============================================
-- EXEC GetQueue '1710', '3L64'
-- =============================================
