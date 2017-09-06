-- =============================================
-- Author:		<Angel Trejo Arizmendi>
-- Creation date: 22-03-2010
-- Description:	Get Code Meal to DIX  
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[GetCodeMealToDIX] 

@CodeMeal varchar(1)

AS
BEGIN
	select DescriptionMeal
	from dbo.CatMealCodesToDIX
	where CodeMeal = @CodeMeal
END