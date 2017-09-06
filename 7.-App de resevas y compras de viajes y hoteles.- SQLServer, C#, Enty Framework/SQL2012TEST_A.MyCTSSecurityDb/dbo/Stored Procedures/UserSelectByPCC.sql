



-- =============================================
-- Author:		<Jessica Gutierrez>
-- Creation date: 19-05-2010
-- Description:	Extraer los usuarios por PCC
-- Modify by: */
-- =============================================

create  PROCEDURE [dbo].[UserSelectByPCC] (
	@PCC nvarchar(50),
	@Firm nvarchar(50)
)
AS

SET NOCOUNT ON

SELECT
	[UserName],
	[FamilyName],
	[Agent],
	[Queue],
	[TA],
	[UserMail],
	[UserId]
FROM
	[Users]
WHERE
	[PCC] = @PCC and
	[Firm]= @Firm

