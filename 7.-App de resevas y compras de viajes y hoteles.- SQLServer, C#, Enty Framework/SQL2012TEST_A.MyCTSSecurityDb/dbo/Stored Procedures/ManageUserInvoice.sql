-- =============================================
-- Author:        <Marcos Q. Ramirez>
-- Create date: <2014-10-29>
-- Description:    <Manejo de datos de Userinvoice>
-- =============================================
CREATE PROCEDURE [dbo].[ManageUserInvoice]
    -- Add the parameters for the stored procedure here

@p_UserMail    nvarchar(50),
    @p_Password    nvarchar(50),
    @p_OrgId    int,
    @p_CreationDate    datetime,
    @p_Status    bit,
    @p_FamilyName    nvarchar(100),
    @p_type int



AS

BEGIN
     DECLARE @var_email varchar(50)  

    if @p_type = 1
    begin
    select * from userinvoices
    where UserMail = @p_UserMail
    end
    else if @p_type = 2
    begin

    SET @var_email = (select  UserMail from userinvoices where UserMail = @p_UserMail)
    if @var_email is  NULL
    begin
    INSERT INTO [dbo].[UserInvoices]
           ([UserMail]
           ,[Password]
           ,[OrgId]
           ,[CreationDate]
           ,[Status]
           ,[FamilyName])
     VALUES
           (@p_UserMail    ,
    @p_Password    ,
    @p_OrgId,
    @p_CreationDate    ,
    @p_Status,
    @p_FamilyName)
    end
    else
    UPDATE [dbo].[UserInvoices]
   SET [UserMail] = @p_UserMail
      ,[Password] = @p_Password
      ,[OrgId] = @p_OrgId
      ,[CreationDate] = @p_CreationDate
      ,[Status] = @p_Status
      ,[FamilyName] = @p_FamilyName
 WHERE  UserMail = @p_UserMail
    end

END
