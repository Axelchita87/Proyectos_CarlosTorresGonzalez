CREATE TABLE [dbo].[Star2] (
    [Pccid]    VARCHAR (10)  NULL,
    [Level1]   NVARCHAR (50) NULL,
    [Level2]   NVARCHAR (50) NULL,
    [Type]     VARCHAR (3)   NULL,
    [Text]     VARCHAR (100) NULL,
    [Date]     DATETIME      NULL,
    [Purged]   BIT           NULL,
    [Metadata] AS            ([dbo].[CalculateMetadata]([Type],[Text])),
    [Email]    NVARCHAR (50) NULL
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_Star2_8_1013578649__K3_4_5]
    ON [dbo].[Star2]([Level2] ASC)
    INCLUDE([Type], [Text]);


GO
CREATE NONCLUSTERED INDEX [_dta_index_Star2_8_1013578649__K2_4_5]
    ON [dbo].[Star2]([Level1] ASC)
    INCLUDE([Type], [Text]);


GO
CREATE NONCLUSTERED INDEX [IX_Star2]
    ON [dbo].[Star2]([Pccid] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Star2_1]
    ON [dbo].[Star2]([Pccid] ASC, [Level1] ASC, [Level2] ASC);


GO
-- =============================================
-- Author:		Luis Felipe Segura Velasco
-- Create date: 10 de Mayo de 2012
-- Description:	PA para la mejora de consultas
-- =============================================
CREATE TRIGGER dbo.tgrStar2InsertMail
   ON  dbo.Star2
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @iPosicion INT

	IF EXISTS (SELECT Email FROM inserted WHERE metadata = 'MAIL'AND Email IS NOT NULL  )
	BEGIN
		IF EXISTS ( SELECT 1
			FROM tblCorreos s2
			JOIN inserted cs
			ON s2.pccId = cs.Pccid
			AND s2.Level2 = cs.Level2
			AND s2.level1 = cs.level1)
		BEGIN
			UPDATE tblCorreos
			SET Email = cs.Email
			FROM inserted cs
			WHERE tblCorreos.pccId = cs.Pccid
			AND tblCorreos.Level2 = cs.Level2
			AND tblCorreos.level1 = cs.level1
		END
		ELSE
		BEGIN
			INSERT INTO tblCorreos
			SELECT 
				1,
				Email,
				pccId,
				level1,
				Level2
			FROM    inserted 
			WHERE   metadata = 'MAIL'
			AND Email IS NOT NULL 			
		END
	END
END
