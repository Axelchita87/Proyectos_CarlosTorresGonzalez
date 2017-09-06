CREATE TABLE [dbo].[QCControlsFeatures] (
    [IDCtrl]              VARCHAR (50)  NOT NULL,
    [CtrlType]            VARCHAR (50)  NULL,
    [ReservationCtrlType] VARCHAR (50)  NULL,
    [CtrlName]            VARCHAR (50)  NULL,
    [CtrlDescription]     VARCHAR (50)  NULL,
    [CtrlLen]             INT           NULL,
    [CtrlCurrentCriteria] VARCHAR (50)  NULL,
    [CtrlCatalogues]      VARCHAR (150) NULL,
    [AllowInsertValues]   BIT           CONSTRAINT [DF_QCControlsFeatures_AllowInsertValues] DEFAULT ((0)) NULL,
    [Order]               INT           NULL,
    CONSTRAINT [PK_ControlsQC] PRIMARY KEY CLUSTERED ([IDCtrl] ASC)
);

