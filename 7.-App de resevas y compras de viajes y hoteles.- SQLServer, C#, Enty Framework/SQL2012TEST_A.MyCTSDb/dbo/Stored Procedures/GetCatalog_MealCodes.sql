
-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Jun-2009
-- =============================================
CREATE Procedure [dbo].[GetCatalog_MealCodes]
 AS 
Begin
select CatMeaCodCode [Value], 
(CatMeaCodCode + ' ' + CatMeaCodALCode + ' ' + CatMeaCodDescription) [Text],
 CatMeaCodALCode [Text2], CatMeaCodDescription [Text3],'' [Text5],'' [Text6],'' [Text7],'' [Text8]
from 
(
Select Distinct rtrim(CatMeaCodCode) CatMeaCodCode, rtrim(CatMeaCodALCode) CatMeaCodALCode,
				rtrim(CatMeaCodDescription) CatMeaCodDescription
		From dbo.CatMealCodes
) as MealCodes
 End

