

-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <18/Febrero/2010>
-- Description:	<Actualiza la información de la estrella de primer nivel>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateStarLevel1] 
	-- Add the parameters for the stored procedure here
	@Pccid nvarchar(10), 
	@Level1 nvarchar(50),
    @NewLevel1 nvarchar(50),
    @ProcessId INT
AS
BEGIN
    -- Insert statements for procedure here
	
	
	if(@ProcessId = 0)
	begin
		Update dbo.CatStarsFirstLevel
		set Star1Name = @NewLevel1, IsNew = 1, DK=@NewLevel1
		where  Pccid = @Pccid and Star1Name = @Level1
		
--		Update dbo.CatStarsFirstLevel
--		set Active = 0, InactiveDate = (SELECT {fn NOW()})
--		where  Pccid != @Pccid and Star1Name = @Level1

		Update dbo.Star1
		set Level1 = @NewLevel1
		where  Pccid = @Pccid and Level1 = @Level1
	    
		Update dbo.CatStarsSecondLevel
		set  Star1id = @NewLevel1
		where  Pccid = @Pccid and Star1id = @Level1 

		Update dbo.Star2
		Set Level1=@NewLevel1
		where Pccid = @Pccid and Level1 = @Level1

--Cursor k desactiva los perfiles del mismo DK
---------------------------------------------------------------------------------------------------------
DECLARE @star1Name AS VARCHAR(40)
DECLARE @pcc AS VARCHAR(10)
Declare @id as int

DECLARE deactivate_profiles_cursor CURSOR FAST_FORWARD FOR
/*(select distinct Star1Name,CF.Pccid from dbo.CatStarsFirstLevel CF
inner join Star1 S1 on CF.Star1Name=S1.Level1
where S1.Level1=CF.Star1Name and S1.Metadata='Numero de Cliente' and Substring([Text],3,6)=@NewLevel1 and IsNew is null)*/
(select distinct CF.Star1Name,CF.Pccid from dbo.CatStarsFirstLevel CF
--inner join Star1 S1 on CF.Star1Name=S1.Level1
where CF.DK = @NewLevel1 and IsNew is null)

OPEN deactivate_profiles_cursor
      
      FETCH NEXT FROM deactivate_profiles_cursor INTO
      @star1Name, @pcc
            
            WHILE @@FETCH_STATUS = 0
            BEGIN
                  
                Update dbo.CatStarsFirstLevel
				Set Active = 0, InactiveDate = (SELECT {fn NOW()})
				Where Star1Name = @star1Name and Pccid=@pcc

				Update dbo.CatStarsSecondLevel
				Set Star1Id=@NewLevel1, Pccid=@Pccid
				Where Star1Id = @star1Name and Pccid=@pcc

				Update dbo.Star2
				Set Level1=@NewLevel1, Pccid=@Pccid
				Where Level1=@star1Name and Pccid=@pcc

                FETCH NEXT FROM deactivate_profiles_cursor INTO
				@star1Name, @pcc
            END
            
CLOSE deactivate_profiles_cursor
DEALLOCATE deactivate_profiles_cursor
--------------------------------------------------------------------------------------------------------------------


DECLARE @Variable numeric
DECLARE MyCursor CURSOR FAST_FORWARD
FOR

-- Realizamos la consulta que queremos guardar en la variable

(select Id from (
select s1.Id ,s1.Value as 'Pcc', s2.value as 'Level1' from 
dbo.Stars as s1
left join
dbo.Stars as s2 on s1.id = s2.id 
where s1.fieldkey = 27 and s2.fieldkey = 28) as Tresult 
where Pcc = @Pccid and Level1 = @Level1)
-- Abrimos el cursor
OPEN MyCursor

FETCH NEXT FROM MyCursor INTO 
@Variable

WHILE (@@FETCH_STATUS <> -1)
BEGIN
IF (@@FETCH_STATUS <> -2)
BEGIN 


UPDATE [Stars]
   SET 
      [Value] = @NewLevel1
 WHERE Id = @Variable and FieldKey=1

--Accedemos al siguiente registro del cursor
END
FETCH NEXT FROM MyCursor INTO 
@Variable
END

--Cerramos el cursor
CLOSE MyCursor

-- lo sacamos de la memoria
DEALLOCATE MyCursor
	end
	
	else if(@ProcessId = 1)
	begin
		Update dbo.CatStarsFirstLevel
		set StarL2Exist = 'True'
		where  Pccid = @Pccid and Star1Name = @Level1
	end
	else if(@ProcessId = 2)
	begin
		Update dbo.CatStarsFirstLevel
		set StarL2Exist = 'False'
		where  Pccid = @Pccid and Star1Name = @Level1
	end
END

-------------------------------------------------------------------------------------------

SET ANSI_NULLS ON
