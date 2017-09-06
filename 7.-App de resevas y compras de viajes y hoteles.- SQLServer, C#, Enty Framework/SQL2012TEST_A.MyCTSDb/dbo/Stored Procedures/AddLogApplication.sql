
-- =============================================
-- Author:		Eduardo S. Almazán
-- Description:	Add log when an exception is fired by the application
-- =============================================
CREATE Procedure [dbo].[AddLogApplication]
 @UserName nvarchar(256),
 @Firm nvarchar(50),
 @UserControlName NVARCHAR(150),
 @ErrorDescription nvarchar(max),
 @StackTrace nvarchar(max) 
AS

INSERT INTO [LogsApplication]
           ([UserName]
           ,[UserControlName]           
           ,[ErrorDescription]
           ,[StackTrace]
           ,[Firm])
     VALUES
           (
			@UserName,
			@UserControlName,
			@ErrorDescription,
			@StackTrace,
			@Firm			
           )
 
 




