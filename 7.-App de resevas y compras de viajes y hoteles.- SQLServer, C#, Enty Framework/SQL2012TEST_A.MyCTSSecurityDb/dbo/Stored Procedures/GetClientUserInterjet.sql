-- =============================================
-- Author: Jessica Gutierrez
-- Create date: 14/07/14
-- Description:	Extraer informacion de clientes de interjet
-- =============================================
CREATE PROCEDURE [dbo].[GetClientUserInterjet] 
@User as nvarchar(50)
AS
BEGIN
	Select [FareType],[Password], [NumberPurse],[SpecialRates]
	from [dbo].[ClientUsersInterjet]
	where [Users]=@User
END