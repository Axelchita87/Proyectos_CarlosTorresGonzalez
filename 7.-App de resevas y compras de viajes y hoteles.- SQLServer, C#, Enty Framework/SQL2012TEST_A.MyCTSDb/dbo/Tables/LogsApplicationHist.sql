CREATE TABLE [dbo].[LogsApplicationHist] (
    [LogID]            INT            IDENTITY (1, 1) NOT NULL,
    [UserName]         NVARCHAR (256) NULL,
    [Firm]             NVARCHAR (50)  NULL,
    [UserControlName]  NVARCHAR (150) NULL,
    [DateCreated]      DATETIME       CONSTRAINT [DF_LogsApplicationHist_DateCreated] DEFAULT (getdate()) NULL,
    [ErrorDescription] NVARCHAR (MAX) NULL,
    [StackTrace]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_LogsApplicationHist] PRIMARY KEY CLUSTERED ([LogID] ASC)
);

