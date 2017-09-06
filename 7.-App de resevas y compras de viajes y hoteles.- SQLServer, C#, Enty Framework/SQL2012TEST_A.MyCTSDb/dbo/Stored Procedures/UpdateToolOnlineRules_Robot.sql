

-- =============================================
-- Author:		<Jessica Gutierrez Becerril>
-- Creation date: 02/12/2013
-- Description:	Update ToolOnlineRules
-- Modify by: */
-- =============================================
CREATE PROCEDURE [dbo].[UpdateToolOnlineRules_Robot] 
@Corporative varchar(50),
 @ToolOnline varchar(30),
 @Attribute1 varchar(50),
 @Supervisor varchar(50),
 @SupAgent int,
 @SupPCC varchar(50),
 @SupStatus char(20),
 @Consultor1 varchar(50),
 @ConAgent1 int,
 @ConPCC1 varchar(50),
 @ConStatus1 char(20),
 @CountConsul1 bit,
 @Consultor2 varchar(50),
 @ConAgent2 int,
 @ConPCC2 varchar(50),
 @ConStatus2 char(20),
 @CountConsul2 bit,
 @Consultor3 varchar(50),
 @ConAgent3 int,
 @ConPCC3 varchar(50),
 @ConStatus3 char(20),
 @CountConsul3 bit,
 @Consultor4 varchar(50),
 @ConAgent4 int,
 @ConPCC4 varchar(50),
 @ConStatus4 char(20),
 @CountConsul4 bit,
 @Consultor5 varchar(50),
 @ConAgent5 int,
 @ConPCC5 varchar(50),
 @ConStatus5 char(20),
 @CountConsul5 bit,
 @FechaInsert datetime,
 @InsertBy int,
 @FechaUpdate datetime,
 @UpdateBy int
AS
BEGIN
	update  [dbo].[ToolOnlineRules]
	set		 Corporative=@Corporative,
             ToolOnline=@ToolOnline ,
			 SupPCC=@SupPCC,          
             Supervisor=@Supervisor,
		     SupAgent=@SupAgent,
			 SupStatus=@SupStatus,
			 Consultor1=@Consultor1, 
			 ConAgent1=@ConAgent1,
			 ConPCC1=@ConPCC1, 
			 ConStatus1=@ConStatus1,
			 CountConsul1= @CountConsul1,
			 Consultor2=@Consultor2, 
			 ConAgent2=@ConAgent2,
			 ConPCC2=@ConPCC2, 
			 ConStatus2=@ConStatus2,
			 CountConsul2= @CountConsul2, 
			 Consultor3=@Consultor3, 
			 ConAgent3=@ConAgent3,
			 ConPCC3=@ConPCC3,
			 ConStatus3=@ConStatus3,
			 CountConsul3= @CountConsul3,
			 Consultor4=@Consultor4, 
			 ConAgent4=@ConAgent4, 
			 ConPCC4=@ConPCC4,
			 ConStatus4=@ConStatus4,
			 CountConsul4= @CountConsul4, 
			 Consultor5=@Consultor5, 
			 ConAgent5=@ConAgent5, 
			 ConPCC5=@ConPCC5,
			 ConStatus5=@ConStatus5,
			 CountConsul5= @CountConsul5,
			 FechaInsert=@FechaInsert, 
			 InsertBy=@InsertBy,
			 FechaUpdate=@FechaUpdate,
			 UpdateBy=@UpdateBy 
	where  Attribute1=@Attribute1

END