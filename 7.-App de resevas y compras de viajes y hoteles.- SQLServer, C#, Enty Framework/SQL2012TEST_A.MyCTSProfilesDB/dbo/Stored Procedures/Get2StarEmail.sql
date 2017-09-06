
-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Create date: <30/Agosto/2011>
-- Description:	<Obtiene Email de la tabla Star2>
-- =============================================
CREATE PROCEDURE [dbo].[Get2StarEmail] 
	@Email as varchar(30)
	
AS
BEGIN
	Declare @id as int
	Declare @Name as varchar(30)
	Declare @Level1 as varchar(30)



	Select @id = Id From dbo.Stars
	Where [Value]= @Email and FieldKey=37

	Select @Name=[Value]  From dbo.Stars
	Where Id=@id and FieldKey=29
	
	Select @Level1=[Value] From dbo.Stars
	Where Id=@id and FieldKey=28

	Select @Name as 'Value', @Level1 as 'Level1'
	

END