-- =============================================
-- Author: Jessica Gutierrez
-- Create date: 14/07/14
-- Description:	Extraer informacion de clientes de interjet
-- =============================================
CREATE PROCEDURE GetClientUserInterjet 
@User as nvarchar(50)
AS
BEGIN
	Select [FareType]
	from [dbo].[ClientUsersInterjet]
	where [Users]=@User
END
