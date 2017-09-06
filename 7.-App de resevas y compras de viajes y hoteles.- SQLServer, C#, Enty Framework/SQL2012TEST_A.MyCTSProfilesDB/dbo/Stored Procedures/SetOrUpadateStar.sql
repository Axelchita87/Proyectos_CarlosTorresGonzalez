
-- =============================================
-- Author:		<Emmanuel Flores>
-- Create date: <26/Julio/2011>
-- Description:	<Procedimiento almacenado que inserta o actualiza un perfil>
-- =============================================
CREATE PROCEDURE [dbo].[SetOrUpadateStar] 
	-- Add the parameters for the stored procedure here
	 @Id as int = null,
	 @Field as varchar(100),
	 @Value as varchar(Max),
	 @Level as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
   declare @FieldKey as int
	if(@Id is null)
	select top 1 @Id = Id + 1 from Stars Order by Id desc
	
	select @FieldKey = Id from DetailStars where FieldName = @Field and [Level] = @Level
	print @FieldKey

	if(@FieldKey is not null)
		begin
	

		if (@Value is not Null )--and  --@Value <> '' or   @Field = 'MiddleName')
			if not Exists (Select Id from Stars where Id = @Id and FieldKey = @FieldKey)
			begin
				print 'Inserta'
				insert  into Stars values(@Id,@FieldKey,@Value)
			end
			else
			begin
				print 'actualiza'
				update Stars set [Value] = @Value where (Id = @Id and FieldKey = @FieldKey);
			end
	end
	select @Id
end

