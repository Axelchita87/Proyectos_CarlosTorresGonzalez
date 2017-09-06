


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCommandsRestricted_Phase2]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN

SELECT c.[ID]
      ,c.[Command]
      ,m.[ModulesName]
      ,c.[Message]
      ,c.[CommandType]
	  ,c.[Allow]
	  ,m.[ModulesSrc]
  FROM CommandsRestricted c
LEFT JOIN Modules m
ON m.ModulesId = c.UserControl
	
END




