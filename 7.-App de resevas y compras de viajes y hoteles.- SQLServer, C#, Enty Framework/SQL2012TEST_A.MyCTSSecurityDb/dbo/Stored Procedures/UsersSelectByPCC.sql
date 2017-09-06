

-- =============================================
-- Author:		<Jessica Gutierrez>
-- Creation date: 07-05-2010
-- Description:	Extraer los usuarios por PCC
-- Modify by: */
-- =============================================

CREATE  PROCEDURE [dbo].[UsersSelectByPCC] (
	@PCC nvarchar(50)
)
AS

SET NOCOUNT ON

SELECT
	[UserName],
	[Firm],
	[FamilyName],
	[Agent]
	
FROM
	[Users]
WHERE
	[PCC] = @PCC