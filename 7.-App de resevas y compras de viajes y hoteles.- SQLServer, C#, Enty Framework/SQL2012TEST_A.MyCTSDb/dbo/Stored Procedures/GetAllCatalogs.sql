
-- =============================================
-- Author:		Eduardo Sánchez Almazán
-- Create date: Jun-2009
-- =============================================
CREATE Procedure [dbo].[GetAllCatalogs]
 AS 
Begin

exec GetCatalog_AirPortCityCountry_MIN

exec GetCatalog_AirPortCityCountry_MAJ

exec GetCatalog_AirLines

exec GetCatalog_Countries

exec GetCatalog_BusCodes

exec GetCatalog_Hotels

exec GetCatalog_CreditCardsCodes

exec GetCatalog_SeaVendorsCodes

exec GetCatalog_CurrenciesCountries

exec GetCatalog_StatusCodes

exec GetCatalog_Cities

exec GetCatalog_StatesUSA
 
exec GetCatalog_AirLinesClasses

exec GetCatalog_TypesCodes

exec GetCatalog_EquipmentCodes

exec GetCatalog_VendorCodes

exec GetCatalog_Pccs

exec GetCatalog_ConfirmDK

exec GetCatalog_PAirLinesFare

exec GetCatalog_CostCenters

exec GetCatalog_MealCodes

exec GetCatalog_Agents
End

