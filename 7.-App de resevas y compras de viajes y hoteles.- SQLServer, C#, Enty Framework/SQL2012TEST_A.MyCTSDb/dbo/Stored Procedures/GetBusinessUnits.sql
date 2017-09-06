





-- =============================================
-- Author:		Pedro Tomas Solis
-- Create date: 23-06-2009
-- Description:	Procedure that gets all the collection of BusinessUnits
-- =============================================
CREATE Procedure [dbo].[GetBusinessUnits]
@OrgId as int
As
Begin
	SELECT ID AS [IDIntegra],CCI as [Name],OUName as [IDBusinessUnits]
	FROM dbo.OperativeUnits U inner join MyCTSSecurityDb.dbo.Applications A on U.ApplicationId=A.ApplicationId
	WHERE OrgId=@OrgId
	ORDER BY CCI
	--Anterior consulta
	--Select	[OUName] as [IDBusinessUnits],[OUDescription] as [Name]--[IDBusinessUnits],[Name],[PCC]
	--From	dbo.OperativeUnits--[dbo].[BusinessUnits] 
	--Order By [OUName]--[Name]
End




