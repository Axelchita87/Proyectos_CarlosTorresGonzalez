-- =============================================
-- Author:		Marcos Ramirez Luna
-- Create date: 26-06-2013
-- Description:	Procedure that gets event Codes Catalog
-- =============================================
CREATE Procedure [dbo].[GetEventCodes]
 @Location as varchar(10)
  ,@Type as int
AS
Begin
if @Type = 1 
begin
 select clave_evento AS EventCode, descripcion AS EventDescription from CatEventosOracle
 where dk = @location 
 end
 else if @Type = 2
 begin
 select clave_evento AS EventCode, descripcion AS EventDescription from CatEventosOracle
 where dk in (select LOCATION from Location_Attribute where Attribute1 = @Location)
end

 End


