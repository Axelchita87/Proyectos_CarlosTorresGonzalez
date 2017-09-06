-- =============================================
-- Author:		Marcos Q. Ramirez
-- Create date: 27-10-2011
-- Description:	Procedure that get lines that
-- will be procedured by MYCTSHotelRobot
-- =============================================
CREATE Procedure [dbo].[GetPNRHotels]
AS
Begin
        SELECT * FROM (select distinct
dense_rank() over(PARTITION by record order by [created_date] desc) as SelectedIndex2,
						[record],
						[OrgId],
						[Mail],
						[Status],
						[RemarksString],
						[DK],
						[Operational_Unit],						
						[Sales_Source],
						[created_date],						
						[Provid_Direc_pay],
						[Service_Type]
from (select distinct [record],
		   [OrgId],
		   [Mail],
		   [Status],
		   [RemarksString],
		   [DK],
		   [Operational_Unit],		   
		   [Sales_Source],
           [created_date],		             
		   [Provid_Direc_pay],
           [Service_Type]
	from (
	select 
						dense_rank() over(PARTITION by record order by created_date desc) as SelectedIndex,
						[record],
						[OrgId],
						[Mail],
						[Status],
						[RemarksString],
						[DK],
						[Operational_Unit],						
						[Sales_Source],
						[created_date],
                        [time_limit],						
						[Provid_Direc_pay],
                        [Service_Type]
		from dbo.DetailsPNRHotel
		where [status] is not null
		and [status] <> 0
		and [status] <> 4
		and [status] <> 5
		and [record] is not null
		and [provid_Direc_Pay] = 'True'
        and ([time_limit] < getdate() or record in (select rec.fcPNR from tblCXSHoteles rec where rec.fcPNR = record and fcautorization is not null or fcautorization <> '' ))
		and [GeaErrorMsg] is null   
		and [Operational_Unit] is not null
		and [Operational_Unit]   <> ''
	) as tbl
	where SelectedIndex = 1	    
union
select distinct [record],
		   [OrgId],
		   [Mail],
		   [Status],
		   [RemarksString],
		   [DK],
		   [Operational_Unit],		   
		   [Sales_Source],
           [created_date],		   
		   [Provid_Direc_pay],
           [Service_Type]
		from dbo.DetailsPNRHotel
		where [status] is not null
		and [status] = 1		
		and [record] is not null
		and [provid_Direc_Pay] = 'False'
        and [Created_date] > '06-02-2014' 
		and [GeaErrorMsg] is null   
		union 
		select distinct [record],
		   [OrgId],
		   [Mail],
		   [Status],
		   [RemarksString],
		   [DK],
		   [Operational_Unit],		   
		   [Sales_Source],
           [created_date],		   
		   [Provid_Direc_pay],
           [Service_Type] from (
	select distinct
						dense_rank() over(PARTITION by record order by [status] desc, [created_date] DESC) as SelectedIndex,
						[record],
						[OrgId],
						[Mail],
						[Status],
						[RemarksString],
						[DK],
						[Operational_Unit],						
						[Sales_Source],
						[created_date],
                        [time_limit],						
						[Provid_Direc_pay],
                        [Service_Type]
		from dbo.DetailsPNRHotel
		where [status] is not null		
		and [status] > 3	
		and [record] is not null
		and [provid_Direc_Pay] = 'True'        
		and [GeaErrorMsg] is null   
		and [record] IN (select rec.fcPNR from tblCXSHoteles rec where rec.fcPNR = record and fcautorization is not null or fcautorization <> '' )
		AND created_date > '20-05-2014'
		 )
	as tbl where SelectedIndex = 1 and status = 4
	) as tbl2) AS TBL3 --WHERE  SelectedIndex2 = 1
End

-- =============================================
-- EXECUTE dbo.GetPNRHotels
-- =============================================