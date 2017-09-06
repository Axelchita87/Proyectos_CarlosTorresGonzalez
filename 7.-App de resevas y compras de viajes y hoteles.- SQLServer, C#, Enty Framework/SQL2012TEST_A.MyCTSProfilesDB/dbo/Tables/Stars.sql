CREATE TABLE [dbo].[Stars] (
    [Id]       INT            NOT NULL,
    [FieldKey] INT            NOT NULL,
    [Value]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Stars] PRIMARY KEY CLUSTERED ([Id] ASC, [FieldKey] ASC),
    CONSTRAINT [FK_Stars_DetailStars] FOREIGN KEY ([FieldKey]) REFERENCES [dbo].[DetailStars] ([Id])
);


GO
CREATE TRIGGER [dbo].[ReceiveOrderForProcess]
ON [dbo].[Stars]
FOR UPDATE
AS
BEGIN
SET NOCOUNT ON
DECLARE @InitDlgHandle UNIQUEIDENTIFIER;
DECLARE @RequestMsg XML;
DECLARE @Level int;
BEGIN TRANSACTION;
BEGIN DIALOG @InitDlgHandle
FROM SERVICE [//SenderDB/Databases/SenderService]
TO SERVICE N'//DestDB/Databases/DestService'
ON CONTRACT [//Common/Databases/DBContract]
WITH
ENCRYPTION = OFF;
if((select level from detailstars as d, inserted where d.id = inserted.FieldKey) = 2)
	begin
SET @RequestMsg =
(
	

	select inserted.*, s1.Value as correo, s2.FieldName
	from inserted inner join Stars s1 on s1.Id= inserted.Id AND s1.FieldKey=37
	inner join DetailStars s2 on inserted.FieldKey=s2.Id
	for xml raw, type
	
)
end
IF @RequestMsg is not null
print 'xml:'+(cast(@RequestMsg as varchar(MAX)))
BEGIN   
SEND ON CONVERSATION @InitDlgHandle
MESSAGE TYPE [//Common/Databases/SendMessage]
(@RequestMsg);
END
COMMIT TRANSACTION;
END

GO
DISABLE TRIGGER [dbo].[ReceiveOrderForProcess]
    ON [dbo].[Stars];

