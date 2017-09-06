
-- Batch submitted through debugger: SQLQuery7.sql|7|0|I:\Users\Emmanuel\AppData\Local\Temp\~vs4C49.sql
-- =============================================
-- Author:		<Ivan Martínez Guerrero>
-- Create date: <22/julio/2011>
-- Description:	<Procedimiento almacenado que permite extraer trajetas de crédito
--				 de la tabla de perfiles>
-- =============================================
CREATE PROCEDURE [dbo].[GetCreditCardsFirstLevel_MYCTS]
	-- Add the parameters for the stored procedure here
	@dk as nvarchar(10)
	
AS
BEGIN
declare @id as int
declare @CreditCard1 as varchar(50)
declare @expiration1 as varchar(50)
declare @CreditCard2 as varchar(50)
declare @expiration2 as varchar(50)
declare @CreditCard3 as varchar(50)
declare @expiration3 as varchar(50)
declare @CreditCard4 as varchar(50)
declare @expiration4 as varchar(50)
declare @CreditCard5 as varchar(50)
declare @expiration5 as varchar(50)
declare @cvv1 as varchar(50)
declare @cvv2 as varchar(50)
declare @cvv3 as varchar(50)

select @id=id from Stars
where FieldKey=1 and [Value]=@dk--Parametro

select @CreditCard1=[Value] from Stars
where id=@id and FieldKey=18

select @expiration1=[Value] from Stars
where id=@id and FieldKey=19

select @CreditCard2=[Value] from Stars
where id=@id and FieldKey=85

select @expiration2=[Value] from Stars
where id=@id and FieldKey=86

select @CreditCard3=[Value] from Stars
where id=@id and FieldKey=87

select @expiration3=[Value] from Stars
where id=@id and FieldKey=88

select @CreditCard4=[Value] from Stars
where id=@id and FieldKey=89

select @expiration4=[Value] from Stars
where id=@id and FieldKey=90

select @CreditCard5=[Value] from Stars
where id=@id and FieldKey=91

select @expiration5=[Value] from Stars
where id=@id and FieldKey=92

IF EXISTS(select [Value] from Stars where id=@id and FieldKey=(SELECT Id FROM DetailStars WHERE FieldName = 'CVV1'))
begin
	select @cvv1=[Value] from Stars
	where id=@id and FieldKey=(SELECT Id FROM DetailStars WHERE FieldName = 'CVV1')
end
ELSE
begin
	select @cvv1 = ''
end

if exists(select [Value] from Stars
where id=@id and FieldKey=(SELECT Id FROM DetailStars WHERE FieldName = 'CVV2'))
begin
	select @cvv2=[Value] from Stars
where id=@id and FieldKey=(SELECT Id FROM DetailStars WHERE FieldName = 'CVV2')
end
else
begin
	select @cvv2=''
end

if exists(select [Value] from Stars
where id=@id and FieldKey=(SELECT Id FROM DetailStars WHERE FieldName = 'CVV3'))
begin
select @cvv3=[Value] from Stars
where id=@id and FieldKey=(SELECT Id FROM DetailStars WHERE FieldName = 'CVV3')
end
else
begin
select @cvv3=''
end

select      @CreditCard1+'*#*'+@expiration1+'*#*'+@cvv1 CreditCard1, @CreditCard2+'*#*'+@expiration2+'*#*'+@cvv2 CreditCard2,
            @CreditCard3+'*#*'+@expiration3+'*#*'+@cvv3 CreditCard3, @CreditCard4+'*#*'+@expiration4 CreditCard4,
            @CreditCard5+'*#*'+@expiration5 CreditCard5
END 


--INSERT INTO [dbo].[DetailStars]
--           ([FieldName]
--           ,[OrderNum]
--           ,[Level]
--           ,[Visible]
--           ,[Observaciones])
--     VALUES
--           ('CVV1'
--           ,41
--           ,1
--           ,1
--           ,'Para el buen funcionamiento del sistema NO modifique estos valores')
--GO

--  USE [MyCTSProfilesDb]
--GO

--INSERT INTO [dbo].[DetailStars]
--           ([FieldName]
--           ,[OrderNum]
--           ,[Level]
--           ,[Visible]
--           ,[Observaciones])
--     VALUES
--           ('CVV2'
--           ,42
--           ,1
--           ,1
--           ,'Para el buen funcionamiento del sistema NO modifique estos valores')
--GO

--  USE [MyCTSProfilesDb]
--GO

--INSERT INTO [dbo].[DetailStars]
--           ([FieldName]
--           ,[OrderNum]
--           ,[Level]
--           ,[Visible]
--           ,[Observaciones])
--     VALUES
--           ('CVV3'
--           ,43
--           ,1
--           ,1
--           ,'Para el buen funcionamiento del sistema NO modifique estos valores')
--GO


-- USE [MyCTSDb]
-- GO
-- INSERT INTO [dbo].[Parameter]
           -- ([ParameterName]
           -- ,[Values]
           -- ,[Description])
     -- VALUES
           -- ('NumDocs'
           -- ,5
           -- ,'numero de imagenes permitidas en un perfil')