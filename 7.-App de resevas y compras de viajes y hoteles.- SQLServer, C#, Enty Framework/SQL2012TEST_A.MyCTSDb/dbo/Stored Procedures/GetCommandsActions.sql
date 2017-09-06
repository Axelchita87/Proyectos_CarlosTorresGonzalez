

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCommandsActions]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN

SELECT c.[ID]
      ,c.[Command]
      ,m.ModulesName
      ,c.[Message]
      ,c.[CommandType]
	  ,m.ModulesSrc
	  ,[Allow]
	  ,c.CommandsAllowed
	  ,c.CommandsRestricted
  FROM CommandsActions c
  LEFT JOIN Modules m
  ON c.UserControl = m.ModulesID
	
END



