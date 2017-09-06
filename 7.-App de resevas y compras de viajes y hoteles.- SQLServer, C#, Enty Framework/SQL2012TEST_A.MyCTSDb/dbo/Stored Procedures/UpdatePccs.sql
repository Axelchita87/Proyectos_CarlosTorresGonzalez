




-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: 07-06-2010
-- Description:	Update PCC
-- Modify by: */
-- =============================================
create PROCEDURE [dbo].[UpdatePccs] 
@CatPccId varchar(50),
@CatPccName varchar(150),
@Status varchar(1),
@StandardClass varchar(1),
@SpecificClass varchar(1),
@Confirmation varchar(1),
@BusinessClass1 varchar(1),
@BusinessClass2 varchar(1),
@BusinessClass3 varchar(1),
@BusinessClass4 varchar(1)


AS
BEGIN
	update  dbo.CatPccs
	set CatPccName=@CatPccName,Status=@Status,StandardClass=@StandardClass,
SpecificClass=@SpecificClass,Confirmation=@Confirmation,BusinessClass1=@BusinessClass1,
BusinessClass2=@BusinessClass2,BusinessClass3=@BusinessClass3,BusinessClass4=@BusinessClass4
	where CatPccId=@CatPccId
END
