CREATE SERVICE [//SenderDB/Databases/SenderService]
    AUTHORIZATION [dbo]
    ON QUEUE [dbo].[SenderQueue];

