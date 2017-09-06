
-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <17/11/2011>
-- Description:	<Set the value of Dk for level 2 Stars >
-- =============================================
CREATE PROCEDURE [dbo].[UpdateStar2MailAll] 	
@OrgId int
AS
BEGIN
DECLARE @PccId AS VARCHAR(20)
DECLARE @Star2Name AS VARCHAR(20)
DECLARE @EMail AS VARCHAR(30)
DECLARE @Text AS VARCHAR(20)
DECLARE @Star1Name AS VARCHAR(20)

DECLARE mail_cursor CURSOR FAST_FORWARD FOR
select distinct s2.level1,
       s2.level2, 
       s2.Pccid,
       case S2.Text when null then null else Substring(S2.Text,4,(Len(S2.Text))) End[Email],      
       S2.[Text]
from Star2 s2
join MyCTSDb.dbo.CatPccs CP on s2.Pccid=CP.CatPccId 
and CP.ApplicationId=(select ApplicationId from MyCTSSecurityDb.dbo.Applications where OrgId=@OrgId)
where S2.Metadata='Mail'
--and s2.Level2='Martinez/ivan'

OPEN mail_cursor				
        FETCH next FROM mail_cursor INTO
        @Star1Name, @Star2Name, @PccId, @EMail, @Text
        WHILE @@FETCH_STATUS = 0        
		BEGIN      
             --select @EMail as value
             update dbo.Star2
             set Email = @EMail
             where Level2 = @Star2Name
             and PccId = @PccId
             AND Metadata='Mail'            
             and level1 = @Star1Name    
        FETCH next FROM mail_cursor INTO
        @Star1Name, @Star2Name, @PccId, @EMail, @Text                                  
		END
CLOSE mail_cursor
DEALLOCATE mail_cursor
END