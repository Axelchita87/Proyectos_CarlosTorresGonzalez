







-- =============================================
-- Author:		<Marcos Q. Ramirez Luna>
-- Create date: <05/Febrero/2010>
-- Description:	<Obtiene el catalogo de todas las estrellas de primer y segundo nivel>
-- Modificación: <Ivan Martínez Guerrero, Obtener Dk Para perfiles 1er. Nivel y correo para perfiles de 2do. nivel>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllStarstemp] 
	@OrgId int
AS
BEGIN
    -- Insert statements for procedure here
	declare @id as int
	declare @ApplicationId as uniqueidentifier 
	select @ApplicationId=ApplicationId from MyCTSSecurityDb.dbo.Applications where OrgId=@OrgId
	
    /*select CF.Pccid 'PccId', CF.Star1Name 'StarName','1' 'Level', null 'Star1Ref', CF.Active, CF.IsNew, null 'Email',
    case S1.Text when null then null else Substring(S1.Text,3,6) End[DK] 
    from dbo.CatStarsFirstLevel CF
	join MyCTSDb.dbo.CatPccs CP on CF.Pccid=CP.CatPccId 
    and cp.ApplicationId=@ApplicationId
	left join Star1 S1 on S1.Level1=CF.Star1Name AND S1.Metadata='Numero de Cliente' 
    where cf.StarL2Exist is not null
	union 
    select CS.Pccid 'PccId', Star2Name 'Star', '2' 'Level', Star1id 'Star1Ref', Active, IsNew, 
    case S2.Text when null then null else Substring(S2.Text,4,(Len(S2.Text))) End[Email],
    null 'DK' 
    from dbo.CatStarsSecondLevel CS
	join MyCTSDb.dbo.CatPccs CP on CS.Pccid=CP.CatPccId 
    and CP.ApplicationId=@ApplicationId
	left join Star2 S2 on S2.Level2=CS.Star2Name and S2.Metadata='Mail'*/
      SELECT distinct st.PccId,
         st.StarName,
         st.[Level],
         st.Star1Ref,
         st.Active, 
	     CASE S1.Text
                WHEN NULL
                THEN NULL
                ELSE Substring(S1.Text,3,6)
         END[DK],
         CASE S2.Text
                WHEN NULL
                THEN NULL
                ELSE Substring(S2.Text,4,(LEN(S2.Text)))
        END[Email]      
		from
		(
		SELECT CF.Pccid 'PccId',
				   CF.Star1Name 'StarName',
				   '1' 'Level',
				   NULL 'Star1Ref',
				   CF.Active,
				   CF.IsNew		   
			FROM   dbo.CatStarsFirstLevel CF         
			WHERE  cf.StarL2Exist IS NOT NULL    
			UNION    
			SELECT CS.Pccid 'PccId',
				   Star2Name 'Star',
				   '2' 'Level',
				   Star1id 'Star1Ref',
				   Active,
				   IsNew           
			FROM   dbo.CatStarsSecondLevel CS
		) st
		LEFT JOIN Star1 S1
		ON     S1.Level1=st.StarName
		AND    S1.Metadata='Numero de Cliente'
		LEFT JOIN Star2 S2
		ON     S2.Level2=st.StarName
		AND    S2.Metadata='Mail'
		JOIN MyCTSDb.dbo.CatPccs CP
		ON     st.Pccid=CP.CatPccId
		AND    CP.ApplicationId=@ApplicationId

END







