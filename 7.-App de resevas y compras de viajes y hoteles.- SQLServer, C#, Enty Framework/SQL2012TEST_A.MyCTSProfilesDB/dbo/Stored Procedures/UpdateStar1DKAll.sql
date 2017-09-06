

-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <16/11/2010>
-- Description:	<Set the value of Dk for level 1 Stars >
-- =============================================
CREATE PROCEDURE [dbo].[UpdateStar1DKAll] 	
@OrgId int
AS
BEGIN
DECLARE @PccId AS VARCHAR(10)
DECLARE @Star1Name AS VARCHAR(10)
DECLARE @DK AS VARCHAR(10)
DECLARE @Metadata AS VARCHAR(50)
DECLARE @Index AS INT
DECLARE @Lenght AS INT
DECLARE @Value AS VARCHAR(100)
DECLARE dk_cursor CURSOR FAST_FORWARD FOR
select distinct s1.level1, 
       s1.Pccid,
       --case s1.[Text] when null then null else Substring(s1.[Text],3,6) End[DK]  
       s1.[text] dk, 
       s1.metadata
from Star1 s1
join MyCTSDb.dbo.CatPccs CP on s1.Pccid=CP.CatPccId 
and CP.ApplicationId=(select ApplicationId from MyCTSSecurityDb.dbo.Applications where OrgId=@OrgId)
where upper(s1.text) like '%DK%' 
and s1.type = 'A'
--S1.Metadata='Numero de Cliente'


OPEN dk_cursor
FETCH next FROM dk_cursor INTO
	@Star1Name, @PccId, @DK, @Metadata
		
		WHILE @@FETCH_STATUS = 0
		BEGIN         
             if @Metadata = 'Numero de Cliente' 
             BEGIN 
             update dbo.CatStarsFirstLevel
             set dk = Substring(@DK,3,6) 
             where Star1Name = @Star1Name
             and PccId = @PccId             
             END
             /*ELSE             
					 set @Index = 0
					 set @Index = CHARINDEX('DK', @DK)
					 if @Index > 0
					 begin

							  set @Lenght = datalength(@DK)
                              if (@Lenght - @Index) >= 6
                              begin
									  set @Value =  Substring(@DK,@Index + 2,@Lenght - (@Index + 2))
									  set @Value = ltrim(@Value)
									  if datalength(@Value) >= 6
									  begin
                                              set @value = replace(@value, ':', '')
                                              set @value = replace(@value, '-', '')
											  set @value = Substring(@Value,1,6) 
											  update dbo.CatStarsFirstLevel
											  set dk = @value 
											  where Star1Name = @Star1Name
											  and PccId = @PccId     
									  end 
                              end
					 end */
                          
             FETCH next FROM dk_cursor INTO
			 @Star1Name, @PccId, @DK, @Metadata
        END
CLOSE dk_cursor
DEALLOCATE dk_cursor
END